using Microsoft.AspNetCore.Mvc;

namespace comm.api.Controllers
{
    [Route("api/[controller]")]
    public class CommController : ControllerBase
    {
        [HttpGet]
        [Route("GetProvince")]
        public string GetProvince()
        {
            return "湖南省";
        }
    }
}