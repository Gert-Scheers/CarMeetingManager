using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarMeetingManager.Models
{
    public class EventType
    {
        [Key]
        public int EventTypeId { get; set; }
        public string Type { get; set; }
    }
}
