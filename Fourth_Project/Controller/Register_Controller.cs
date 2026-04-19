using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Fourth_Project.Data;
using Fourth_Project.Model;
using System.Diagnostics.Tracing;
using System.Runtime.Versioning;

namespace Fourth_Project.Controller
{
    [ApiController]
    [Route("Student")]
    public class Register_Controller : ControllerBase
    {
        private readonly AppDBContext _context;
        public Register_Controller(AppDBContext context)  // dependency injection er maddhome database context ke inject kora hocche
        {
            _context = context;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(Register_Model User)
        {
            var userInfo = await _context.UserInfo
                .FirstOrDefaultAsync(x => x.Email == User.Email);

            if (userInfo != null)
            {
                return BadRequest("User already exists with this email.");
            }

            var newUser = new Register_Model
            {
                Id = Guid.NewGuid(),
                Name = User.Name,
                Email = User.Email,
                Password = User.Password
            };

            await _context.UserInfo.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return Created($"Registration Successful! Welcome {User.Name}!", newUser);
        }

        
        [HttpGet("getallusers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _context.UserInfo.ToListAsync();
            return Ok(users);
        }


    }
}