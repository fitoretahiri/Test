using Food_delivery_app_LabCouse1.Data;
using Food_delivery_app_LabCouse1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Food_delivery_app_LabCouse1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KlientiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;

        public KlientiController(IConfiguration configuration, ApplicationDbContext db)
        {
            _configuration = configuration;
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<Klienti>>> GetKlientet()
        {
            return await _db.Klienti.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Klienti>> GetKlientin(int id)
        {
            return await _db.Klienti.FindAsync(id);
        }

        [HttpPost]
        public JsonResult addKlientin(Klienti klienti)
        {
            _db.Klienti.Add(klienti);
            _db.SaveChanges();
            return new JsonResult("Klienti u shtua me sukses");
        }

        [HttpPut]
        public JsonResult updateKlientin(Klienti klienti)
        {
            _db.Klienti.Update(klienti);
            _db.SaveChanges();

            return new JsonResult("Klienti u perditesua me sukses");
        }

        [HttpDelete("{id}")]
        public JsonResult deleteKleintin(int id)
        {
            var klienti = _db.Klienti.Find(id);
            _db.Remove(klienti);
            _db.SaveChanges();

            return new JsonResult("Klienti u fshi me sukses");
        }
    }
}
