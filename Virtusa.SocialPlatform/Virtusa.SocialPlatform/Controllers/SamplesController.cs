using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Virtusa.SocialPlatform.Common.Interfaces;

namespace Virtusa.SocialPlatform.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]")]
    public class SamplesController : Controller
    {
        ISampleBusiness sampleBusiness;
        public SamplesController(ISampleBusiness sampleBusiness)
        {
            this.sampleBusiness = sampleBusiness;
        }

        [Route("{id}")]
        public string GetSample(int id)
        {
            return sampleBusiness.GetSample(id);
        }
    }
}