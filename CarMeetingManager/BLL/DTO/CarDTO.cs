using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarMeetingManager.BLL.DTO
{
    public class CarDTO
    {
        public int MakeId { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public string Displacement { get; set; }
        public string Wheels { get; set; }

        //Navigation properties
        //public CarMake Make { get; set; }
        //public LoweringType Lowering { get; set; }
    }
}
