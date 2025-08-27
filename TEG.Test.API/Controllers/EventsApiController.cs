using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TEG.Test.Application.Services;
using TEG.Test.Domain.Models;

namespace TEG.Test.API.Controllers
{
	[Route("api/events")]
	[ApiController]
	public class EventsApiController : ControllerBase
	{
		private readonly IEventService _eventService;

		public EventsApiController(IEventService eventService)
		{
			_eventService = eventService;
		}

		// GET: api/events
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
		{
			var data = await _eventService.GetEventsAsync();
			if (data == null || !data.Any()) return NotFound();
			return Ok(data);
		}

		// GET: api/events/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Event>> GetEvent(int id)
		{
			var ev = await _eventService.GetEventDetailsAsync(id);
			if (ev == null) return NotFound();
			return Ok(ev);
		}

		// GET: api/venues/5/events
		[HttpGet("~/api/venues/{venueId}/events")]
		public async Task<ActionResult<IEnumerable<Event>>> GetEventsByVenue(int venueId)
		{
			var events = await _eventService.GetEventsByVenueAsync(venueId);

			if (events == null || !events.Any())
				return NotFound();

			return Ok(events);

		}
	}
}
