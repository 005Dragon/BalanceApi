namespace Balance.Services.Models;

public class BalanceDto
{
    public string PeriodName { get; set; }
    public decimal StartAmount { get; set; }
    public decimal AccrualAmount { get; set; }
    public decimal PaymentAmount { get; set; }
    public decimal EndAmount { get; set; }
}