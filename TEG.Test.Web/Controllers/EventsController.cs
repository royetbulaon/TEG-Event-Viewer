using Microsoft.AspNetCore.Mvc;
using TEG.Test.Web.Models;

namespace TEG.Test.Web.Controllers
{
	public class EventsController : Controller
	{
		private readonly IConfiguration _config;
		public EventsController(IConfiguration config)
		{
			_config = config;
		}
		public async Task<IActionResult> ByVenue(int id)
		{
			var vm = new EventsByVenueViewModel
			{
				VenueId = id
			};

			ViewBag.ApiBaseUrl = _config["ApiSettings:BaseUrl"];
			return View(vm);
		}
	}
}
