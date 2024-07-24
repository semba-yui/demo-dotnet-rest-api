using Asp.Versioning;
using SembaYui.DemoRestApi.Commons.Json;
using SembaYui.DemoRestApi.Commons.Logging;
using SembaYui.DemoRestApi.Middlewares;
using SembaYui.DemoRestApi.Repositories.Implementations;
using SembaYui.DemoRestApi.Repositories.Interfaces;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Load Configuration
builder.Configuration.AddJsonFile("appsettings.json", false, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = new SnakeCaseNamingPolicy();
});

// Add support to API Versioning
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
});

// DI
builder.Services.AddSingleton<IDateTimeRepository, DateTimeRepositoryImpl>();
builder.Services.AddSingleton<LogMessages>();
builder.Services.AddTransient<RequestResponseLoggingMiddleware>();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

// Add support to logging with SERILOG
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

// Add support to localization
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

var app = builder.Build();

// Middleware
app.UseMiddleware<RequestResponseLoggingMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Add support to logging request with SERILOG
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.MapControllers();

// Add support to localization
var supportedCultures = new[] { "en", "ja" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);

await app.RunAsync();

/// <summary>
///     For Integration Test.
///     <see
///         href="https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-8.0#basic-tests-with-the-default-webapplicationfactory" />
/// </summary>
public abstract partial class Program;
