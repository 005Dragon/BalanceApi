using Balance.Api.Validators;
using Balance.Services;
using Balance.Services.Contracts;
using Balance.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace Balance.Api.Controllers;

[ApiController]
[Route(template: "[controller]")]
public class BalanceController : ControllerBase
{
    private readonly IBalanceService _balanceService;

    public BalanceController(IBalanceService balanceService)
    {
        _balanceService = balanceService;
    }
    
    [HttpGet]
    public IActionResult GetBalances(int accountId, PeriodType periodType)
    {
        if (!GetBalancesApiParametersValidator.Validate(accountId, periodType, out IActionResult? errorActionResult))
        {
            return errorActionResult;
        }
    
        List<BalanceDto> balances = _balanceService.GetBalances(accountId, periodType);
    
        return Ok(balances);
    }
}