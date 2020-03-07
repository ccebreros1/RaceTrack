using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RaceTrack.Models
{
    public partial class RaceVehicle
    {
        [NotMapped]
        public string VehicleType { get; set; }
    }
}
