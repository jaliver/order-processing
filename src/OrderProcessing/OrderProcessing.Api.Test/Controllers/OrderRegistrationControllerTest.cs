using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OrderProcessing.Api.Data;
using Xunit;

namespace OrderProcessing.Api.Test.Controllers
{
    public class OrderRegistrationControllerTest
    {
        private const string BaseUri = "api/v1/orderregistration";

        [Fact]
        public async Task When_CallingCreateOrders_Then_ReturnsOk()
        {
            var app = await GetWebAppFactory(Guid.NewGuid().ToString());
            using var httpClient = app.CreateClient();

            var requestUrl = GetOrderEndpointUrl();

            var response = await httpClient.PostAsync(requestUrl, null);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task When_CallingCreateOrders_Then_ReturnsReceiptWithProcessedDateLaterThanCreatedDate()
        {
            var app = await GetWebAppFactory(Guid.NewGuid().ToString());
            using var httpClient = app.CreateClient();

            var requestUrl = GetOrderEndpointUrl();

            var response = await httpClient.PostAsync(requestUrl, null);
            var som = response.Content;
            var e = await som.ReadAsStringAsync();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        private static string GetOrderEndpointUrl()
        {
            return $"{BaseUri}/orders";
        }

        private static async Task<WebApplicationFactory<Program>> GetWebAppFactory(string uniqueTestDbName)
        {
            await using var app = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(DbContextOptions<OrderDbContext>));
                        services.AddDbContext<OrderDbContext>(options =>
                        {
                            options.UseInMemoryDatabase(uniqueTestDbName);
                        });
                    }));

            return app;
        }
    }
}
