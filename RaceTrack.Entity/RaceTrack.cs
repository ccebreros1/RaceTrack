using System;
using System.Collections.Generic;

namespace RaceTrack.Entity
{
    public class RaceTrack
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Race> Races { get; set; }
    }
}
