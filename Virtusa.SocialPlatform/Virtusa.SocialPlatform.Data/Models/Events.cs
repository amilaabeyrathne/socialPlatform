using System;
using System.Collections.Generic;
using System.Text;

namespace Virtusa.SocialPlatform.Data.Models
{
    public class Events
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public byte[] BannerImage{ get; set; }
        public string BannerPath { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


    }
}
