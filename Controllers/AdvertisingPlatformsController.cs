using Microsoft.AspNetCore.Mvc;
using TestTask.Services;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdvertisingPlatformsController : ControllerBase
    {
        private readonly IAdvertisingPlatformsServices _advertisingPlatformsServices;

        public AdvertisingPlatformsController(IAdvertisingPlatformsServices advertisingPlatformsServices)
        {
            _advertisingPlatformsServices = advertisingPlatformsServices;
        }

        [HttpGet("download")]
        public ActionResult<Dictionary<string, List<string>>> Download()
        {
            return _advertisingPlatformsServices.Download();
        }

        [HttpGet("search")]
        public ActionResult<Dictionary<string, List<string>>>  Search(string input)
        {
            return _advertisingPlatformsServices.searchPlatforms(input);
        }
    }
}
