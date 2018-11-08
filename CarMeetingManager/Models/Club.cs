using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarTuningEventManager.Models
{
    public class Club
    {
        [Key]
        public int ClubId { get; set; }
        [Required][Display(Name="Naam")]
        public string Name { get; set; }
        [Required][Display(Name="Omschrijving")]
        public string Description { get; set; }
        public string Photo { get; set; }
        [Required][EmailAddress]
        public string Contact { get; set; }
    }
}
