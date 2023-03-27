using Obilet.Business.Dtos.BusLocation;

namespace Obilet.Business.Services {
	public interface BusLocationService {

		Task<List<GetBusLocationItem>> GetBusLocationsBySearchText(string? searchText = null);

		Task<List<GetBusLocationItem>> GetBusLocations();

	}
}
