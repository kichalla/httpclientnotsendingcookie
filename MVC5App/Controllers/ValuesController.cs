using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace MVC5App.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        [Route("~/getdata")]
        public HttpResponseMessage Get()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Headers.AddCookies(new[]
            {
                new CookieHeaderValue(".AspNetCore.Session", "RAExEmXpoCbueP_QYM")
                {
                    HttpOnly = true,
                    Path = "/"
                },

                new CookieHeaderValue(".AspNetCore.Antiforgery.Xam7_OeLcN4", "CfDJ8NGNxAt7CbdClq3UJ8_6w_4661wRQZT1aDtUOIUKshbcV4P0NdS8klCL5qGSN-PNBBV7w23G6MYpQ81t0PMmzIN4O04fqhZ0u1YPv66mixtkX3iTi291DgwT3o5kozfQhe08-RAExEmXpoCbueP_QYM")
                {
                    HttpOnly = true,
                    Path = "/"
                },
            });
            response.Content = new StringContent("From getdata");
            return response;
        }

        [Route("~/postdata")]
        [HttpPost]
        public string Post()
        {
            var cookies = string.Join(", ", Request.Headers.GetCookies().Select(c => c.ToString()));
            return "From post data. Cookie list: " + cookies;
        }
    }
}
