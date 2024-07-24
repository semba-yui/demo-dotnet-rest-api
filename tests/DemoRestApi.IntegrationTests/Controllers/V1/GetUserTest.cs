using System.Net;
using FluentAssertions;
using FluentAssertions.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using SembaYui.DemoRestApi.IntegrationTests.Common;
using Serilog;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace SembaYui.DemoRestApi.IntegrationTests.Controllers.V1;

public class GetUserTest : IClassFixture<CustomWebApplicationFactory>
{
    /// <summary>
    ///     Endpoint
    /// </summary>
    private const string TargetEndpoint = "/api/v1.0/user";

    private readonly HttpClient _client;

    /// <summary>
    ///     Expected response JSON path
    /// </summary>
    private readonly string _expectedResponseJsonPath =
        Path.Combine("TestData", "ExpectedResponses", "User", "GetUser");

    private readonly CustomWebApplicationFactory _factory;

    public GetUserTest(CustomWebApplicationFactory webApplicationFactory,
        ITestOutputHelper iTestOutputHelper)
    {
        _factory = webApplicationFactory;

        _client = _factory.CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });

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
        var testDateTime = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Local);
        _factory.DateTimeRepositoryMock?.Setup(repo => repo.Now).Returns(testDateTime);

        // Expected response
        var expectedResponsePath = Path.Combine(_expectedResponseJsonPath, "ok.json");
        var expectedResponse = await File.ReadAllTextAsync(expectedResponsePath);
        var expectedJson = JToken.Parse(expectedResponse);

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

        // Response body
        var actualJson = JToken.Parse(await response.Content.ReadAsStringAsync());
        actualJson.Should().BeEquivalentTo(expectedJson);
    }
}
