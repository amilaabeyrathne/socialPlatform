using System;
using System.Collections.Generic;
using System.Text;

namespace Virtusa.SocialPlatform.Common.Utility
{
    public class EmailSettings
    {
        public String Domain { get; set; }

        public int Port { get; set; }

        public String UsernameEmail { get; set; }

        public String UsernamePassword { get; set; }

        public String FromEmail { get; set; }

        public List<String> ToEmails { get; set; }

        public String CcEmail { get; set; }
    }
}
