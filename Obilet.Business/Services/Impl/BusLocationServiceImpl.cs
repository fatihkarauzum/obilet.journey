using AutoMapper;
using Obilet.Business.Dtos.BusLocation;
using Obilet.Business.Mappers;
using Obilet.Common.Clients.Obilet;
using Obilet.Common.Clients.Obilet.Constants;
using Obilet.Common.Clients.Obilet.Dtos.BusLocation;
using Obilet.Common.Constants;
using Obilet.Common.Services;
using Obilet.Core.Attributes;
using System.Collections.Generic;

namespace Obilet.Business.Services.Impl
{
    public class BusLocationServiceImpl : BusLocationService {

        private readonly ObiletClient obiletClient;
		private readonly CookieService cookieService;
        private readonly IMapper mapper;

        public BusLocationServiceImpl(ObiletClient obiletClient, CookieService cookieService, IMapper mapper) {
            this.obiletClient = obiletClient; 
            this.cookieService = cookieService;
            this.mapper = mapper;
        }

        public async Task<List<GetBusLocationItem>> GetBusLocationsBySearchText(string? searchText = null)
        {
            GetBusLocationsReq getBusLocationsReq = new GetBusLocationsReq(searchText);
            getBusLocationsReq.DeviceSession.DeviceId = cookieService.GetCookie(CookieConstant.DEVICE);
			getBusLocationsReq.DeviceSession.SessionId = cookieService.GetCookie(CookieConstant.SESSION);

			GetBusLocationsResp locations = await obiletClient.PostAsync<GetBusLocationsReq, GetBusLocationsResp>(ObiletEndpoint.GET_BUS_LOCATIONS, getBusLocationsReq);

			List<GetBusLocationItem> locationItems = new List<GetBusLocationItem>();
            if (locations.isValid())
				locations.Data.ForEach(location => locationItems.Add(mapper.Map<GetBusLocationItem>(location)));

			return locationItems;
		}

		[Cacheable(Key = "ALL_LOCATIONS")]
		public async Task<List<GetBusLocationItem>> GetBusLocations() {
            return await this.GetBusLocationsBySearchText();
        }

	}
}
