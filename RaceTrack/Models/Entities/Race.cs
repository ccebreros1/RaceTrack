using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RaceTrack.Models
{
    public partial class Race
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set;}
        public DateTime Date { get; set; }
        public int RaceTrackId { get; set; }

        public RaceTrackInfo RaceTrack { get; set; }
    }
}
