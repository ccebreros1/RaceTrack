using System;
using System.Collections.Generic;

namespace RaceTrack.Models
{
    public class RaceTrackInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Race> Races { get; set; }
    }
}
