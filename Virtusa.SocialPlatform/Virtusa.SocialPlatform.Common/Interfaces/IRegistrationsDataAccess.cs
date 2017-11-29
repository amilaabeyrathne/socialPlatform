using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Virtusa.SocialPlatform.Common.Models;

namespace Virtusa.SocialPlatform.Common.Interfaces
{
    public interface IRegistrationsDataAccess
    {
        RegistrationModel GetRegistrationById(long empId);
        int CreateRegistrations(RegistrationModel registrationModel);
        Task<IEnumerable<CompetitionModel>> GetCompetitionsAsync(bool isGroup);
        Task<IEnumerable<TiersModel>> GetTiersAsync();
        Task<IEnumerable<CegsModel>> GetCegsAsync();
        Task<IEnumerable<RegistrationModel>> GetAllRegistrationsAsync(bool isGroup);
        int EditRegistrations(RegistrationModel registrationModel);
        int DeleteRegistrations(int participantId);
        Task<IEnumerable<ParticipentModel>> GetTeamMemberByIdAsync(int teamId);
        int EditTeamMembers(List<ParticipentModel> participentModel);
    }
}
