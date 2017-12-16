using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SongIpsum.Models;

namespace SongIpsum.Controllers
{
    [RoutePrefix("api/lyric")]
    public class LyricController : ApiController
    {
        [HttpGet, Route("")]
        public HttpResponseMessage GetLyrics()
        {
            var db = new ApplicationDbContext();

            var lyrics = db.Lyric;

            return Request.CreateResponse(HttpStatusCode.OK, lyrics);
        }

        //[HttpGet, Route("api/lyric/decade")]
        //public HttpResponseMessage GetAllDecades()
        //{
        //    var db = new ApplicationDbContext();

        //    var allDecades = db.Lyric;

        //    return Request.CreateResponse(HttpStatusCode.OK, allDecades);
        //}

        [HttpGet, Route("decade/{Decade}")]
        public HttpResponseMessage GetDecade(int Decade)
        {
            var db = new ApplicationDbContext();

            var decades = db.Lyric.Where(decade => decade.Decade == Decade);

            return Request.CreateResponse(HttpStatusCode.OK, decades);
        }

    }
}
