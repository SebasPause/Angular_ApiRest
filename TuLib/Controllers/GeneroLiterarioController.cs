using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuLib.Model;
using TuLib.Model.Entities;
using TuLib.ViewModels.OtherViewModels;

namespace TuLib.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroLiterarioController : ControllerBase
    {
        private readonly Context _context;

        public GeneroLiterarioController(Context context)
        {
            _context = context;
        }

        //api/generoliterario
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<GeneroLiterario> genero;
            List<GeneroLiterarioViewModel> generoLiterarioList = new List<GeneroLiterarioViewModel>();
            GeneroLiterarioViewModel generoLiterario;
            try
            {
                genero = _context.GenerosLiterarios.ToList();
                foreach (GeneroLiterario item in genero)
                {
                    generoLiterario = new GeneroLiterarioViewModel();
                    generoLiterario.ID = item.Id;
                    generoLiterario.bookId = item.BookId;
                    generoLiterario.Genero = item.Genero;
                    generoLiterarioList.Add(generoLiterario);

                }
                return new OkObjectResult(generoLiterarioList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } //fin getAll

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Insert([FromBody] GeneroLiterarioViewModel model)
        {
            try
            {
                GeneroLiterario generoLiterario = new GeneroLiterario();
                generoLiterario.Id = model.ID;
                generoLiterario.BookId = model.bookId;
                generoLiterario.Genero = model.Genero;
                _context.GenerosLiterarios.Add(generoLiterario);

                await _context.SaveChangesAsync();

                String message = "ha funcionado";
                return Ok(new { message });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("actualizarGenero")]
        public async Task<IActionResult> Update([FromBody] GeneroLiterarioViewModel model)
        {
            try
            {
                var entity = _context.GenerosLiterarios.FirstOrDefault(a => a.BookId == model.bookId);
                entity.Genero = model.Genero;

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
