using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Food_delivery_app_LabCouse1.Models
{
    public class Perdoruesi
    {
        [Key]
        public int perdoruesiID { get; set; }
        public string email { get; set; }
        public string emri { get; set; }
        public string password { get; set; }
        public string qyteti { get; set; }
        public string adresa { get; set; }
        public string nr_telefonit { get; set; }
        public string photoProfile { get; set; }
        public int roliID { get; set; }
        [ForeignKey("roliID")]
        public Roli roli { get; set; }

    }
}