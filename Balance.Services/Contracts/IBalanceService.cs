using Balance.Services.Models;

namespace Balance.Services.Contracts;

public interface IBalanceService
{
    List<BalanceDto> GetBalances(int accountId, PeriodType periodType);
}