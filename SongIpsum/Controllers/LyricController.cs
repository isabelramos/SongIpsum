using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SongIpsum.Models;
using RestSharp;

namespace SongIpsum.Controllers
{
    [RoutePrefix("api/lyric")]
    public class LyricController : ApiController
    {
        [HttpGet, Route("")]
        public HttpResponseMessage GetLyrics()
        {
            var db = new ApplicationDbContext();

            var lyrics = db.Artist;

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

            var decades = db.Artist.Where(decade => decade.Decade == Decade).OrderBy(x => Guid.NewGuid()).Take(5);

            var randomTracksFromSelectedDecadeArtist = new List<Track>();

            foreach (var artist in decades)
            {
                var randomTrack =
                    db.Track.Where(track => track.Artist.ArtistName == artist.ArtistName).OrderBy(x => Guid.NewGuid()).First();

                randomTracksFromSelectedDecadeArtist.Add(randomTrack);
            }

            GetLyricsFromMusixmatch(randomTracksFromSelectedDecadeArtist);

            return Request.CreateResponse(HttpStatusCode.OK, randomTracksFromSelectedDecadeArtist);
        }

        private void GetLyricsFromMusixmatch(List<Track> randomTracksFromSelectedDecadeArtist)
        {
            var client = new RestClient("http://api.musixmatch.com/ws/1.1/matcher.lyrics.get");

            var apiKey = new ApiConstants().Apikey;

            var request = new RestRequest("", Method.GET);
            request.AddParameter("apikey", apiKey);
            client.ClearHandlers();
            client.AddHandler("*", new RestSharp.Deserializers.JsonDeserializer());

            foreach (var track in randomTracksFromSelectedDecadeArtist)
            {
                request.AddParameter("q_track", track.TrackName);
                request.AddParameter("q_artist", track.Artist.ArtistName);
                
                var response = client.Execute<MusixmatchResponse.RootObject>(request);
                var lyric = response.Data.message.body.lyrics.lyrics_body;
            }
        }

        [HttpGet, Route("genre/{Genre}")]
        public HttpResponseMessage GetGenre(string Genre)
        {
            var db = new ApplicationDbContext();

            var genres = db.Artist.Where(genre => genre.Genre == Genre);

            return Request.CreateResponse(HttpStatusCode.OK, genres);
        }

        //[HttpGet, Route("artist/{Artist}")]
        //public HttpResponseMessage GetArtist(string Artist)
        //{
        //    var db = new ApplicationDbContext();

        //    var artists = db.Artist.Where(artist => artist.Artist == Artist);

        //    return Request.CreateResponse(HttpStatusCode.OK, artists);
        //}

    }
}
