using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.IO;

public class EventLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _logFilePath = "request_logs.txt";

    public EventLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();

        // Captura as informações da requisição
        var clientIp = context.Connection.RemoteIpAddress?.ToString();
        var hasJwtToken = context.Request.Headers.ContainsKey("Authorization");
        var requestMethod = context.Request.Method;
        var requestUrl = context.Request.Path;
        var requestTime = DateTime.Now;

        await _next(context);

        stopwatch.Stop();
        var totalProcessingTime = stopwatch.ElapsedMilliseconds;

        // Cria um log e salva em um arquivo
        var log = $"ClientIp: {clientIp}, HasJwtToken: {hasJwtToken}, RequestMethod: {requestMethod}, RequestUrl: {requestUrl}, RequestTime: {requestTime}, TotalProcessingTime: {totalProcessingTime}ms";
        await File.AppendAllTextAsync(_logFilePath, log + "\n");
    }
}
        

