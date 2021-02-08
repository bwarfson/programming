using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime.Internal;
using Amazon.SecurityToken;
using Amazon.SecurityToken.Model;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using securesns.Models;

namespace securesns.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAmazonSecurityTokenService _securityTokenServiceClient;

        public HomeController(ILogger<HomeController> logger, IAmazonSecurityTokenService securityTokenServiceClient)
        {
            _logger = logger;
            _securityTokenServiceClient = securityTokenServiceClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> Create()
        {
            try
            {
                var response = await _securityTokenServiceClient.AssumeRoleAsync(new AssumeRoleRequest
                {
                    DurationSeconds = 3600,
                    RoleArn = "arn:aws:iam::822491197222:role/snspublishrole",
                    RoleSessionName = "testAssumeRoleSession",
                });

                AssumedRoleUser assumedRoleUser = response.AssumedRoleUser;
                Credentials credentials = response.Credentials;

                var snsClient = new AmazonSimpleNotificationServiceClient(credentials, RegionEndpoint.USWest2);

                var publishResponse = await snsClient.PublishAsync(new PublishRequest
                {
                    Subject = "Coding Test Results for " +
                    DateTime.Today.ToShortDateString(),
                    Message = "All of today's coding tests passed.",
                    TopicArn = "arn:aws:sns:us-west-2:822491197222:snssecuretopic"
                });

                return Json(publishResponse);
            }  
            catch (HttpErrorResponseException ex) 
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return Json(false);
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
