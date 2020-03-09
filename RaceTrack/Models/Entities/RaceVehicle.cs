using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RaceTrack.Models
{
    public partial class RaceVehicle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Display(Name = "Race")]
        [Required]
        public int RaceId { get; set; }

        [Display(Name = "Vehicle")]
        [Required]
        public int VehicleId { get; set; }

        [Display(Name = "Tow strap on the vehicle")]
        public bool HasTowStrap { get; set; }

        [Display(Name = "Less than 85% tire wear")]
        public bool AcceptableTireWear { get; set; }

        [Display(Name = "Not lifted more than 5 inches")]
        public bool AcceptableLift { get; set; }

        public Vehicle Vehicle { get; set; }
        public Race Race { get; set; }
    }
}
