using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarMeetingManager.Models
{
    public class Lowering
    {
        [Key]
        public int LoweringId { get; set; }
        public string Type { get; set; }
    }
}
