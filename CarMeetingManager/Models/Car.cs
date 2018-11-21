﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarMeetingManager.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        public int MakeId { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public string Displacement { get; set; }
        public int LoweringId { get; set; }
        public string Wheels { get; set; }
        public int MemberId { get; set; }

        //Navigation properties
        public CarMake Make { get; set; }
        public LoweringType Lowering { get; set; }
    }
}
