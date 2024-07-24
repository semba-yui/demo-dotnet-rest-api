using Serilog;

namespace SembaYui.DemoRestApi.Middlewares;

public class RequestResponseLoggingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // リクエストをログに出力
        var requestBody = "";
        if (context.Request.ContentLength > 0 || context.Request.ContentType?.Contains("application/json") == true)
        {
            context.Request.EnableBuffering();
            using var reader = new StreamReader(context.Request.Body, leaveOpen: true);
            requestBody = await reader.ReadToEndAsync();
            context.Request.Body.Position = 0;
        }

        Log.Information("Request: {Method} {Path} {Body}", context.Request.Method, context.Request.Path, requestBody);

        // レスポンスをキャプチャ
        var originalBodyStream = context.Response.Body;
        using var responseBody = new MemoryStream();
        context.Response.Body = responseBody;

        await next(context);

        // レスポンスをログに出力
        context.Response.Body.Seek(0, SeekOrigin.Begin);
        var responseBodyText = await new StreamReader(context.Response.Body).ReadToEndAsync();
        context.Response.Body.Seek(0, SeekOrigin.Begin);
        Log.Information("Response: {StatusCode} {Body}", context.Response.StatusCode, responseBodyText);

        await responseBody.CopyToAsync(originalBodyStream);
    }
}
