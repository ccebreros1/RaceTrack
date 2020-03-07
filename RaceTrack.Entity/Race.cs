using System;
using System.Collections.Generic;
using System.Text;

namespace RaceTrack.Entity
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public DateTime Date { get; set; }
        public int RaceTrackId { get; set; }

        public RaceTrack RaceTrack { get; set; }
    }
}
