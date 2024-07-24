using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using SembaYui.DemoRestApi.Repositories.Interfaces;

namespace SembaYui.DemoRestApi.IntegrationTests.Common;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    public Mock<IDateTimeRepository>? DateTimeRepositoryMock { get; private set; }

    public JsonSerializerOptions JsonOptions { get; } =
        new() { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower };


    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            DateTimeRepositoryMock = new Mock<IDateTimeRepository>();

            // Replace the existing IDateTimeRepository registration with the mock
            services.RemoveAll(typeof(IDateTimeRepository));
            services.AddSingleton(DateTimeRepositoryMock.Object);
        });
    }
}
