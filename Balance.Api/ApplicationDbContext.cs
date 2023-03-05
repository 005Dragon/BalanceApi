using Balance.Storage;

namespace Balance.Api;

public class ApplicationDbContext : DataDbContext
{
    public ApplicationDbContext(IConfiguration configuration) : base(configuration)
    {
    }
}