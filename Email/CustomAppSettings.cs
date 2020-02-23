using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vueproject.Email
{
    public class CustomAppSettings
    {
        public CustomAppSettings()
        {
            //edit values in appsettings.json

            SENDGRID_API_KEY = "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";

        }

        public string SENDGRID_API_KEY { get; set; }
    }
}
