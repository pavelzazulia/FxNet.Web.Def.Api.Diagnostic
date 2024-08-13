using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FxNet.Web.Def.Api.Diagnostic.Middleware
{
    public class GlobalExceptionHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var traceId = Guid.NewGuid();

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var problemDetails = new
                {
                    Type = "Name of exception",
                    Id = context.Request.Form["Id"],
                    Data = new { Message = ex.Message }
                };
                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }
    }
}
