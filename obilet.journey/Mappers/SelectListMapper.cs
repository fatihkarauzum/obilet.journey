using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Obilet.Business.Dtos.BusLocation;
using Obilet.Business.Dtos.Journey;
using Obilet.Common.Clients.Obilet.Dtos.Journey;

namespace Obilet.Journey.Mappers {
    public class SelectListMapper : Profile {

        public SelectListMapper() {

            CreateMap<GetBusLocationItem, SelectListItem>()
                .ForMember(dest =>
                    dest.Text,
                    opt => opt.MapFrom(src => src.LongName))
                .ForMember(dest =>
                    dest.Value,
                    opt => opt.MapFrom(src => src.Id.ToString()));

        }

    }
}
