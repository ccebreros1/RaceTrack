using System;
using System.Collections.Generic;
using System.Text;

namespace RaceTrack.Entity
{
    public class RaceVehicle
    {
        public int Id { get; set; }
        public int RaceId { get; set; }
        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }
        public Race Race { get; set; }
    }
}
