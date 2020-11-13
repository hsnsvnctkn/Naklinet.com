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

namespace Naklinet.UI.Controllers
{
    public class Transport : Controller
    {
        private readonly IGetOfferRepository _getOfferRepository;

        public Transport(IGetOfferRepository getOfferRepository)
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
                    var url = string.Format("https://geocode-maps.yandex.ru/1.x/?apikey=0c0b1bea-d7b8-46b9-aec1-0bb9ca47e7f0&geocode={0}&results=5&kind=district&lang=tr-TR&format=json", valueKey);
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
        //public JsonResult GetPrice(TransportInfo trInfo)
        //{

        //}
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
