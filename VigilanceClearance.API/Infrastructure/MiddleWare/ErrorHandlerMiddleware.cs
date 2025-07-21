using VigilanceClearance.Application.Interfaces;

namespace VigilanceClearance.API.Infrastructure.MiddleWare
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILogService logService)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await logService.LogAsync(ex.Message, ex.StackTrace ?? "");
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("An unexpected error occurred.");
            }
        }
    }

}
