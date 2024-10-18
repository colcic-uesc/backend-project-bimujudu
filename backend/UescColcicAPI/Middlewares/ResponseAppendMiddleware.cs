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
        await _next(context);  

        context.Response.Headers.Add("X-APP-NAME", "MyApp");
        context.Response.Headers.Add("X-APP-API-VERSION", "0.1");
    }
}
