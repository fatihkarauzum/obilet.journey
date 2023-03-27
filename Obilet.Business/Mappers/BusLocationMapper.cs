using AutoMapper;
using Obilet.Business.Dtos.BusLocation;
using Obilet.Common.Clients.Obilet.Dtos.BusLocation;

namespace Obilet.Business.Mappers {
	public class BusLocationMapper : Profile {

		public BusLocationMapper() {

			CreateMap<GetBusLocationItem, BusLocationsResponseData>();
			CreateMap<BusLocationsResponseData, GetBusLocationItem>();

		}

	}
}
