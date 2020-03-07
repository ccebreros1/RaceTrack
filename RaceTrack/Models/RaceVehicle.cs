using System;
using System.Collections.Generic;
using System.Text;

namespace RaceTrack.Models
{
    public partial class RaceVehicle
    {
        public int Id { get; set; }
        public int RaceId { get; set; }
        public int VehicleId { get; set; }
        public bool HasTowStrap { get; set; }
        public bool AcceptableTireWear { get; set; }
        public bool AcceptableLift { get; set; }

        public Vehicle Vehicle { get; set; }
        public Race Race { get; set; }
    }
}
