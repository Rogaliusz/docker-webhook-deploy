using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Docker.Webhook.Deploy.Models
{
    public class DockerQuery
    {
        [FromQuery]
        public string DockerContainerName { get; set; }

        [FromQuery]
        public string DockerRepository { get; set; }
    }
}
