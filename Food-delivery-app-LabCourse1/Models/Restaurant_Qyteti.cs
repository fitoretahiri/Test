using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Food_delivery_app_LabCouse1.Models
{
    public class Restaurant_Qyteti
    {
        [Key]
        public int id { get; set; }
        public int restaurantID { get; set; }
        [ForeignKey("restaurantID")]
        public Restaurant restaurant { get; set; }

        public int qytetiID { get; set; }
        [ForeignKey("qytetiID")]
        public Qyteti qyteti { get; set; }


    }
}
