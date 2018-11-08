using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarMeetingManager.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        [Required][Display(Name="Naam")]
        public string Name { get; set; }
        [Required][Display(Name="Omschrijving")]
        public string Description { get; set; }
        [Required][Display(Name="Locatie")]
        public string Location { get; set; }
        [Required][Display(Name="Plaatsen")]
        public int Capacity { get; set; }
        public int EventTypeId { get; set; }

        public EventType Type { get; set; }
    }
}