using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Collibri.Middleware
{
    public class RequestResponseMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestResponseMiddleware> _logger;

        public RequestResponseMiddleware(RequestDelegate next, ILogger<RequestResponseMiddleware> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(HttpContext context)
        {
            // Capture request details
            LogRequest(context.Request);

            // Buffer the response stream to capture the content
            var originalBodyStream = context.Response.Body;

            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    context.Response.Body = memoryStream;

                    // Continue processing the request pipeline
                    await _next.Invoke(context);

                    // Log response details including content
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    using (var reader = new StreamReader(memoryStream))
                    {
                        string responseContent = await reader.ReadToEndAsync();
                        LogResponse(context.Response, responseContent);

                        // Copy the content back to the original response stream
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        await memoryStream.CopyToAsync(originalBodyStream);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing request: {ex.Message}");
            }
            finally
            {
                // Restore the original response body stream
                context.Response.Body = originalBodyStream;
            }
        }

        private void LogRequest(HttpRequest request)
        {
            string logMessage = $"[{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}] {request.Method} {request.Path}";
            _logger.LogInformation(logMessage);
        }

        private void LogResponse(HttpResponse response, string responseContent)
        {
            string logMessage = $"[{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}] Status Code:{response.StatusCode}{Environment.NewLine}Content: {responseContent}";
            _logger.LogInformation(logMessage);
        }
    }

    public static class RequestResponseLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestResponseLogging(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestResponseMiddleware>();
        }
    }
}
