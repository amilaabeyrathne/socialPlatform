using System;

namespace Virtusa.SocialPlatform.Data.Models
{
    public class Competitions
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Type { get; set; }
        public string EventCode { get; set; }
        public string Description { get; set; }
        public int HeadCount { get; set; }
        public DateTime RegistrationEndDate { get; set; }

    }
}