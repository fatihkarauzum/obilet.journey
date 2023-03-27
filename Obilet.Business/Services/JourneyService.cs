using Obilet.Business.Dtos.Journey;

namespace Obilet.Business.Services {
	public interface JourneyService {

		Task<List<GetJourneyItem>> GetJourneys(long originId, long destinationId, DateTime? departureDate = null);

	}
}
