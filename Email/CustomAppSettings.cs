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
