using Balance.Storage.Records;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Balance.Storage;

public abstract class DataDbContext : DbContext
{
    public DbSet<AccountRecord> Accounts { get; set; }
    public DbSet<AccrualRecord> Accruals { get; set; }
    public DbSet<PaymentRecord> Payments { get; set; }
    public DbSet<HistoryAmountRecord> HistoryAmounts { get; set; }

    private readonly IConfiguration _configuration;

    protected DataDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite(_configuration.GetConnectionString("BalanceDatabase"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        CreatePresetData(modelBuilder);
    }

    private static void CreatePresetData(ModelBuilder modelBuilder)
    {
        var sourceReader = new SourceReader();

        sourceReader.ReadBalances("Sources/balance_202105270825.json");
        sourceReader.ReadPayments("Sources/payment_202105270827.json");
        
        modelBuilder.Entity<AccountRecord>().HasData(sourceReader.AccountRecords.ToArray());
        modelBuilder.Entity<HistoryAmountRecord>().HasData(sourceReader.HistoryAmountRecords.ToArray());
        modelBuilder.Entity<AccrualRecord>().HasData(sourceReader.AccrualRecords.ToArray());
        modelBuilder.Entity<PaymentRecord>().HasData(sourceReader.PaymentRecords.ToArray());
    }
}