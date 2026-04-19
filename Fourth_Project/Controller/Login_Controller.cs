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

namespace Fourth_Project.Controller
{
    [ApiController]
    [Route("Student/Login")]

    public class Login_Controller : ControllerBase
    {
        private readonly AppDBContext _context;
        public Login_Controller(AppDBContext context)  // dependency injection er maddhome database context ke inject kora hocche
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login_Model User)
        {
            var UserInfo = await _context.UserInfo
                .FirstOrDefaultAsync(x => x.Email == User.Email);

            if (UserInfo == null)
            {
                return NotFound();
            }

            if (UserInfo.Password != User.Password)
            {
                return NotFound();
            }

            return Ok($"Login Successful! Welcome {UserInfo.Name}!");
        }

    }
}