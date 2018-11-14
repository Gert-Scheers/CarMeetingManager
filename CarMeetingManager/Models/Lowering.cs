using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarMeetingManager.Models
{
    public enum VeringType
    {
        None = 1,
        Springs = 2,
        Coilovers = 3,
        Airride = 4
    }

    public class Lowering
    {
        [Key]
        public int LoweringId { get; set; }
        public VeringType Type { get; set; }
    }
}
