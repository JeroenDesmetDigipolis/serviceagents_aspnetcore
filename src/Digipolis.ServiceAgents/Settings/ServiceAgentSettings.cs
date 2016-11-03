﻿using System;
using System.Collections.Generic;

namespace Digipolis.ServiceAgents.Settings
{
    public class ServiceAgentSettings
    {
        public ServiceAgentSettings()
        {
            Services = new Dictionary<string, ServiceSettings>();
        }

        public IDictionary<string, ServiceSettings> Services { get; private set; }
    }
}
