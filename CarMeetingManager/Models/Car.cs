using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarTuningEventManager.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        [Required][Display(Name ="Merk")]
        public string Make { get; set; }
        [Required][Display(Name ="Model")]
        public string Model { get; set; }
        [Required][Display(Name ="Bouwjaar")]
        public int ProductionYear { get; set; }
        [Display(Name ="Cilinderinhoud")]
        public string Displacement { get; set; }
        public int LoweringId { get; set; }
        [Display(Name ="Velgen en banden")]
        public string Wheels { get; set; }

        public Lowering Lowering { get; set; }
    }
}
