using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Food_delivery_app_LabCouse1.Models
{
    public class Restaurant
    {
        [Key]
        public int restaurantID { get; set; }
        public DateTime data_regjistrimit { get; set; }
        public int perdoruesiID { get; set; }
        [ForeignKey("perdoruesiID")]
        public Perdoruesi perdoruesi { get; set; }
        //tash lidhja me tabelen e lidhjeve
        public List<Restaurant_Qyteti> Restaurant_Qyteti { get; set; }
    }
}
