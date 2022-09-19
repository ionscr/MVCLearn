using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCLearn.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if(context.Exception is KeyNotFoundException)
            {
                context.Result = new StatusCodeResult(404);
            }
            context.ExceptionHandled = true;
            context.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    {"controller", "Error" },
                    {"action", "ErrorPage"}
                }
                );
        }
    }
}
