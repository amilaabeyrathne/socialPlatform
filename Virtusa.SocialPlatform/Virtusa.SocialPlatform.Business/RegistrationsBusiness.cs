using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Virtusa.SocialPlatform.Common.Interfaces;
using Virtusa.SocialPlatform.Common.Models;

namespace Virtusa.SocialPlatform.Business
{
    public class RegistrationsBusiness : IRegistrationsBusiness
    {
        IRegistrationsDataAccess registrationdata;
        public RegistrationsBusiness(IRegistrationsDataAccess dataAccess)
        {
            registrationdata = dataAccess;
        }

        public int CreateRegistrations(RegistrationModel registrationModel)
        {
            return registrationdata.CreateRegistrations(registrationModel);
        }

        public async Task<IEnumerable<TiersModel>> GetTiersAsync()
        {
            return await registrationdata.GetTiersAsync();
        }

        public async Task<IEnumerable<CompetitionModel>> GetCompetitionsAsync(bool isGroup)
        {
            return await registrationdata.GetCompetitionsAsync(isGroup);
        }

        public async Task<IEnumerable<CegsModel>> GetCegsAsync()
        {
            return await registrationdata.GetCegsAsync();
        }

        public RegistrationModel GetRegistrationById(long empId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RegistrationModel>> GetAllRegistrationsAsync(bool isGroup)
        {
            return await registrationdata.GetAllRegistrationsAsync(isGroup);
        }

        public int EditRegistrations(RegistrationModel registrationModel)
        {
            return registrationdata.EditRegistrations(registrationModel);
        }

        public int DeleteRegistrations(int participantId)
        {
            return registrationdata.DeleteRegistrations(participantId);
        }

        public Task<IEnumerable<ParticipentModel>> GetTeamMemberByIdAsync(int teamId)
        {
            return registrationdata.GetTeamMemberByIdAsync(teamId);
        }

        public int EditTeamMembers(List<ParticipentModel> participentModel)
        {
            return registrationdata.EditTeamMembers(participentModel);
        }
    }
}
