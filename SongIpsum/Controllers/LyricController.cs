using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SongIpsum.Models;
using RestSharp;
using Bearded.Utilities;
using Bearded.Utilities.Linq;

namespace SongIpsum.Controllers
{
    [RoutePrefix("api/lyric")]
    public class LyricController : ApiController
    {
        private ApplicationDbContext Db { get; set; }

        [HttpGet, Route("decade/{Decade}")]
        public HttpResponseMessage GetDecade(int Decade)
        {
            if (Db == null)
            {
                Db = new ApplicationDbContext();
            }

            var listOfArtists = Db.Artist.Where(decade => decade.Decade == Decade).RandomSubset(5);

            var criteria = GetLyricsFromAnyUserCriteria(listOfArtists);
            return Request.CreateResponse(HttpStatusCode.OK, criteria);

        }

        public string GetLyricsFromAnyUserCriteria(List<Artist> listOfArtists)
        {

            var randomTracksFromSelectedArtist = new List<Track>();

            foreach (var artist in listOfArtists)
            {
                var randomTrack =
                    Db.Track.Where(track => track.Artist.ArtistName == artist.ArtistName).RandomSubset(1).First();

                randomTracksFromSelectedArtist.Add(randomTrack);
            }

            List<string> listOfLyrics = GetLyricsFromMusixmatch(randomTracksFromSelectedArtist);

            var ipsumSplit = listOfLyrics.SelectMany(x => x.Split(new[] { "\r\n", "\r", "\n", "******* This Lyrics is NOT for Commercial use *******", "\n(1409616768196)", "(1409616768196)" }, StringSplitOptions.RemoveEmptyEntries));

            var ipsum = string.Join(" ", ipsumSplit.RandomSubset(25));

            return ipsum;
        }

        private List<string> GetLyricsFromMusixmatch(List<Track> randomTracksFromSelectedArtist)
        {
            var client = new RestClient("http://api.musixmatch.com/ws/1.1/matcher.lyrics.get");

            var apiKey = new ApiConstants().Apikey;

            var request = new RestRequest("", Method.GET);
            request.AddParameter("apikey", apiKey);
            client.ClearHandlers();
            client.AddHandler("*", new RestSharp.Deserializers.JsonDeserializer());

            var allSelectedLyrics = new List<string>();

            foreach (var track in randomTracksFromSelectedArtist)
            {
                request.AddParameter("q_track", track.TrackName);
                request.AddParameter("q_artist", track.Artist.ArtistName);
                
                var response = client.Execute<MusixmatchResponse.RootObject>(request);
                var lyric = response.Data.message.body.lyrics.lyrics_body;

                allSelectedLyrics.Add(lyric);
            }

            return allSelectedLyrics;
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
