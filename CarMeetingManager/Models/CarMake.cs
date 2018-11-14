using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarMeetingManager.Models
{
    public class CarMake
    {
        [Key]
        public int MakeID { get; set; }
        public string Make { get; set; }
        public string CountryCode { get; set; }
    }
}
