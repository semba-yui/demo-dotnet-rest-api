using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Serilog;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace SembaYui.DemoRestApi.IntegrationTests.Controllers.V1;

public class WeatherForecastTest : IClassFixture<WebApplicationFactory<Program>>
{
    /// <summary>
    ///     Endpoint
    /// </summary>
    private const string TargetEndpoint = "/api/v1.0/weatherforecast";

    private readonly HttpClient _client;

    public WeatherForecastTest(WebApplicationFactory<Program> webApplicationFactory,
        ITestOutputHelper iTestOutputHelper)
    {
        _client = webApplicationFactory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });

        // Logging
        var logOutput = (TestOutputHelper)iTestOutputHelper;
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.TestOutput(logOutput)
            .CreateLogger();
    }


    [Fact(DisplayName = "正常系")]
    public async Task Ok()
    {
        // -------------------
        // Setup
        // -------------------
        // do nothing

        // -------------------
        // Exercise
        // -------------------
        var response = await _client.GetAsync(TargetEndpoint);

        // -------------------
        // Verify
        // -------------------
        response.Should().NotBeNull();
        // HTTP Status
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
