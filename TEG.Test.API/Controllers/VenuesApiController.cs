using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TEG.Test.Application.Services;
using TEG.Test.Domain.Models;

namespace TEG.Test.API.Controllers
{
	[Route("api/venues")]
	[ApiController]
	public class VenuesApiController : ControllerBase
	{
		private readonly IEventService _eventService;

		public VenuesApiController(IEventService eventService)
		{
			_eventService = eventService;
		}

		// GET: api/venues
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Venue>>> GetVenues()
		{
			var venues = await _eventService.GetAllVenuesAsync();
			if (venues == null || !venues.Any()) return NotFound();
			return Ok(venues);
		}

		// GET: api/venues/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Venue>> GetVenue(int id)
		{
			var venue = await _eventService.GetVenueByIdAsync(id);
			if (venue == null) return NotFound();
			return Ok(venue);
		}
	}
}
