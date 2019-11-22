using System;
using System.Collections.Generic;
using System.Text;

namespace Abstracts.Configuration
{
    public class OpenIdSettings
    {

        public string Authority { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string Scopes { get; set; }

    }
}
