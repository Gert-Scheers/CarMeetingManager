using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarMeetingManager.Models
{
    public class Registration
    {
        [Key]
        public int RegistrationId { get; set; }
        [Required]
        public int MemberId { get; set; }
        [Required]
        public int EventId { get; set; }

        //Navigation propertiess
        public Member Member { get; set; }
        public Event Event { get; set; }
    }
}
