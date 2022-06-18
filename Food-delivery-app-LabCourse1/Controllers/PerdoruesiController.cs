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
    public class PerdoruesiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;

        public PerdoruesiController(IConfiguration configuration, ApplicationDbContext db)
        {
            _configuration = configuration;
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<Perdoruesi>>> GetPerdoruesit()
        {
            return await _db.Perdoruesi.Include("roli").ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Perdoruesi>> GetPerdoruesin(int id)
        {
            return await _db.Perdoruesi.FindAsync(id);
        }
        
        [HttpPost]
        public Perdoruesi addPerdoruesin(Perdoruesi perdoruesi){
                _db.Perdoruesi.Add(perdoruesi);
                _db.SaveChanges();
                return perdoruesi;
        }

        [HttpPut]
        public JsonResult updatePerdoruesin(Perdoruesi perdoruesi)
        {
            _db.Perdoruesi.Update(perdoruesi);
            _db.SaveChanges();

            return new JsonResult("Perdoruesi u perditesua me sukses");
        }

        [HttpDelete("{id}")]
        public JsonResult deletePerdoruesin(int id)
        {
           var perdoruesi = _db.Perdoruesi.Find(id);
           _db.Remove(perdoruesi);
           _db.SaveChanges();

            return new JsonResult("Perdoruesi u fshi me sukses");
        }


    }
}
