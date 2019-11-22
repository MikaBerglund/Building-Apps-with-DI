using Abstracts.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonServices
{
    public class GraphService
    {
        public GraphService(AzureAdApplicationSettings settings)
        {
            this.Settings = settings;
        }

        private AzureAdApplicationSettings Settings;
    }
}
