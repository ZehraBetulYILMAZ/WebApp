using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Oasis_WebApp.Models;
using Org.BouncyCastle.Crypto.Agreement.Srp;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static grpcWebClient.FileService;

namespace Oasis_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }
    
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string eMailAddress, string Password)
        {
            Result result = new Result();
            try
            {
                var client = new RestClient("http://localhost:5000/api/login");
                var payload = new JObject();
                payload.Add("eMailAddress",eMailAddress);
                payload.Add("Password", Password);

                var request = new RestRequest();
                request.AddStringBody(payload.ToString(), DataFormat.Json);

                var obj = client.PostAsync(request).Result;
                Console.WriteLine(obj.Content);
                result = JsonConvert.DeserializeObject<Result>(obj.Content);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                result.message = "kayıt başarısız";
                result.success = false;
               
            }
            return View(result);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
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
