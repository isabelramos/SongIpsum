using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SongIpsum.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string ArtistName { get; set; }
        public int Decade { get; set; }
        public string Genre { get; set; }
    }
}
