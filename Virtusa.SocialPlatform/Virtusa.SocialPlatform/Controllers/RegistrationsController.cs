using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Virtusa.SocialPlatform.Business;
using Virtusa.SocialPlatform.Common.Interfaces;
using Virtusa.SocialPlatform.Common.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Virtusa.SocialPlatform.Controllers
{
    [Route("api/[controller]")]
    public class RegistrationsController : Controller
    {
        IRegistrationsBusiness regBusiness;
        public RegistrationsController(IRegistrationsBusiness registrationBusiness)
        {
            regBusiness = registrationBusiness;
        }
        //GET: api/registrations
        [HttpGet]
        public ActionResult Get()
        {
            return View();
        }

        [Route("getcompetitions/{isGroup}")]
        public async Task<IEnumerable<CompetitionModel>> GetCompetitions(bool isGroup)
        {
            try
            {
                return await regBusiness.GetCompetitionsAsync(isGroup);
            }
            catch (Exception exp)
            {
                throw;
            }
        }

        [Route("gettiers")]
        public async Task<IEnumerable<TiersModel>> GetTiers()
        {
            try
            {
                return await regBusiness.GetTiersAsync();
            }
            catch (Exception exp)
            {
                throw;
            }
        }

        [Route("getcegs")]
        public async Task<IEnumerable<CegsModel>> GetCegs()
        {
            try
            {
                return await regBusiness.GetCegsAsync();
            }
            catch (Exception exp)
            {
                throw;
            }
        }

        [Route("allregistrations/{isGroup}")]
        [HttpGet]
        public async Task<IEnumerable<RegistrationModel>> GetAllregistrations(bool isGroup)
        {
            try
            {
                return await regBusiness.GetAllRegistrationsAsync(isGroup);
            }
            catch (Exception exp)
            {
                throw;
            }
        }

        [Route("getteammember/{teamId}")]
        [HttpGet]
        public async Task<IEnumerable<ParticipentModel>> GetTeamMemberById(int teamId)
        {
            try
            {
                return await regBusiness.GetTeamMemberByIdAsync(teamId);
            }
            catch (Exception exp)
            {
                throw;
            }
        }

        // POST api/registrations
        [HttpPost]
        public int Post([FromBody]RegistrationModel registrationModel)
        {
            if (null != registrationModel)
            {
               var result = regBusiness.CreateRegistrations(registrationModel);
               return result;
            }
            else
            {
                return 0;
            }
            
        }

        // PUT api/registrations
        [HttpPut]
        public int Put([FromBody]RegistrationModel registrationModel)
        {
            if (null != registrationModel)
            {
                var result = regBusiness.EditRegistrations(registrationModel);
                return result;
            }
            else
            {
                return 0;
            }

        }

        // PUT api/registrations
        [Route("teamupdate")]
        [HttpPut]
        public int Put([FromBody]List<ParticipentModel> participentModel)
        {
            if (null != participentModel)
            {
                var result = regBusiness.EditTeamMembers(participentModel);
                return result;
            }
            else
            {
                return 0;
            }

        }

        // PUT api/registrations
        [Route("deleteregistration/{participantid}")]
        [HttpDelete]
        public int Delete(int participantId)
        {
            if (participantId != 0)
            {
                var result = regBusiness.DeleteRegistrations(participantId);
                return result;
            }
            else
            {
                return 0;
            }

        }


    }
}
