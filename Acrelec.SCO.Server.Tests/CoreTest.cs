using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Acrelec.SCO.Core.Model.RestExchangedMessages;
using Acrelec.SCO.DataStructures;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace Acrelec.SCO.Server.Tests
{
    public class CoreTest
    {
        private readonly HttpClient _client;

        public CoreTest()
        {
            var builder = new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>();
            var server = new TestServer(builder);

            _client = server.CreateClient();
        }

        [Fact]
        public async Task Check_Availability()
        {
            var result = await _client.GetFromJsonAsync<CheckAvailabilityResponse>("/api-sco/v1/availability");

            Assert.NotNull(result);
            Assert.True(result.CanInjectOrders);

        }

        [Fact]
        public async Task Inject_Order_To_Success()
        {
            var model = new InjectOrderRequest
            {
                Order = new Order
                {
                    OrderItems = new List<OrderedItem>
                    {
                        new()
                        {
                            ItemCode = "100",
                            Qty = 1
                        },
                        new()
                        {
                            ItemCode = "200",
                            Qty = 2
                        },
                    }
                },
                Customer = new Customer
                {
                    Address = "Bucharest",
                    Firstname = "John"
                }
            };
            var request = await _client.PostAsJsonAsync("/api-sco/v1/injectorder", model);

            Assert.True(request.IsSuccessStatusCode);
            var result = await request.Content.ReadFromJsonAsync<InjectOrderResponse>();
            Assert.NotNull(result);
            Assert.Equal("10", result.OrderNumber);

        }

        [Fact]
        public async Task Customer_Details_Is_Empty()
        {
            var model = new InjectOrderRequest
            {
                Order = new Order
                {
                    OrderItems = new List<OrderedItem>
                    {
                        new()
                        {
                            ItemCode = "100",
                            Qty = 1
                        },
                        new()
                        {
                            ItemCode = "200",
                            Qty = 2
                        },
                    }
                }
            };
            var request = await _client.PostAsJsonAsync("/api-sco/v1/injectorder", model);

            Assert.False(request.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, request.StatusCode);
            Assert.Equal("Bad Request", request.ReasonPhrase);
        }


    }
}
