using Food_delivery_app_LabCouse1.Data;
using Food_delivery_app_LabCouse1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Food_delivery_app_LabCouse1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Restaurant_QytetiController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;

        public Restaurant_QytetiController(IConfiguration configuration, ApplicationDbContext db)
        {
            _configuration = configuration;
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<Restaurant_Qyteti>>> GetLidhjet()
        {
            return await _db.restaurant_Qyteti.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant_Qyteti>> GetLidhja(int id)
        {
            return await _db.restaurant_Qyteti.FindAsync(id);
        }

        [HttpPost]
        public JsonResult addLidhja(Restaurant_Qyteti lidhjet)
        {
            _db.restaurant_Qyteti.Add(lidhjet);
            _db.SaveChanges();
            return new JsonResult("Lidhja u realizua me sukses");
        }

        [HttpPut]
        public JsonResult updateLidhja(Restaurant_Qyteti lidhjet)
        {
            _db.restaurant_Qyteti.Update(lidhjet);
            _db.SaveChanges();

            return new JsonResult("Lidhja u perditesua me sukses");
        }

        [HttpDelete("{id}")]
        public JsonResult deleteLidhja(int id)
        {
            var lidhja= _db.restaurant_Qyteti.Find(id);
            _db.Remove(lidhja);
            _db.SaveChanges();

            return new JsonResult("Lidhja u fshi me sukses");
        }
    }
}