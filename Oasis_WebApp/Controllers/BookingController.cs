using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MySql.Data.MySqlClient.Memcached;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Oasis_WebApp.Models;
using Org.BouncyCastle.Asn1.Crmf;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using static TcDogrula.KPSPublicSoapClient;
using Result = Oasis_WebApp.Models.Result;

namespace Oasis_WebApp.Controllers
{
    public class BookingController : Controller
    {
        //private IReservationService _reservationService;
        private ReservationManager reservationManager = new ReservationManager();
        //public BookingController(IReservationService reservationService)
        //{
        //    _reservationService = reservationService;
        //}

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(BookingModel booking)
        {
            Result result = new Result();
            if (TcDogrulaMethod(booking) && EmailDogrula(booking.eMailAddress))
            {
                int reservationResult = 0;
                result = ApiRegister(booking);
                if (result.success)
                {
                    var reservation = new Reservation()
                    {
                        ArrivalDate = booking.ArrivalDate,
                        DepartureDate = booking.DepartureDate,
                        
                    }; 

                    reservationResult=  reservationManager.AddReservation(reservation);
                    if(reservationResult < 0 )
                    {

                        //REZERVASYON BAŞARISIZ

                        result.success = false;
                        result.message = "Rezervasyonunuz gerçekleşemedi.";
                    }
                }
                else
                {
                    result.success = false;
                    result.message = "Kayıt Başrısız";
                }
                }
                else
                {
                    result.success = false;
                    result.message = "Kişisel biligilerinizi yanlış girdiniz";
                }
                return View(result);
            }

            private bool EmailDogrula(string email)
            {
                EmailApi emailApi = new EmailApi();
            //try
            //{
            //    var client = new RestClient($"https://api.apilayer.com/email_verification/check?email={email}");
            //    var request = new RestRequest();
            //    request.AddHeader("apikey", "jI6AB8gimPPHmPVkB9yX7o81ofMdBotk");

            //    RestResponse response = client.Execute(request);
            //    Console.WriteLine(response.Content);
            //    emailApi = JsonConvert.DeserializeObject<EmailApi>(response.Content);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //    emailApi.is_deliverable = false;
            //}
            //return emailApi.free;
            return true;
            }
            private Result ApiRegister(BookingModel booking)
            {

                Result result = new Result();
                try
                {
                    var client = new RestClient("http://localhost:5000/api/register");
                    var payload = new JObject();
                    payload.Add("eMailAddress", booking.eMailAddress);
                    payload.Add("Password", booking.Password);
                    payload.Add("Name", booking.Name);
                    payload.Add("Surname", booking.Surname);
                    payload.Add("TcKimlikNo", booking.TcKimlikNo);
                    
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
                    return result;
                }

                return result;

            }
            private bool TcDogrulaMethod(BookingModel booking)
            {
                bool dogrulamaSonucu = false;
                try
                {
                    var mernisClient = new TcDogrula.KPSPublicSoapClient(EndpointConfiguration.KPSPublicSoap);
                    var tcKimlikDogrulamaServisResponse = mernisClient.TCKimlikNoDogrulaAsync(long.Parse(booking.TcKimlikNo), booking.Name, booking.Surname, booking.DateOfBirth.Year).GetAwaiter().GetResult();
                    dogrulamaSonucu = tcKimlikDogrulamaServisResponse.Body.TCKimlikNoDogrulaResult;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    dogrulamaSonucu = false;
                }
                return dogrulamaSonucu;
            }
        }
    }
