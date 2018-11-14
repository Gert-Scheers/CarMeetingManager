using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarMeetingManager.Models
{
    public enum Types
    {
        Japans = 1,
        Duits = 2,
        Oldtimer = 3,
        Tuning = 4,
        Open = 5
    }

    public class EventType
    {
        [Key]
        public int EventTypeId { get; set; }
        public Types Type { get; set; }
    }
}
