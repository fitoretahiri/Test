using Food_delivery_app_LabCouse1.Data;
using Food_delivery_app_LabCouse1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Food_delivery_app_LabCouse1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;

        public RestaurantController(IConfiguration configuration, ApplicationDbContext db)
        {
            _configuration = configuration;
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<Restaurant>>> GetRestorantet()
        {
            return await _db.Restaurant.Include("perdoruesi").ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestoranti(int id)
        {
            return await _db.Restaurant.FindAsync(id);
        }

        [HttpPost]
        public JsonResult addRestoranti(Restaurant restoranti){
                _db.Restaurant.Add(restoranti);
                _db.SaveChanges();
                return new JsonResult("Restoranti u shtua me sukses");
        }

        [HttpPut]
        public JsonResult updateRestoranti(Restaurant restoranti)
        {
            _db.Restaurant.Update(restoranti);
            _db.SaveChanges();

            return new JsonResult("Restoranti u perditesua me sukses");
        }

        [HttpDelete("{id}")]
        public JsonResult deleteRestoranti(int id)
        {
           var restoranti = _db.Restaurant.Find(id);
           _db.Remove(restoranti);
           _db.SaveChanges();

            return new JsonResult("Restoranti u fshi me sukses");
        }
    }
}
