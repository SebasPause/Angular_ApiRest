using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuLib.Model;
using TuLib.Model.Entities;
using TuLib.ViewModels.OtherViewModels;

namespace TuLib.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly Context _context;

        public UserProfileController(UserManager<ApplicationUser> userManager,Context context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        [Authorize]
        //GET : /api/UserProfile
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
                user.Id,
                user.FullName,
                user.Email,
                user.UserName,
                user.Age,
                user.Description,
                user.Image
            };
        }

        [Authorize]
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UsuarioViewModel model)
        {
            try
            {
                var entity = _context.ApplicationUsers.FirstOrDefault(a => a.Id == model.id);
                entity.Age = model.age;
                entity.FullName = model.fullName;
                entity.Description = model.description;
                entity.Image = model.image;

                await _context.SaveChangesAsync();
                String message = "ha funcionado";
                return Ok(new { message });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
