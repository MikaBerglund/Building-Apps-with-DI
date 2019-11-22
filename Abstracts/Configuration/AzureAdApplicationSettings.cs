using System;
using System.Collections.Generic;
using System.Text;

namespace Abstracts.Configuration
{
    public class AzureAdApplicationSettings
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string TenantId { get; set; }
    }
}
