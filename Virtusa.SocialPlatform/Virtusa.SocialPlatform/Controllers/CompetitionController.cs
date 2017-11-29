using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Virtusa.SocialPlatform.Common.Interfaces;
using Virtusa.SocialPlatform.Common.Models;
using Virtusa.SocialPlatform.Common;
using Microsoft.AspNetCore.Authorization;

namespace Virtusa.SocialPlatform.Controllers
{
    //[Produces("application/json")]
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    public class CompetitionController : Controller
    {
        ICompetitionBusiness competitionBusiness;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="competition"></param>
        public CompetitionController(ICompetitionBusiness competition)
        {
            competitionBusiness = competition;
        }

        /// <summary>
        /// Get All competition
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<CompetitionModel> Get()
        {
            List< CompetitionModel > list = competitionBusiness.GetAll();

            return list; 
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]CompetitionModel competitionToAdd)
        {
            string message = competitionBusiness.Save(competitionToAdd);
        }

        [HttpDelete("{id}")]
        public int Delete(long id)
        {
            string message = competitionBusiness.Delete(id);
            int resultCode = 0;

            if (message == CommonResource.ResourceManager.GetString("SuccessMessage"))
            {
                return resultCode =1;
            }

            return resultCode;
        }

        public int Put([FromBody]CompetitionModel model)
        {
            string message = competitionBusiness.Update(model);

            int resultCode = 0;

            if (message == CommonResource.ResourceManager.GetString("SuccessMessage"))
            {
                return resultCode = 1;
            }

            return resultCode;
        }

    }
}