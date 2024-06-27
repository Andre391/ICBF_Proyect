using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

public class HorarioRestriccionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var currentHour = DateTime.Now.Hour;

        if (currentHour < 8 || currentHour > 10)
        {
            context.Result = new RedirectToActionResult("Privacy", "Home", null);
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}
