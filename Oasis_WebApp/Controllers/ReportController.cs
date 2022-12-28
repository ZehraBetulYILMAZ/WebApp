using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using static grpcWebClient.FileService;
using System.IO;
using System.Threading;
using System;
using System.Threading.Tasks;

namespace Oasis_WebApp.Controllers
{
    public class ReportController : Controller
    {
        public async Task<IActionResult> Report(string Staff,string Guest)
        {
            //using var channel = GrpcChannel.ForAddress("http://localhost:5116");
            //var client = new FileServiceClient(channel);


            //string downloadPath = @"D:\WebApp\Oasis_WebApp\DownloadFiles";

            //var fileInfo = new grpcWebClient.FileInfo
            //{
            //    FileExtension = ".pdf",
            //    FileNmae = "Otel_Otomasyon_Projesi"
            //};
            //FileStream fileStream = null;
            //try
            //{ 
            //    var request = client.FileDownload(fileInfo);
            //    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            //    int count = 0;
            //    decimal chunksize = 0;
            //    while (await request.ResponseStream.MoveNext(cancellationTokenSource.Token))
            //    {
            //        if (count++ == 0)
            //        {
            //            fileStream = new FileStream($@"{downloadPath}\{request.ResponseStream.Current.Info.FileNmae}{request.ResponseStream.Current.Info.FileExtension}", FileMode.CreateNew);
            //            fileStream.SetLength(request.ResponseStream.Current.FileSize);
            //        }

            //        var buffer = request.ResponseStream.Current.Buffer.ToByteArray();
            //        await fileStream.WriteAsync(buffer, 0, request.ResponseStream.Current.ReadedByte);
            //        Console.WriteLine($"{Math.Round(((chunksize += request.ResponseStream.Current.ReadedByte) * 100) / request.ResponseStream.Current.FileSize)} %");
            //    }
            //    Console.WriteLine("Yüklendi... ");
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}
            //await fileStream.DisposeAsync();
            //fileStream.Close();
            return View();
        }
    }
}
