using Balance.Services.Contracts;
using Balance.Services.Implementations;
using Balance.Storage;

namespace Balance.Api;

public static class TransientInitializer
{
    public static void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<DataDbContext, ApplicationDbContext>();

        builder.Services.AddTransient<IBalanceService, BalanceService>();
    }
}