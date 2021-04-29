using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using recipe_web.Models;

namespace recipe_web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAmazonSimpleNotificationService snsClient;
        
        public HomeController(ILogger<HomeController> logger, IAmazonSimpleNotificationService snsClient)
        {
            _logger = logger;
            this.snsClient = snsClient;
        }

        public async  Task<IActionResult> Index()
        {
            var publishRequest = new PublishRequest
                {
                    Message = "Hello World!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!",
                    TopicArn = "arn:aws:sns:us-west-2:822491197222:Loyalty-Cdk-Topic",
                    MessageAttributes = new Dictionary<string, MessageAttributeValue>() 
                    { 
                        { "MessageType", new MessageAttributeValue { StringValue = "CreateCustomer" }}
                    }
                };

            var response = await snsClient.PublishAsync(publishRequest);

            var publishRequestFifo = new PublishRequest
                {
                    Message = "Hello World!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!",
                    TopicArn = "arn:aws:sns:us-west-2:000000000000:local_sns",
                    MessageAttributes = new Dictionary<string, MessageAttributeValue>() 
                    { 
                        { "MessageType", new MessageAttributeValue { StringValue = "AwardPoints" }}
                    }
                };

            var responseFifo = await snsClient.PublishAsync(publishRequestFifo);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
