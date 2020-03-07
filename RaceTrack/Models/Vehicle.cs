﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RaceTrack.Models
{
    public class Vehicle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string OwnerName { get; set; }
        public string VehicleAlias { get; set; }
        public int VehicleTypeId { get; set; }

        public virtual ICollection<RaceVehicle> RaceVehicles { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}
