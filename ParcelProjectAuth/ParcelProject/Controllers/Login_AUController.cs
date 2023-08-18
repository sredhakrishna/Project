using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParcelProject.Data;
using ParcelProject.DTO.Registration;
using ParcelProject.Model;

namespace ParcelProject.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class Login_AUController : ControllerBase
    {
        public readonly DbContextClass dbContextClass;
        IMapper _mapper;

        public Login_AUController(DbContextClass _db, IMapper mapper)
        {
            dbContextClass = _db;
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<ActionResult> GetAdminUsers()
        {
            return Ok(await dbContextClass.ADMIN_USER.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<AdminUser>> Postadm([FromBody] Registrationdto regdot)
        {
            var adm = _mapper.Map<AdminUser>(regdot);
            await dbContextClass.AddAsync(adm);
            await dbContextClass.SaveChangesAsync();
            return Ok(adm);
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<AdminUser>> put([FromBody] Registrationdto regdot, int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var Admin = _mapper.Map<AdminUser>(regdot);
            dbContextClass.ADMIN_USER.Update(Admin);
            await dbContextClass.SaveChangesAsync();
            return Ok(Admin);
        }
        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var result = dbContextClass.ADMIN_USER.Find(id);
            dbContextClass.ADMIN_USER.Remove(result);
            await dbContextClass.SaveChangesAsync();
            return Ok(result);
        }
    }
}
