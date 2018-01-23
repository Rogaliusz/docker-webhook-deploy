using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Docker.Webhook.Deploy.Settings;

namespace Docker.Webhook.Deploy.IoC.Modules
{
    public class SettingsModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(SettingsExtensions.GetSettings<CredentialsSettings>())
                .SingleInstance();
        }
    }
}
