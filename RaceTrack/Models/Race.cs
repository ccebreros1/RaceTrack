using System;
using System.Collections.Generic;
using System.Text;

namespace RaceTrack.Models
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public DateTime Date { get; set; }
        public int RaceTrackId { get; set; }

        public RaceTrackInfo RaceTrack { get; set; }
    }
}
