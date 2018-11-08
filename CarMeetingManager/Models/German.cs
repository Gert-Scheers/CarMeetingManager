using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarMeetingManager.Models
{
    public class German
    {
        [Key]
        public int GermanId { get; set; }
        [Display(Name ="Merk")]
        public string Make { get; set; }
    }
}
