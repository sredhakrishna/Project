using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Registration.Data;
using Registration.Models;
using Registration.Services;
namespace Registration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly DbContextClass _context;



        public RegisterController(DbContextClass context)

        {

            _context = context;

        }

        [HttpGet]
        public async Task<IActionResult> GetRegister()
        {
            return Ok(await _context.Details.ToListAsync());
        }

        //post:

        [HttpPost("user")]

        public async Task<IActionResult> RegisterUser([FromBody] Register product)

        {

            product.Role = "User";

            _context.Details.Add(product);

            await _context.SaveChangesAsync();

            return Ok(product);

        }

        //post

        [HttpPost("admin")]

        public async Task<IActionResult> RegisterAdmin([FromBody] Register product)

        {

            product.Role = "Admin";

            _context.Details.Add(product);

            await _context.SaveChangesAsync();

            return Ok(product);

        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Register>> put([FromBody] Register Admin, int id)
        {
            //var _id = _context.Details.Find(id);
            if (id == 0)
            {
                return BadRequest();
            }
            _context.Details.Update(Admin);
            await _context.SaveChangesAsync();
            return Ok(Admin);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result =_context.Details.Find(id);
            _context.Details.Remove(result);
            await _context.SaveChangesAsync();
            return Ok(result);
        }
        //    private readonly IRegisterService registerService;
        //    public RegisterController(IRegisterService _registerService)
        //    {
        //        registerService = _registerService;
        //    }
        //    [HttpGet]
        //    public IEnumerable<Register> RegisterList()
        //    {
        //        var registerList = registerService.GetRegisterList();
        //        return registerList;
        //    }
        //    [HttpGet("{id}")]
        //    public Register GetRegisterById(int id)
        //    {
        //        return registerService.GetRegisterById(id);
        //    }
        //    [HttpPost]
        //    public Register AddRegister(Register product)
        //    {
        //        return registerService.AddRegister(product);
        //    }
        //    [HttpPut]
        //    public Register UpdateRegister(Register product)
        //    {
        //        return registerService.UpdateRegister(product);
        //    }
        //    [HttpDelete("{id}")]
        //    public bool DeleteRegister(int id)
        //    {
        //        return registerService.DeleteRegister(id);
        //    }
    }
}