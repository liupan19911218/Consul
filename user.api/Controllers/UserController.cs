using Consul;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using user.api.Extensions;

namespace user.api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("get-url")]
        public string GetCommUrl()
        {
            AgentService agentService = ConsulClientExtenions.ChooseService("CommService");
            string url = $"http://{agentService.Address}:{agentService.Port}/api/Comm/GetProvince";
            return url;
        }
    }
}