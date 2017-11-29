using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Virtusa.SocialPlatform.Common.Interfaces;
using Virtusa.SocialPlatform.Common.Models;
using Virtusa.SocialPlatform.Common.Utility;

namespace Virtusa.SocialPlatform.Controllers
{
    //[Produces("application/json")]
    [Route("api/OrderDetails")]
    public class OrderDetailsController : Controller
    {
        IOrderBussiness orderBusiness;
        EmailSender _emailSender;

        public OrderDetailsController(IOrderBussiness _orderBusiness)
        {
            orderBusiness = _orderBusiness;
         
        }

        // POST: api/OrderDetails
        [HttpPost]
        public int Post([FromBody]OrderModel orderModel)
        {
          if(null != orderModel)
            {
                var result = orderBusiness.makeOrder(orderModel);
                return result;

            }
            else
            {
                return 0;
            }
            
        }

        //public async Task TestAction()
        //{
        //    List<string> Recipients = new List<string>();
        //    Recipients.Add("uhazzan@virtusa.com");
        //    Recipients.Add("smrathnayake@virtusa.com");
        //    Recipients.Add("MWelivita@virtusa.com");
        //    await _emailSender.SendEmailAsync(Recipients, "Test Mail", $"This is Test Email For SocialPlatForm");
        //    ViewBag.message = "Email sent";
        //}
    }
}
