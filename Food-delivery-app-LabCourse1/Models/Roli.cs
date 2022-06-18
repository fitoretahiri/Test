using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Food_delivery_app_LabCouse1.Models
{
    public class Roli
    {
        [Key]
        public int roliID { get; set; }

        public String role { get; set; }
    }
}
