﻿using System;
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
