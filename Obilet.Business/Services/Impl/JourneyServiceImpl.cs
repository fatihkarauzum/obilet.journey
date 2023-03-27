using AutoMapper;
using Obilet.Business.Dtos.BusLocation;
using Obilet.Business.Dtos.Journey;
using Obilet.Business.Dtos.Session;
using Obilet.Common.Clients.Obilet;
using Obilet.Common.Clients.Obilet.Constants;
using Obilet.Common.Clients.Obilet.Dtos.BusLocation;
using Obilet.Common.Clients.Obilet.Dtos.Journey;
using Obilet.Common.Constants;
using Obilet.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Business.Services.Impl {

	public class JourneyServiceImpl : JourneyService {

		private readonly ObiletClient obiletClient;
		private readonly CookieService cookieService;
		private readonly IMapper mapper;

		public JourneyServiceImpl(ObiletClient obiletClient, CookieService cookieService, IMapper mapper) {
			this.obiletClient = obiletClient;
			this.cookieService = cookieService;
			this.mapper = mapper;
		}

		public async Task<List<GetJourneyItem>> GetJourneys(long originId, long destinationId, DateTime? departureDate = null) {

			GetJourneysReq getJourneysReq =
				new GetJourneysReq(
					new JourneysRequestData(originId, destinationId, departureDate ?? DateTime.Now)
				);

			getJourneysReq.DeviceSession.DeviceId = cookieService.GetCookie(CookieConstant.DEVICE);
			getJourneysReq.DeviceSession.SessionId = cookieService.GetCookie(CookieConstant.SESSION);

			GetJourneysResp journeys = await obiletClient.PostAsync<GetJourneysReq, GetJourneysResp>(ObiletEndpoint.GET_BUS_JOURNEY, getJourneysReq);

			List<GetJourneyItem> journeyItems = new List<GetJourneyItem>();
			if (journeys.isValid())
				journeys.Data.ForEach(journey => journeyItems.Add(mapper.Map<GetJourneyItem>(journey)));

			return journeyItems;
		}

	}

}
