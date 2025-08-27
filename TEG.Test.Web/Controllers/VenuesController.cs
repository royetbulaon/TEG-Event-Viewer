using Microsoft.AspNetCore.Mvc;

namespace TEG.Test.Web.Controllers
{
	public class VenuesController : Controller
	{
		private readonly IConfiguration _config;
		public VenuesController(IConfiguration config)
		{
			_config = config;
		}
		public IActionResult Index()
		{
			ViewBag.ApiBaseUrl = _config["ApiSettings:BaseUrl"];
			return View();
		}
	}
}
