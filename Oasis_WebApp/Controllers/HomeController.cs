using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Oasis_WebApp.Models;
using Org.BouncyCastle.Crypto.Agreement.Srp;
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
        public async Task<IActionResult> ProtoBUF()
        {
            using var channel = GrpcChannel.ForAddress("http://localhost:5116");
            var client = new FileServiceClient(channel);


            string downloadPath = @"D:\WebApp\Oasis_WebApp\DownloadFiles";

            var fileInfo = new grpcWebClient.FileInfo
            {
                FileExtension = ".pdf",
                FileNmae = "Otel_Otomasyon_Projesi"
            };

            FileStream fileStream = null;

            var request = client.FileDownload(fileInfo);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            int count = 0;
            decimal chunksize = 0;
            while (await request.ResponseStream.MoveNext(cancellationTokenSource.Token))
            {
                if (count++ == 0)
                {
                    fileStream = new FileStream($@"{downloadPath}\{request.ResponseStream.Current.Info.FileNmae}{request.ResponseStream.Current.Info.FileExtension}", FileMode.CreateNew);
                    fileStream.SetLength(request.ResponseStream.Current.FileSize);
                }

                var buffer = request.ResponseStream.Current.Buffer.ToByteArray();
                await fileStream.WriteAsync(buffer, 0, request.ResponseStream.Current.ReadedByte);
                Console.WriteLine($"{Math.Round(((chunksize += request.ResponseStream.Current.ReadedByte) * 100) / request.ResponseStream.Current.FileSize)} %");
            }
            Console.WriteLine("Yüklendi... ");
            await fileStream.DisposeAsync();
            fileStream.Close();
            return View();
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
