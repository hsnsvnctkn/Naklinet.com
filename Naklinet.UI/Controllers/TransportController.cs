using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Naklinet.Repository;
using Naklinet.Repository.Contracts;
using Naklinet.Repository.Dto;
using Newtonsoft.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Naklinet.UI.Controllers
{
    public class TransportController : Controller
    {
        private readonly IGetOfferRepository _getOfferRepository;

        public TransportController(IGetOfferRepository getOfferRepository)
        {
            _getOfferRepository = getOfferRepository;
        }
        public IActionResult Index()
        {
            var getOffer = _getOfferRepository.GetOfferDto();
            return View(getOffer);
        }
        [HttpPost]
        public JsonResult AutoCompleteAddress(string valueKey)
        {
            if (valueKey != null)
                if (valueKey.Length > 2)
                {
                    var url = string.Format("https://geocode-maps.yandex.ru/1.x/?apikey=0c0b1bea-d7b8-46b9-aec1-0bb9ca47e7f0&geocode={0}&rspn=1&ll=38.965509,35.813004&spn=30,30&results=5&kind=district&lang=tr-TR&format=json", valueKey);
                    //List<string> districts = new List<string>();

                    //XmlTextReader xmlTextReader = new XmlTextReader(url);

                    //while (xmlTextReader.Read())
                    //{
                    //    if (xmlTextReader.NodeType == XmlNodeType.Element)
                    //        if (xmlTextReader.Name == "text")
                    //        {
                    //            xmlTextReader.Read();
                    //            districts.Add(xmlTextReader.Value.ToString());
                    //        }
                    //}

                    //var json = JsonConvert.SerializeObject(districts);
                    //var jss = json;

                    var json = _download_serialized_json_data<Rootobject>(url);

                    var addresses = json.response.GeoObjectCollection.featureMember;

                    return Json(new { districts = addresses });
                }
            return Json(new { districts = "null" });
        }
        [HttpPost]
        public JsonResult GetPrice(TransportInfo transportInfo)
        {
            try
            {
                int offerID;

                var phone = HttpContext.Session.GetString("SessionCustomerPhone");

                if (phone == "")
                    return Json(new { status = false, msg="Lütfen Sayfayı yenileyerek tekrar deneyiniz.." });

                transportInfo.CustomerPhone = phone;

                if (transportInfo.FromRoomCountID == null || transportInfo.FromFloor == null || transportInfo.ToFloor == null)
                {
                    offerID = _getOfferRepository.CreateOffer(transportInfo, null);
                    return Json(new { offerID, status = true, price = "Size özel teklif için sizi arıyacağız.." });
                }

                var price = _getOfferRepository.GetPrice(transportInfo);
                offerID = _getOfferRepository.CreateOffer(transportInfo, price);

                return Json(new { offerID, status = true, price = (price + " ₺") });
            }
            catch (Exception e)
            {
                return Json(new { status = false, msg = e });
            }
        }

        [HttpPost]
        public JsonResult CreateCustomer(string customerNo)
        {
            try
            {
                if (customerNo == null || !IsValidNumber(customerNo))
                    return Json(new { status = false, msg = "Geçerli bir numara giriniz.." });

                var trimmedPhoneNo = TrimPhoneNo(customerNo);

                if (_getOfferRepository.IsThereCustomer(trimmedPhoneNo))
                {
                    SetSessionPhoneNo(trimmedPhoneNo);
                    return Json(new { status = true });
                }
                else
                {
                    CreateCustomerWithNo(trimmedPhoneNo);
                    SetSessionPhoneNo(trimmedPhoneNo);
                    return Json(new { status = true });
                }
            }
            catch (Exception e)
            {
                return Json(new { status = false, msg = e });
            }
        }

        public void UpdateCustomerLeftStep(int? step)
        {
            try
            {
                if (step != null)
                {
                    var phone = HttpContext.Session.GetString("SessionCustomerPhone");
                    if (phone != null)
                        _getOfferRepository.UpdateLeftStep((int)step, phone);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JsonResult CreateReservation(TransportInfo transportInfo)
        {
            try
            {
                //_getOfferRepository.CreateReservation(transportInfo);
                return Json(new { status = true });
            }
            catch (Exception e)
            {
                return Json(new { status = false, msg = e });
            }
        }


        //Prive Functions
        private void CreateCustomerWithNo(string trimmedPhoneNo)
        {
            _getOfferRepository.CreateCustomerWithNo(trimmedPhoneNo);
        }

        private void SetSessionPhoneNo(string phone)
        {
            try
            {
                HttpContext.Session.SetString("SessionCustomerPhone", phone);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string TrimPhoneNo(string number)
        {
            number = number.Trim().Replace(" ", string.Empty);
            var temp = number.Substring(1, 3);
            number = number.Substring(5, (number.Length - 5));
            number = number.Replace("-", string.Empty);
            return temp + number;
        }
        private bool IsValidNumber(string number)
        {
            try
            {
                if (number.Contains("_"))
                    return false;
                number = TrimPhoneNo(number);
                if (number.Length == 10)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private T _download_serialized_json_data<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }

    }
}
