using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using System.Threading.Tasks;
using WebApp.ThirdPartyAPI;

namespace WebApp.Controllers {

    [ApiController]
    [Route("brew-coffee")]
    public class BrewsController : ControllerBase {
        public BrewCoffee data;
        public IWeatherAPI weather;
        public BrewsController(IWeatherAPI wea)
        {
            data = new BrewCoffee();
            weather = wea;
        }
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetCoffee() 
        {
            if (data.PreparedDate.Day == 1 && data.PreparedDate.Month == 4)
                return StatusCode(418);
            else if (BrewCoffee.CountedTime < 5)
            {
                data.LocalTemp = await weather.GetTemperature();
                if (data.LocalTemp>30)
                    data.Message = "Your refreshing iced coffee is ready";
                return Ok(data);
            }
            else
                return StatusCode(503);
        }
    }
}
