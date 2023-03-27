using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Obilet.Business.Dtos.BusLocation;
using Obilet.Business.Dtos.Journey;
using Obilet.Business.Services;
using Obilet.Common.Utils;
using Obilet.Core.Attributes;
using Obilet.Journey.Models.ParameterModels;
using Obilet.Journey.Models.ViewModels;
using System.Data;

namespace obilet.journey.Controllers
{

    [ServiceFilter(typeof(SessionAttribute))]
    public class HomeController : Controller {

        private readonly BusLocationService busLocationService;
        private readonly JourneyService journeyService;
        private readonly IMapper mapper;

        public HomeController(BusLocationService busLocationService, JourneyService journeyService, IMapper mapper) {

            this.busLocationService = busLocationService;
            this.journeyService = journeyService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index() {

            await busLocationService.GetBusLocations();
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> SearchBusLocations(string searchText) {

            List<GetBusLocationItem> busLocationItems = new List<GetBusLocationItem>();
            List<SelectListItem> sectionList = new List<SelectListItem>();

            if (StringUtil.IsNullOrEmpty(searchText)) {
                busLocationItems = await busLocationService.GetBusLocations();

                sectionList = busLocationItems.Take(10)
                    .Select(mapper.Map<SelectListItem>).ToList();

                return Json(sectionList);
            }

            busLocationItems = await busLocationService.GetBusLocationsBySearchText(searchText);

            sectionList = busLocationItems
                            .Select(mapper.Map<SelectListItem>).ToList();

            return Json(sectionList);
        }

        public async Task<IActionResult> SearchJourneys(SearchJourneyParamModel paramModel) {

            List<GetJourneyItem> journeyItems = 
                await journeyService.GetJourneys(
                    paramModel.OriginId, 
                    paramModel.DestinationId, 
                    paramModel.DepartureDate
                );

            JourneysViewModel journeysViewModel = new JourneysViewModel() {
                Journeys = journeyItems,
                OriginName = paramModel.OriginName,
                DestinationName = paramModel.DestinationName,
                DepartureDate = paramModel.DepartureDate
            };

            return View(journeysViewModel);
        }

    }
}