using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Virtusa.SocialPlatform.Common.Interfaces;
using Virtusa.SocialPlatform.Common.Models;
using Virtusa.SocialPlatform.Data.Models;
using System.Threading.Tasks;
using System.Linq;

namespace Virtusa.SocialPlatform.Data
{
    public class RegistrationsDataAccess : IRegistrationsDataAccess
    {
        #region private variables
        private SampleContext context;
        #endregion

        #region constructors
        public RegistrationsDataAccess(SampleContext dbcontext)
        {
            context = dbcontext;
        }
        #endregion

        #region public methods
        public int CreateRegistrations(RegistrationModel registrationModel)
        {

            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    if (registrationModel.IsGroup)
                    {
                        var team = new Teams()
                        {
                            TeamName = registrationModel.TeamName
                        };
                        context.Teams.Add(team);
                        context.SaveChanges();
                        var teamId = team.Id;
                        int result = InsertParticipantandMembership(teamId, registrationModel);

                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        return 1;
                    }
                    else
                    {
                        var participent = (PopulateParticipantDBObject(registrationModel));
                        context.Participants.Add(participent);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        return 1;

                    }

                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return 0;
                }
            }
        }

        public int EditRegistrations(RegistrationModel registrationModel)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    if (!registrationModel.IsGroup)
                    {
                        var participent = context.Participants.Where(a => a.Id == registrationModel.ParticipantId).FirstOrDefault<Participants>();
                        participent = (UpdateParticipantDBObject(participent, registrationModel));
                        context.Entry(participent).State = EntityState.Modified;
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        return 1;
                    }
                    else
                    {
                        var teams = context.Teams.Where(t => t.Id == registrationModel.TeamId).FirstOrDefault<Teams>();
                        teams.TeamName = registrationModel.TeamName;
                        context.Entry(teams).State = EntityState.Modified;
                        var membershipList = context.Memberships.Where(m => m.TeamId == registrationModel.TeamId);
                        foreach (var membership in membershipList)
                        {
                            var participent = context.Participants.Where(a => a.Id == membership.ParticipantId).FirstOrDefault<Participants>();
                            participent.ContactNo = registrationModel.Contact;
                            context.Entry(participent).State = EntityState.Modified;
                        }
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        return 1;
                    }

                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return 0;
                }
            }
        }

        public int DeleteRegistrations(int participantId)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var participent = context.Participants.Where(a => a.Id == participantId).FirstOrDefault<Participants>();
                    if (!participent.IsGroup)
                    {
                        context.Entry(participent).State = EntityState.Deleted;
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        return 1;
                    }
                    else
                    {
                        context.Entry(participent).State = EntityState.Deleted;
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        return 1;
                    }

                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return 0;
                }
            }
        }
        public async Task<IEnumerable<CegsModel>> GetCegsAsync()
        {
            var ceg = context.Cegs.ToListAsync<Cegs>();
            var newCegModel = AutoMapper.Mapper.Map<IEnumerable<CegsModel>>(ceg.Result);
            return newCegModel;
        }

        public async Task<IEnumerable<CompetitionModel>> GetCompetitionsAsync(bool isGroup)
        {
            string grpOrIntl = isGroup ? "Group" : "Induvidual";
            var competition = context.Competition.Where(c=>c.Type == grpOrIntl).ToListAsync<Competition>();
            var newcompetitionModel = AutoMapper.Mapper.Map<IEnumerable<CompetitionModel>>(competition.Result); 
            return newcompetitionModel;
        }

        public RegistrationModel GetRegistrationById(long empId)
        {
            //Registrations registration = samplecontext.Registrations.FirstOrDefaultAsync(x => x.EmployeeId == empId).Result;
            //var newRegistration = AutoMapper.Mapper.Map<RegistrationModel>(registration);
            return new RegistrationModel();
        }

        public async Task<IEnumerable<TiersModel>> GetTiersAsync()
        {
            var tier = context.Tiers.ToListAsync<Tiers>();
            var newTierModel = AutoMapper.Mapper.Map<IEnumerable<TiersModel>>(tier.Result);
            return newTierModel;
        }

        public async Task<IEnumerable<RegistrationModel>> GetAllRegistrationsAsync(bool isGroup)
        {
            IEnumerable<RegistrationModel> registrationData = null;
            if (isGroup)
            {

                registrationData = (from t in context.Teams
                                    join m in context.Memberships on t.Id equals m.TeamId
                                    join p in context.Participants on m.ParticipantId equals p.Id
                                    join c in context.Competition on p.CompetitionId equals c.Id
                                    select new RegistrationModel()
                                    {
                                        CompetitionName = c.Name,
                                        TeamName = t.TeamName,
                                        Contact = p.ContactNo,
                                        IsGroup = p.IsGroup,
                                        TeamId = t.Id,
                                        TeamPath = ""
                                        //teamMembers = new List<TeamsModel>()
                                        //{
                                        //    new TeamsModel()
                                        //    {
                                        //        Id = Convert.ToString(p.Id),
                                        //        Name = p.EmployeeName
                                        //       }
                                        //},

                                    }).Distinct();


                return registrationData;
            }
            else
            {
                registrationData = from p in context.Participants
                                   join c in context.Competition on p.CompetitionId equals c.Id
                                   select new RegistrationModel()
                                   {
                                       CompetitionName = c.Name,
                                       ParticipantId = p.Id,
                                       EmployeeId = p.EmployeeId,
                                       EmployeeName = p.EmployeeName,
                                       CegId = p.CegId,
                                       CompetitionsId = p.CompetitionId,
                                       Contact = p.ContactNo,
                                       IsGroup = p.IsGroup,
                                       TeamName = "",
                                       TeamPath = "",
                                       teamMembers = new List<TeamsModel>(),
                                       TierId = p.TierId,

                                   };
                return registrationData.Where(c => c.IsGroup == false);

            }


        }

        public async Task<IEnumerable<ParticipentModel>> GetTeamMemberByIdAsync(int teamId)
        {
            IEnumerable<ParticipentModel> teamDataList = null;
            teamDataList = (from t in context.Teams
                            join m in context.Memberships on t.Id equals m.TeamId
                            join p in context.Participants on m.ParticipantId equals p.Id
                            select new ParticipentModel()
                            {
                                TeamId = t.Id,
                                EmployeeId = p.EmployeeId,
                                EmployeeName = p.EmployeeName,
                                CompetitionId = p.CompetitionId,
                                ContactNo = p.ContactNo
                            }).Where(t => t.TeamId == teamId);

            return teamDataList;
        }

        public int EditTeamMembers(List<ParticipentModel> participentModel)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var participantData in participentModel)
                    {
                        var singleParticipent = context.Participants.Where(a => a.EmployeeId == participantData.EmployeeId).FirstOrDefault<Participants>();
                        RegistrationModel registrationData = new RegistrationModel()
                        {
                            EmployeeId = participantData.EmployeeId,
                            EmployeeName = participantData.EmployeeName,
                            TeamId = participentModel[0].TeamId,
                            CompetitionsId = participentModel[0].CompetitionId,
                            Contact = participentModel[0].ContactNo,
                            IsGroup = true,
                        };
                        if (singleParticipent!= null)
                        {
                            var participent = (UpdateParticipantDBObject(singleParticipent, registrationData));
                            context.Entry(participent).State = EntityState.Modified;
                            context.SaveChanges();
                        }
                        else
                        {
                            var participent = (PopulateParticipantDBObject(registrationData));
                            context.Participants.Add(participent);
                            context.SaveChanges();

                            var id = participent.Id;
                            var membership = new Memberships()
                            {
                                ParticipantId = id,
                                TeamId = registrationData.TeamId
                            };

                            context.Memberships.Add(membership);
                            context.SaveChanges();
                        }
                        
                    }
                    dbContextTransaction.Commit();
                    return 1;
                }
                catch (Exception exp)
                {
                    return 0;
                    throw;
                }
            }
        }

        #endregion

        #region private methods
        private Participants PopulateParticipantDBObject(RegistrationModel registrationModel)
        {
            return new Participants
            {
                EmployeeId = registrationModel.EmployeeId,
                EmployeeName = registrationModel.EmployeeName,
                ContactNo = registrationModel.Contact,
                CompetitionId = registrationModel.CompetitionsId,
                CegId = registrationModel.CegId,
                TierId = registrationModel.TierId,
                EventCode = "",
                IsGroup = registrationModel.IsGroup

            };
        }
        private Participants UpdateParticipantDBObject(Participants participants, RegistrationModel registrationModel)
        {
            try
            {
                participants.EmployeeId = registrationModel.EmployeeId;
                participants.EmployeeName = registrationModel.EmployeeName;
                participants.ContactNo = registrationModel.Contact;
                participants.CompetitionId = registrationModel.CompetitionsId;
                participants.CegId = (participants.CegId == 0) ? registrationModel.CegId : participants.CegId;
                participants.TierId = (participants.TierId == 0) ? registrationModel.TierId : participants.TierId;
                participants.EventCode = "";
                return participants;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private int InsertParticipantandMembership(int teamId, RegistrationModel registrationModel)
        {
            try
            {
                foreach (var member in registrationModel.teamMembers)
                {
                    var participant = new Participants()
                    {
                        EmployeeId = Convert.ToInt32(member.Id),
                        EmployeeName = member.Name,
                        ContactNo = registrationModel.Contact,
                        CompetitionId = registrationModel.CompetitionsId,
                        CegId = registrationModel.CegId,
                        TierId = registrationModel.TierId,
                        EventCode = "",
                        IsGroup = registrationModel.IsGroup,
                        TeamParentId = 1


                    };
                    context.Participants.Add(participant);
                    context.SaveChanges();

                    var id = participant.Id;
                    var membership = new Memberships()
                    {
                        ParticipantId = id,
                        TeamId = teamId
                    };

                    context.Memberships.Add(membership);



                }
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }


        #endregion

    }
}
