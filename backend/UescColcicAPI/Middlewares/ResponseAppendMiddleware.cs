using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class ResponseAppendMiddleware
{
    private readonly RequestDelegate _next;

    public ResponseAppendMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.OnStarting(() =>
        {
            context.Response.Headers.Append("X-APP-NAME", "MeuApp");
            context.Response.Headers.Append("X-APP-API-VERSION", "0.1");
            return Task.CompletedTask;
        });

        await _next(context);
    }
}