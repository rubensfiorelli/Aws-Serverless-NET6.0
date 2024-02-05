using Amazon;
using Amazon.SQS;
using Aws.Application.PortsDriver;
using Aws.Core.AdaptersDriven;
using AWS.Application.Services;
using AWS.Core.DTOs.Input;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Register.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class OrdersController : ControllerBase
    {

        private readonly ILogger<OrdersController> _logger;
        private readonly IOrderDriver _service;


        public OrdersController(ILogger<OrdersController> logger, IOrderDriver service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost("orders")]
        public async Task<IActionResult> Post(InputOrderDto request)
        {
            var sQSClient = new AmazonSQSClient(RegionEndpoint.USEast1);
            var publisher = new SqsPublisher(sQSClient);

            await _service.Add(request);


            if (request is not null)
            {
                await publisher.PublisherAsync("order-notification", new NotificationMsg
                {
                    Id = Guid.NewGuid().ToString(),
                    Notification = JsonSerializer.Serialize(request.OrderNumber),
                    Type = 1

                });
            }

            Console.WriteLine($" Request successfully added to DynamoDB");

            _logger.LogInformation("Request successfully!");

            return Ok(request);
        }


    }
}
