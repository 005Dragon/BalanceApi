using Balance.Api.Responses;
using Balance.Services;
using Microsoft.AspNetCore.Mvc;

namespace Balance.Api.Validators;

public static class GetBalancesApiParametersValidator
{
    public static bool Validate(int accountId, PeriodType periodType, out IActionResult errorActionResult)
    {
        if (accountId == default)
        {
            errorActionResult = new BadRequestObjectResult(ValueMustBeProvidedError(nameof(accountId)));

            return false;
        }

        if (periodType == default)
        {
            errorActionResult = new BadRequestObjectResult(ValueMustBeProvidedError(nameof(periodType)));

            return false;
        }

        errorActionResult = default;
        return true;
    }
    
    private static ApiErrorResponse ValueMustBeProvidedError(string propertyName)
    {
        return new ApiErrorResponse { ErrorMessage = $"Value {propertyName} must be provided." };
    }
}