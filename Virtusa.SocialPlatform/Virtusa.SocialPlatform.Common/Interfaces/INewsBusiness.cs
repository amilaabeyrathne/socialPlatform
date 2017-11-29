using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Virtusa.SocialPlatform.Common.Models;

namespace Virtusa.SocialPlatform.Common.Interfaces
{
    public interface INewsBusiness
    {
        Task<NewsModel> GetNews(int id);

        Task<IEnumerable<NewsModel>> GetAllNews();

        int AddNews(NewsModel newsItemToAdd);

        int EditNews(NewsModel newsModel);

        int DeleteNews(int newsId);

        int PublishNews(int newsId);


    }
}
