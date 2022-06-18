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
using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Food_delivery_app_LabCouse1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "AppUser")]
    public class RoleController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;

        public RoleController(IConfiguration configuration, ApplicationDbContext db)
        {
            _configuration = configuration;
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<Roli>>> GetRoles()
        {
            return await _db.Roli.ToListAsync();
        }

        [HttpGet("{roliID}")]
        public async Task<ActionResult<Roli>> GetRole(int id)
        {
            return await _db.Roli.FindAsync(id);
        }

        [HttpPost]
        public JsonResult addRolin(Roli roli){
                _db.Roli.Add(roli);
                _db.SaveChanges();
                return new JsonResult("Roli u shtua me sukses");
        }

        [HttpPut]
        public JsonResult updateRolin(Roli roli)
        {
            _db.Roli.Update(roli);
            _db.SaveChanges();

            return new JsonResult("Roli u perditesua me sukses");
        }

        [HttpDelete("{id}")]
        public JsonResult deleteRolin(int id)
        {
           var roli = _db.Roli.Find(id);
           _db.Remove(roli);
           _db.SaveChanges();

            return new JsonResult("Roli u fshi me sukses");
        }
    }
}
