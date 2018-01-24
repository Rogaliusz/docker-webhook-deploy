using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Docker.Webhook.Deploy.Models
{
    public class DockerQuery
    {
        [FromQuery]
        public string DockerContainerName
        {
            get => _dockerContainerName;
            set => _dockerContainerName = Base64UrlEncoder.Decode(value);
        }

        [FromQuery]
        public string DockerRepository
        {
            get => _dockerRepository;
            set => _dockerRepository = Base64UrlEncoder.Decode(value);

        }

        private string _dockerContainerName;

        private string _dockerRepository;
    }
}
