using Balance.Services.Contracts;
using Balance.Services.Models;
using Balance.Storage;
using Balance.Storage.Records;

namespace Balance.Services.Implementations;

public class BalanceService : IBalanceService
{
    private readonly DataDbContext _dataDbContext;

    public BalanceService(DataDbContext dataDbContext)
    {
        _dataDbContext = dataDbContext;
    }

    public List<BalanceDto> GetBalances(int accountId, PeriodType periodType)
    {
        AccrualRecord[] accruals = 
            _dataDbContext.Accruals.Where(x => x.AccountId == accountId).OrderBy(x => x.DateTime).ToArray();

        PaymentRecord[] payments =
            _dataDbContext.Payments.Where(x => x.AccountId == accountId).OrderBy(x => x.DateTime).ToArray();

        bool accountHasOperationPeriod =
            TryGetAccountOperationPeriod(
                accruals,
                payments,
                out DateTime minOperationDate,
                out DateTime maxOperationDate
            );

        if (!accountHasOperationPeriod)
        {
            return new List<BalanceDto>();
        }

        IEnumerable<DateTime> periods = GetPeriods(minOperationDate, maxOperationDate, periodType);

        return CalculateBalances(periodType, periods, accruals, payments);
    }

    private List<BalanceDto> CalculateBalances(
        PeriodType periodType, 
        IEnumerable<DateTime> periods, 
        IReadOnlyList<AccrualRecord> accruals,
        IReadOnlyList<PaymentRecord> payments)
    {
        var result = new List<BalanceDto>();
        
        decimal balanceAmount = GetInitialBalanceAmount(accruals);

        bool startPeriodDateProvided = false;
        DateTime startPeriodDate = default;

        foreach (DateTime endPeriodDate in periods)
        {
            if (!startPeriodDateProvided)
            {
                startPeriodDate = endPeriodDate;
                startPeriodDateProvided = true;
                
                continue;
            }

            var balance = new BalanceDto
            {
                PeriodName = GetPeriodName(startPeriodDate, periodType),
                StartAmount = balanceAmount,
                AccrualAmount =
                    accruals.Where(x => startPeriodDate <= x.DateTime && endPeriodDate > x.DateTime).Sum(x => x.Amount),
                PaymentAmount =
                    payments.Where(x => startPeriodDate <= x.DateTime && endPeriodDate > x.DateTime).Sum(x => x.Amount),
            };

            balanceAmount += balance.PaymentAmount - balance.AccrualAmount;

            balance.EndAmount = balanceAmount;

            result.Add(balance);

            startPeriodDate = endPeriodDate;
        }

        return result;
    }

    private decimal GetInitialBalanceAmount(IReadOnlyList<AccrualRecord> accruals)
    {
        if (accruals.Count == 0)
        {
            return 0m;
        }
        
        return _dataDbContext.HistoryAmounts.FirstOrDefault(x => x.AccrualId == accruals[0].Id)?.Amount ?? 0m;
    }

    private static bool TryGetAccountOperationPeriod(
        IEnumerable<AccrualRecord> accruals, 
        IEnumerable<PaymentRecord> payments,
        out DateTime minOperationDate,
        out DateTime maxOperationDate)
    {
        minOperationDate = default;
        maxOperationDate = default;
        
        bool operationDateProvided = false;

        foreach (AccrualRecord accrual in accruals)
        {
            if (!operationDateProvided)
            {
                minOperationDate = accrual.DateTime;
                maxOperationDate = accrual.DateTime;
                
                operationDateProvided = true;
                
                continue;
            }
            
            if (minOperationDate > accrual.DateTime)
            {
                minOperationDate = accrual.DateTime;
            }

            if (maxOperationDate < accrual.DateTime)
            {
                maxOperationDate = accrual.DateTime;
            }
        }

        foreach (PaymentRecord payment in payments)
        {
            if (!operationDateProvided)
            {
                minOperationDate = payment.DateTime;
                maxOperationDate = payment.DateTime;
                
                operationDateProvided = true;
                
                continue;
            }
            
            if (minOperationDate > payment.DateTime)
            {
                minOperationDate = payment.DateTime;
            }

            if (maxOperationDate < payment.DateTime)
            {
                maxOperationDate = payment.DateTime;
            }
        }

        return operationDateProvided;
    }

    private static IEnumerable<DateTime> GetPeriods(
        DateTime minOperationDate,
        DateTime maxOperationDate,
        PeriodType periodType)
    {
        switch (periodType)
        {
            case PeriodType.Month:
            {
                var currentPeriodDate = new DateTime(minOperationDate.Year, minOperationDate.Month, 1);
            
                while (currentPeriodDate <= maxOperationDate)
                {
                    yield return currentPeriodDate;

                    currentPeriodDate = currentPeriodDate.AddMonths(1);
                }
                
                yield return currentPeriodDate;
            
                yield break;
            }
            case PeriodType.Quarter:
            {
                var currentPeriodDate = new DateTime(minOperationDate.Year, 1 + minOperationDate.Month / 3 * 3, 1);

                while (currentPeriodDate <= maxOperationDate)
                {
                    yield return currentPeriodDate;

                    currentPeriodDate = currentPeriodDate.AddMonths(3);
                }

                yield return currentPeriodDate;

                yield break;
            }
            case PeriodType.Year:
            {
                var currentPeriodDate = new DateTime(minOperationDate.Year, 1, 1);

                while (currentPeriodDate <= maxOperationDate)
                {
                    yield return currentPeriodDate;

                    currentPeriodDate = currentPeriodDate.AddYears(1);
                }
                
                yield return currentPeriodDate;

                break;
            }
            case PeriodType.None:
            {
                break;
            }
            default:
            {
                throw new ArgumentOutOfRangeException(nameof(periodType), periodType, null);
            }
        }
    }

    private static string GetPeriodName(DateTime dateTime, PeriodType periodType)
    {
        return periodType switch
        {
            PeriodType.Month => dateTime.ToString("yyyyMM"),
            PeriodType.Quarter => $"{dateTime.Year}{1 + dateTime.Month / 3}",
            PeriodType.Year => dateTime.Year.ToString(),
            _ => throw new ArgumentOutOfRangeException(nameof(periodType), periodType, null)
        };
    }
}