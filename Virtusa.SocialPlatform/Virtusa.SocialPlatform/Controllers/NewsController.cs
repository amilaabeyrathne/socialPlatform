using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Virtusa.SocialPlatform.Common.Interfaces;
using Virtusa.SocialPlatform.Common.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Virtusa.SocialPlatform.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        INewsBusiness business;

        public NewsController(INewsBusiness bus)

        {
            business = bus;
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<NewsModel> GetNews(int id)
        {
            return await business.GetNews(id);
        }
        //// GET: api/values
        [HttpGet]
        public async Task<IEnumerable<NewsModel>> Get()
        {
            return await business.GetAllNews();
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody]NewsModel newsItemToAdd)
        {
            business.AddNews(newsItemToAdd);
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // PUT api/news
        [HttpPut]
        public int Put([FromBody]NewsModel newsModel)
        {
            if (null != newsModel)
            {
                var result = business.EditNews(newsModel);
                return result;
            }
            else
            {
                return 0;
            }

        }

        // PUT api/news
        [Route("deleteNews/{newsid}")]
        [HttpDelete]
        public int Delete(int newsid)
        {
            if (newsid != 0)
            {
                var result = business.DeleteNews(newsid);
                return result;
            }
            else
            {
                return 0;
            }

        }

        // PUT api/news
        [Route("publishNews/{newsid}")]
        [HttpDelete]
        public int Publish(int newsid)
        {
            if (newsid != 0)
            {
                var result = business.PublishNews(newsid);
                return result;
            }
            else
            {
                return 0;
            }

        }
    }
}
