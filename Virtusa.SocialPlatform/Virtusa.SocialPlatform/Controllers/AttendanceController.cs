using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Virtusa.SocialPlatform.Business;
using Virtusa.SocialPlatform.Common.Interfaces;
using Virtusa.SocialPlatform.Common.Models;

namespace Virtusa.SocialPlatform.Controllers
{
    [Route("api/[controller]")]
    public class AttendanceController : Controller
    {
        IAttendanceBusiness attendBusiness;
        public AttendanceController(IAttendanceBusiness attendanceBusiness)
        {
            attendBusiness = attendanceBusiness;
        }
        // GET: api/Attendance
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("getcompetitions")]
        public async Task<IEnumerable<CompetitionModel>> GetCompetitions()
        {
            try
            {
                return await attendBusiness.GetCompetitionsAsync();
            }
            catch (Exception exp)
            {
                throw;
            }
        }

        [Route("getsessions")]
        public async Task<IEnumerable<SessionModel>> GetSessions()
        {
            try
            {
                return await attendBusiness.GetSessionAsync();
            }
            catch (Exception exp)
            {
                throw;
            }
        }
        [Route("allattendances/{isGroup}")]
        [HttpGet]
        public async Task<IEnumerable<AttendanceModel>> GetAllAttendancesAsync(int? sessionId, int? competitionId)
        {
            try
            {
                return await attendBusiness.GetAllAttendancesAsync(sessionId, competitionId);
            }
            catch (Exception exp)
            {
                throw;
            }
        }

        // POST api/Attendance
        [HttpPost]
        public int Post([FromBody]AttendanceModel attendanceModel)
        {
            if (null != attendanceModel)
            {
                var result = attendBusiness.CreateAttendances(attendanceModel);
                return result;
            }
            else
            {
                return 0;
            }

        }

        // PUT api/Attendance
        [Route("deleteattendance/{participantid}")]
        [HttpDelete]
        public int Delete(int? sessionId, int? competitionId, int empId)
        {
            if (empId != 0)
            {
                var result = attendBusiness.DeleteAttendances(sessionId, competitionId, empId);
                return result;
            }
            else
            {
                return 0;
            }

        }

        //// GET: api/Attendance/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Attendance
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Attendance/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
