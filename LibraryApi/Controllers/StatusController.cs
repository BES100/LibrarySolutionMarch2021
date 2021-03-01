using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public class StatusController : ControllerBase
    {

        // GET /status
        [HttpGet("status")]
        public StatusResponse GetTheStatus()
        {
            return new StatusResponse
            {
                Message = "Everything is going great. Thanks for asking!",
                LastChecked = DateTime.Now
            };
        }

        // GET /customers/13
        // GET /customers/(anyhting that is an integer)
        [HttpGet("customers/{customerId:int}")]
        public ActionResult GetInfoAboutCustomer(int customerId)
        {
            return Ok($"Getting info about customer {customerId}");
        }

        // GET blogs/2018/4/15
        [HttpGet("blogs/{year:int}/{month:int}/{day:int}")]
        public ActionResult GetBlogPosts(int year, int month, int day)
        {
            return Ok($"Getting blogs for {month}-{day}-{year}");
        }

    }

    public class StatusResponse
    {
        public string Message { get; set; }
        public DateTime LastChecked { get; set; }
    }

   
}
