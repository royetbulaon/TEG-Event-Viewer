using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEG.Test.Domain.Interface;
using TEG.Test.Domain.Models;

namespace TEG.Test.Application.Services
{
	public class EventService : IEventService
	{
		private readonly IEventRepository _eventRepository;

		public EventService(IEventRepository eventRepository)
		{
			_eventRepository = eventRepository;
		}

		public async Task<IEnumerable<Venue>> GetAllVenuesAsync()
		{
			var data = await _eventRepository.GetEventsAndVenuesAsync();
			return data?.Venues ?? Enumerable.Empty<Venue>();
		}

		public async Task<Venue?> GetVenueByIdAsync(int venueId)
		{
			var data = await _eventRepository.GetEventsAndVenuesAsync();
			if (data == null) return null;

			return data.Venues.FirstOrDefault(v => v.Id == venueId);
		}

		public async Task<IEnumerable<Event>> GetEventsByVenueAsync(int venueId)
		{
			var data = await _eventRepository.GetEventsAndVenuesAsync();
			if (data == null) return Enumerable.Empty<Event>();
			var events = data.Events.Where(e => e.VenueId == venueId).ToList();

			// Hydrate with venue navigation property
			foreach (var ev in events)
			{
				ev.Venue = data.Venues.FirstOrDefault(v => v.Id == ev.VenueId);
			}

			return events;
		}
		public async Task<IEnumerable<Event>> GetEventsAsync()
		{
			var data = await _eventRepository.GetEventsAndVenuesAsync();
			if (data == null) return Enumerable.Empty<Event>();

			// Filter events
			var events = data.Events.ToList();

			// Hydrate with venue navigation property
			foreach (var ev in events)
			{
				ev.Venue = data.Venues.FirstOrDefault(v => v.Id == ev.VenueId);
			}

			return events;
		}

		public async Task<Event?> GetEventDetailsAsync(int eventId)
		{
			var data = await _eventRepository.GetEventsAndVenuesAsync();
			if (data == null) return null;

			var ev = data.Events.FirstOrDefault(e => e.Id == eventId);

			if (ev != null)
			{
				ev.Venue = data.Venues.FirstOrDefault(v => v.Id == ev.VenueId);
			}

			return ev;
		}
	}
}
