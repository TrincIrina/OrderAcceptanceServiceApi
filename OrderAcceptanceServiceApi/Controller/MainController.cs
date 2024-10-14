using Microsoft.AspNetCore.Mvc;

namespace OrderAcceptanceServiceApi.Controller
{
    [Route("api")]
    [ApiController]
    public class MainController : ControllerBase
    {
        [HttpGet]
        public object Index()
        {
            return new { Message = "server is running" };
        }

        [HttpGet("ping")]
        public object Ping()
        {
            return new { Message = "pong" };
        }
    }
}
