using System;
using System.Collections.Generic;
using System.Text;

namespace Virtusa.SocialPlatform.Common.Models
{
    public class SessionModel
    {
        public int Id { get; set; }
        public string SessionName { get; set; }
        public string Trainer { get; set; }
        public DateTime SessionDate { get; set; }
    }
}
