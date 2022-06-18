using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Food_delivery_app_LabCouse1.Models
{
    public class Menu
    {
        public int Id { get; set; }

        public string emertimi { get; set; }

        public int nr_artikujve { get; set; }
        //lidhja e tabeles menu me tabelen restaurant
        public int restaurantID { get; set; }
        [ForeignKey("restaurantID")]
        public Restaurant restaurant { get; set; }
    }
}
