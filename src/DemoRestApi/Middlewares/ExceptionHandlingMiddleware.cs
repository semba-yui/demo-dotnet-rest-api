using System.Net;
using System.Net.Mime;
using SembaYui.DemoRestApi.Commons.Logging;
using SembaYui.DemoRestApi.Exceptions;
using SembaYui.DemoRestApi.Models.Responses;
using SembaYui.DemoRestApi.Repositories.Interfaces;
using Serilog;

namespace SembaYui.DemoRestApi.Middlewares;

/// <summary>
///     例外を処理するミドルウェア
/// </summary>
/// <param name="logMessages"></param>
public class ExceptionHandlingMiddleware(LogMessages logMessages, IDateTimeRepository dateTimeRepository) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (OriginalApplicationException ae)
        {
            Log.Error(ae, logMessages.L0001UnhandledException);

            if (!context.Response.HasStarted)
            {
                var now = dateTimeRepository.Now;
                await HandleOriginalApplicationExceptionAsync(context, now);
            }
        }
        catch (OriginalSystemException se)
        {
            Log.Error(se, logMessages.L0002ApplicationException);

            if (!context.Response.HasStarted)
            {
                var now = dateTimeRepository.Now;
                await HandleOriginalSystemExceptionAsync(context, now);
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, logMessages.L0003SystemException);

            if (!context.Response.HasStarted)
            {
                var now = dateTimeRepository.Now;
                await HandleExceptionAsync(context, now);
            }
        }
    }

    /// <summary>
    ///     アプリケーション例外を処理する
    /// </summary>
    /// <param name="context"></param>
    /// <param name="now"></param>
    /// <returns></returns>
    private static Task HandleOriginalApplicationExceptionAsync(HttpContext context, DateTime now)
    {
        context.Response.ContentType = MediaTypeNames.Application.Json;
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        var response = new ErrorResponse(ResponseCodes.ClientError, now);

        return context.Response.WriteAsJsonAsync(response);
    }

    /// <summary>
    ///     システム例外を処理する
    /// </summary>
    /// <param name="context"></param>
    /// <param name="now"></param>
    /// <returns></returns>
    private static Task HandleOriginalSystemExceptionAsync(HttpContext context, DateTime now)
    {
        context.Response.ContentType = MediaTypeNames.Application.Json;
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = new ErrorResponse(ResponseCodes.SystemError, now);

        return context.Response.WriteAsJsonAsync(response);
    }

    /// <summary>
    ///     その他の例外を処理する
    /// </summary>
    /// <param name="context"></param>
    /// <param name="now"></param>
    /// <returns></returns>
    private static Task HandleExceptionAsync(HttpContext context, DateTime now)
    {
        context.Response.ContentType = MediaTypeNames.Application.Json;
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var result = new ErrorResponse(ResponseCodes.UnknownError, now);

        return context.Response.WriteAsJsonAsync(result);
    }
}
