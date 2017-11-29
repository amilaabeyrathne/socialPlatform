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
    public class SessionsController : Controller
    {
        ISessionBusiness business;
        public SessionsController(ISessionBusiness bus)
        {
            business = bus;
        }

        [Route("{id}")]
        public async Task<SessionModel> GetSession(int id)
        {
            try
            {
                return await business.GetSession(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //// GET: api/values
        [HttpGet]
        public async Task<IEnumerable<SessionModel>> Get()
        {
            try
            {
                return await business.GetAllSession();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
        // POST: api/Session
        [HttpPost]
        public int Post([FromBody]SessionModel sessionModel)
        {
            if (null != sessionModel)
            {
                var result = business.AddSession(sessionModel);
                return result;
            }
            else
            {
                return 0;
            }
        }

        // PUT api/Session
        [HttpPut]
        public int Put([FromBody]SessionModel sessionModel)
        {
            if (null != sessionModel)
            {
                var result = business.EditSession(sessionModel);
                return result;
            }
            else
            {
                return 0;
            }

        }

        // PUT api/Session
        [Route("deletesession/{id}")]
        [HttpDelete]
        public int Delete(int id)
        {
            if (id != 0)
            {
                var result = business.DeleteSession(id);
                return result;
            }
            else
            {
                return 0;
            }

        }
    }
}
