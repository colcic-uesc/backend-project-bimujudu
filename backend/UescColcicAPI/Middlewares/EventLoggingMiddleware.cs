using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class EventLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly UescColcicAPI.Services.BD.UescColcicDBContext _dbContext;

    public EventLoggingMiddleware(RequestDelegate next, UescColcicAPI.Services.BD.UescColcicDBContext dbContext)
    {
        _next = next;
        _dbContext = dbContext;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();

        // Captura as informações da requisição
        var clientIp = context.Connection.RemoteIpAddress?.ToString();
        var hasJwtToken = context.Request.Headers.ContainsKey("Authorization");
        var requestMethod = context.Request.Method;
        var requestUrl = context.Request.Path;
        var requestTime = DateTime.UtcNow;
        
        await _next(context);

        stopwatch.Stop();
        var totalProcessingTime = stopwatch.ElapsedMilliseconds;

        // Cria um log e salva no banco de dados
        var log = new RequestLog
        {
            ClientIp = clientIp,
            HasJwtToken = hasJwtToken,
            RequestMethod = requestMethod,
            RequestUrl = requestUrl,
            RequestTime = requestTime,
            TotalProcessingTime = totalProcessingTime
        };

        _dbContext.RequestLogs.Add(log);
        await _dbContext.SaveChangesAsync();
    }
}
