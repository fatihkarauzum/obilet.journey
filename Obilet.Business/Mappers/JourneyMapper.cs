using AutoMapper;
using Obilet.Business.Dtos.Journey;
using Obilet.Common.Clients.Obilet.Dtos.Journey;

namespace Obilet.Business.Mappers {
	public class JourneyMapper : Profile {

		public JourneyMapper() {

			CreateMap<GetJourneyItem, JourneyResponseData>()
				.ForMember(dest =>
					dest.Journey,
					opt => opt.MapFrom(src => src.JourneyDetail));

			CreateMap<JourneyResponseData, GetJourneyItem>()
				.ForMember(dest =>
					dest.JourneyDetail,
					opt => opt.MapFrom(src => src.Journey)); ;

			CreateMap<JourneyDetail, JourneyData>();
			CreateMap<JourneyData, JourneyDetail>();

		}

	}
}
