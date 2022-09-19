using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace MVCLearn.Middlewares
{
    public class MaintenanceMiddleware
    {
        private readonly RequestDelegate _next;
        public MaintenanceMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext, IConfiguration configuration)
        {
            if(!httpContext.Request.Path.Value.Contains("/maintenance"))
                if (configuration.GetValue<bool>("IsMaintenance"))
                {
                    httpContext.Response.Redirect("/maintenance");
                }
            await _next(httpContext);
        }
    }
}
