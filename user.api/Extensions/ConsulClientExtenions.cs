using Consul;
using System;
using System.Linq;

namespace user.api.Extensions
{
    public class ConsulClientExtenions
    {
        public static AgentService ChooseService(string serviceName)
        {
            using (ConsulClient client = new ConsulClient(c => c.Address = new Uri("http://localhost:8500")))
            {
                var services = client.Agent.Services().Result.Response;
                // 找出目标服务
                var targetServices = services.Where(c => c.Value.Service.Equals(serviceName)).Select(s => s.Value);
                // 实现随机负载均衡
                var targetService = targetServices.ElementAt(new Random().Next(1, 1000) % targetServices.Count());
                Console.WriteLine($"{DateTime.Now} 当前调用服务为：{targetService.Address}:{targetService.Port}");

                return targetService;
            }
        }
    }
}