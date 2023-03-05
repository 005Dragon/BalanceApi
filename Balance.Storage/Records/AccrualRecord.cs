using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Balance.Storage.Records;

public class AccrualRecord
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [ForeignKey(nameof(AccountRecord))]
    public int AccountId { get; set; }
    public AccountRecord Account { get; set; }
    
    public DateTime DateTime { get; set; }
    
    public decimal Amount { get; set; }
}