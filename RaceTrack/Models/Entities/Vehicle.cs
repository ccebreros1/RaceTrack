using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RaceTrack.Models
{
    public partial class Vehicle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Display(Name = "Owner")]
        [Required]
        public string OwnerName { get; set; }

        [Display(Name = "Vehicle Alias")]
        public string VehicleAlias { get; set; }

        [Display(Name = "Vehicle Type")]
        [Required]
        public int VehicleTypeId { get; set; }

        public virtual ICollection<RaceVehicle> RaceVehicles { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}
