using Balance.Storage.Records;
using Newtonsoft.Json;

namespace Balance.Storage;

public class SourceReader
{
    public IEnumerable<AccountRecord> AccountRecords => _idToAccountRecordIndexes.Values;
    public IEnumerable<AccrualRecord> AccrualRecords => _accrualRecords;
    public IEnumerable<PaymentRecord> PaymentRecords => _paymentRecords;
    public IEnumerable<HistoryAmountRecord> HistoryAmountRecords => _historyAmountRecords;

    private readonly Dictionary<int, AccountRecord> _idToAccountRecordIndexes = new();
    private readonly List<AccrualRecord> _accrualRecords = new();
    private readonly List<PaymentRecord> _paymentRecords = new();
    private readonly List<HistoryAmountRecord> _historyAmountRecords = new();

    public void ReadBalances(string path)
    {
        using var streamReader = new StreamReader(path);
        string jsonString = streamReader.ReadToEnd();
        
        dynamic json = JsonConvert.DeserializeObject(jsonString);

        if (json == null)
        {
            return;
        }

        int index = 0;
        
        foreach (dynamic balanceItem in json.balance)
        {
            AccountRecord account = GetOrCreateAccountRecord((int)balanceItem.account_id);
            DateTime dateTime = DateTime.ParseExact((string)balanceItem.period, "yyyyMM", null);

            var accrualRecord = new AccrualRecord
            {
                Id = ++index,
                AccountId = account.Id,
                DateTime = dateTime,
                Amount =  (decimal)balanceItem.calculation
            };
            
            _accrualRecords.Add(accrualRecord);

            var amountHistoryRecord = new HistoryAmountRecord
            {
                Id = index,
                AccrualId = index,
                Amount = (decimal)balanceItem.in_balance
            };
            
            _historyAmountRecords.Add(amountHistoryRecord);
        }
    }
    
    public void ReadPayments(string path)
    {
        using var streamReader = new StreamReader(path);
        string jsonString = streamReader.ReadToEnd();
        
        dynamic json = JsonConvert.DeserializeObject(jsonString);
        
        if (json == null)
        {
            return;
        }
        
        int index = 0;
        
        foreach (dynamic paymentItem in json)
        {
            AccountRecord account = GetOrCreateAccountRecord((int)paymentItem.account_id);
            
            var paymentRecord = new PaymentRecord
            {
                Id = ++index,
                Guid = (Guid)paymentItem.payment_guid,
                AccountId = account.Id,
                DateTime = DateTime.Parse((string)paymentItem.date),
                Amount = (decimal)paymentItem.sum
            };
            
            _paymentRecords.Add(paymentRecord);
        }
    }

    private AccountRecord GetOrCreateAccountRecord(int accountId)
    {
        if (!_idToAccountRecordIndexes.TryGetValue(accountId, out AccountRecord accountRecord))
        {
            accountRecord = new AccountRecord { Id = accountId };
            
            _idToAccountRecordIndexes[accountId] = accountRecord;
        }

        return accountRecord;
    }
}