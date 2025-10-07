using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.IO;
using BT3_Nhom3_23WebC.Models;

namespace BT2_Nhom3_23WebC.Middleware
{
    public class RequestLogMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // T?o log model
            var log = new RequestFileLogModel
            {
                Timestamp = DateTime.Now,
                Level = "Info",
                Message = $"Request {context.Request.Method} {context.Request.Path}",
                Source = context.Connection.RemoteIpAddress?.ToString() ?? "Unknown",
                Exception = ""
            };

            var logFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "logs");
            Directory.CreateDirectory(logFolder);
            var logFilePath = Path.Combine(logFolder, "log.txt");
            string logContent = $"{log.Timestamp:yyyy-MM-dd HH:mm:ss} [{log.Level}] {log.Message} (Source: {log.Source}) Exception: {log.Exception}\n";
            await File.AppendAllTextAsync(logFilePath, logContent);

            await _next(context);
        }
    }
}
