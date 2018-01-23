using Autofac;
using docker.webhook.deploy.ioc.modules;
using Microsoft.Extensions.Configuration;

namespace Docker.Webhook.Deploy.IoC
{
    public class ContainerModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<ServiceModule>();

        }
    }
}
