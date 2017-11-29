using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using Virtusa.SocialPlatform.Common.Interfaces;
using Virtusa.SocialPlatform.Common.Models;
using Virtusa.SocialPlatform.Data.Models;
using Virtusa.SocialPlatform.Common;

namespace Virtusa.SocialPlatform.Data
{
    public class CompetitionDataAccess : ICompetitionDataAccess
    {
        #region class variables

        SampleContext context;

        #endregion

        #region constructors

        public CompetitionDataAccess(SampleContext DbContext)
        {
            context = DbContext;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Get all competitons
        /// </summary>
        /// <returns></returns>
        public List<CompetitionModel> GetAll()
        {
            List<Competition> list = (from com in context.Competition
                                      where com.IsDeleted == false
                                      select com).OrderByDescending(x => x.EditedOn).ToList();

            Mapper.Initialize(cfg => {
                cfg.CreateMap<Competition, CompetitionModel>();
            });

            List<CompetitionModel> modelList = new List<CompetitionModel>();

            foreach (Competition item in list)
            {
                CompetitionModel model = Mapper.Map<CompetitionModel>(item);
                modelList.Add(model);
            }

            return modelList;
        }

        public List<CompetitionModel> GetCompetition(int id)
        {
            throw new NotImplementedException();
        }

        public string Save(CompetitionModel model)
        {

            Mapper.Initialize(cfg => {
                cfg.CreateMap<CompetitionModel, Competition>();
            });

            try
            {
                Competition item = Mapper.Map<Competition>(model);
                item.EditedOn = DateTime.Now;
                context.Add(item);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

            return CommonResource.ResourceManager.GetString("SuccessMessage");
        }

        public string Delete(long id)
        {
            try
            {
                Competition competitionToUpdate = context.Competition.FirstOrDefault(x => x.Id == id);
                competitionToUpdate.IsDeleted = true;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return CommonResource.ResourceManager.GetString("SuccessMessage");
        }

        public string Update(CompetitionModel model)
        {
            try
            {
                Competition competitionToUpdate = context.Competition.FirstOrDefault(x => x.Id == model.Id);
                competitionToUpdate.Name = model.Name;
                competitionToUpdate.RegistrationEndDate = model.registrationEndDate;
                competitionToUpdate.Type = model.Type;
                competitionToUpdate.EditedOn = DateTime.Now;
                competitionToUpdate.Description = model.Description;
                context.SaveChanges();

            }
            catch (Exception ex)
            {

                return ex.Message;
            }

            return CommonResource.ResourceManager.GetString("SuccessMessage");
        }
        #endregion
    }
}
