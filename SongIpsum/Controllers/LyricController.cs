using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SongIpsum.Models;

namespace SongIpsum.Controllers
{
   /* [RoutePrefix("api/lyric")] */
    public class LyricController : ApiController
    {
        [HttpGet, Route("api/lyric")]
        public HttpResponseMessage GetLyrics()
        {
            var db = new ApplicationDbContext();

            var lyrics = db.Lyric;

            return Request.CreateResponse(HttpStatusCode.OK, lyrics);
        }

    }
}
