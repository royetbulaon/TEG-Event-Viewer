using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEG.Test.Domain.Models;

namespace TEG.Test.Application.Services
{
	public interface IEventService
	{
		Task<IEnumerable<Venue>> GetAllVenuesAsync();
		Task<Venue?> GetVenueByIdAsync(int venueId);
		Task<IEnumerable<Event>> GetEventsByVenueAsync(int venueId);
		Task<IEnumerable<Event>> GetEventsAsync();
		Task<Event?> GetEventDetailsAsync(int eventId);
	}
}
