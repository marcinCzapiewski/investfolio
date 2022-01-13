using Microsoft.AspNetCore.Mvc;

namespace Investfolio.Modules.Quotes.Api.Controllers
{
    [Route("quotes")]
    internal class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get() => "quotes";
    }
}
