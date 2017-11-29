using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Virtusa.SocialPlatform.Common.Models;

namespace Virtusa.SocialPlatform.Common.Interfaces
{
    public interface INewsDataAccess
    {
        Task<NewsModel> GetNews(int id);
        int Save(NewsModel newsItemToAdd);

        Task<IEnumerable<NewsModel>> GetAllNews();

        int EditNews(NewsModel newsModel);

        int DeleteNews(int newsId);

        int PublishNews(int newsId);
    }
}
