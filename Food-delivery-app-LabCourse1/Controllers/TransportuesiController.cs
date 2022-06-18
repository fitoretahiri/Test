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
    public class TransportuesiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;

        public TransportuesiController(IConfiguration configuration, ApplicationDbContext db)
        {
            _configuration = configuration;
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<Transportuesi>>> GetTransportuesit()
        {
            return await _db.Transportuesi.Include("perdoruesi").ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transportuesi>> GetTransportuesi(int id)
        {
            return await _db.Transportuesi.FindAsync(id);
        }

        [HttpPost]
        public JsonResult addTransportuesi(Transportuesi transportuesi){
                _db.Transportuesi.Add(transportuesi);
                _db.SaveChanges();
                return new JsonResult("Transportuesi u shtua me sukses");
        }

        [HttpPut]
        public JsonResult updateTransportuesi(Transportuesi transportuesi)
        {
            _db.Transportuesi.Update(transportuesi);
            _db.SaveChanges();

            return new JsonResult("Transportuesi u perditesua me sukses");
        }

        [HttpDelete("{id}")]
        public JsonResult deleteTransportuesi(int id)
        {
           var transportuesi = _db.Transportuesi.Find(id);
           _db.Remove(transportuesi);
           _db.SaveChanges();

            return new JsonResult("Transportuesi u fshi me sukses");
        }
    }
}
