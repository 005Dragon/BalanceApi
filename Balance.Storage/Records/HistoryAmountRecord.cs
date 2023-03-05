using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Balance.Storage.Records;

public class HistoryAmountRecord
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [ForeignKey(nameof(AccrualRecord))]
    public int AccrualId { get; set; }
    public AccrualRecord Accrual { get; set; }
    
    public decimal Amount { get; set; }
}