using System;
using System.Collections.Generic;

namespace Food_delivery_app_LabCouse1.Models
{
    public class Qyteti
    {
        public int Id { get; set; }

        public string emri { get; set; }

        public List<Restaurant_Qyteti> Restaurant_Qyteti { get; set; }
    }
}
