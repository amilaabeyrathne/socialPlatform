using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtusa.SocialPlatform.Common.Interfaces;
using Virtusa.SocialPlatform.Common.Models;
using Virtusa.SocialPlatform.Data.Models;

namespace Virtusa.SocialPlatform.Data
{

    public class NewsDataAccess : INewsDataAccess
    {
        SampleContext context;
        public NewsDataAccess(SampleContext DbContext)
        {
            context = DbContext;
        }

        public async Task<NewsModel> GetNews(int id)
        {
            //return context.News..FirstOrDefaultAsync(x => new NewsModel{Title=x.
            News selectedNews = await context.News.FirstOrDefaultAsync(x => x.Id == id);

            return PopulateNewsModel(selectedNews);
        }


        public async Task<IEnumerable<NewsModel>> GetAllNews()
        {
            //TODO: Select only isPublished == true
            IEnumerable<NewsModel> allNewsFromDB= await context.News.Select(x=>PopulateNewsModel(x))
                                                                    .OrderBy(x => x.Priority)
                                                                    .ThenByDescending(x=>x.DateCreated)
                                                                    .ToListAsync();

            return allNewsFromDB;
        }

        public int Save(NewsModel newsItemToAdd)
        {
            context.News.Add(PopulateNewsDBObject(newsItemToAdd));
            return context.SaveChanges();

        }

        private NewsModel PopulateNewsModel(News newsFromDB)
        {
            return new NewsModel
            {
                Id = newsFromDB.Id,
                Content = newsFromDB.Content,
                Category = newsFromDB.Category,
                CreatedBy = newsFromDB.CreatedBy,
                LastModified = newsFromDB.LastModified,
                DateCreated = newsFromDB.DateCreated,
                EventCode = newsFromDB.EventCode,
                ExpiryDate = newsFromDB.ExpiryDate,
                IsPublished = newsFromDB.IsPublished,
                Title = newsFromDB.Title,
                Priority = newsFromDB.Priority,
                Summary = newsFromDB.Summary
                
            };
        }

        private News PopulateNewsDBObject(NewsModel newsModel)
        {
            return new News
            {
                Id = newsModel.Id,
                Content = newsModel.Content,
                Category = newsModel.Category,
                CreatedBy = newsModel.CreatedBy,
                LastModified = newsModel.LastModified,
                DateCreated = newsModel.DateCreated,
                EventCode = newsModel.EventCode,
                ExpiryDate = newsModel.ExpiryDate,
                IsPublished = newsModel.IsPublished,
                Title = newsModel.Title,
                Priority = newsModel.Priority,
                Summary = newsModel.Summary
            };
        }

        public int EditNews(NewsModel newsModel)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {

                    var NewsItems = context.News.Where(a => a.Id == newsModel.Id).FirstOrDefault<News>();
                    NewsItems = (UpdateNewsDBObject(NewsItems, newsModel));
                    context.Entry(NewsItems).State = EntityState.Modified;
                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return 1;

                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return 0;
                }
            }
        }

        private News UpdateNewsDBObject(News news, NewsModel newsModel)
        {
            try
            {
                news.Title = newsModel.Title;
                news.Content = newsModel.Content;
                news.ExpiryDate = newsModel.ExpiryDate;
                return news;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public int DeleteNews(int newsId)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {

                    var newsItem = context.News.Where(a => a.Id == newsId).FirstOrDefault<News>();
                    newsItem.IsDeleted = true;
                    context.Entry(newsItem).State = EntityState.Modified;
                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return 1;

                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return 0;
                }
            }
        }

        public int PublishNews(int newsId)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {

                    var newsItem = context.News.Where(a => a.Id == newsId).FirstOrDefault<News>();
                    newsItem.IsPublished = true;
                    context.Entry(newsItem).State = EntityState.Modified;
                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return 1;

                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return 0;
                }
            }
        }



    }
}
