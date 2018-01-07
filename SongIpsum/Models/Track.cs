using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SongIpsum.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string TrackName { get; set; }
        public virtual Artist Artist { get; set; }
    }
}