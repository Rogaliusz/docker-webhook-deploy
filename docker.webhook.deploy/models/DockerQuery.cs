using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace docker.webhook.deploy.models
{
    public class DockerQuery
    {
        [FromQuery]
        public string DockerName { get; set; }

        [FromQuery]
        public string DockerRepo { get; set; }

        [FromQuery] 
        public int FromPort { get; set; }

        [FromQuery]
        public int ToPort { get; set; }
    }
}
