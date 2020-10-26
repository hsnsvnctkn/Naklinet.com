using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Naklinet.Repository;
using Naklinet.Repository.Contracts;

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
    }
}
