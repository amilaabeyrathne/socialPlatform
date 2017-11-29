using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Virtusa.SocialPlatform.Common.Interfaces;
using Virtusa.SocialPlatform.Common.Models;

namespace Virtusa.SocialPlatform.Business
{
    public class NewsBusiness : INewsBusiness
    {
        INewsDataAccess data;
        public NewsBusiness(INewsDataAccess dataAccess)
        {
            data = dataAccess;
        }

        public int AddNews(NewsModel newsItemToAdd)
        {
            return data.Save(newsItemToAdd);
        }

        public async Task<IEnumerable<NewsModel>> GetAllNews()
        {
            return await data.GetAllNews();
        }

        public async Task<NewsModel> GetNews(int id)
        {
            return await data.GetNews(id);
        }
        public int EditNews(NewsModel newsModel)
        {
            return data.EditNews(newsModel);
        }

        public int DeleteNews(int newsId)
        {
            return data.DeleteNews(newsId);
        }

        public int PublishNews(int newsId)
        {
            return data.PublishNews(newsId);

        }

    }
}
