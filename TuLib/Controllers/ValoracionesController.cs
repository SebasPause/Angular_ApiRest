using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class ValoracionesController : ControllerBase
    {
        private readonly Context _context;

        public ValoracionesController(Context context)
        {
            _context = context;
        }

        ///api/valoraciones/getbyid?bookId=10EC15DC-3CD9-4885-BCA9-9F3231977AD1
        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(Guid bookID)
        {
            List<Valoracion> valorations;
            List<CommentViewModel> valorationsList = new List<CommentViewModel>();
            CommentViewModel valoration;
            try
            {
                if (bookID == Guid.Empty && bookID == null)
                    return BadRequest("Invalid book id");
                valorations = _context.Valoraciones.Where(p => p.BookId == bookID).ToList();
                foreach (Valoracion item in valorations)
                {
                    valoration = new CommentViewModel();
                    valoration.ID = item.Id;
                    valoration.Valor = item.Valor;
                    valoration.bookID = item.BookId;
                    string contenido = System.Text.Encoding.UTF8.GetString(item.Comentario);
                    valoration.Comentario = contenido;
                    valorationsList.Add(valoration);
                }
                if (valorations == null)
                    return NotFound($"Book with id '{bookID}' does not exist");
                return new OkObjectResult(valorationsList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } //fin getById

        ///api/valoraciones
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Valoracion> valorations;
            List<CommentViewModel> valorationsList = new List<CommentViewModel>();
            CommentViewModel valoration;
            try
            {
                valorations = _context.Valoraciones.ToList();
                foreach (Valoracion item in valorations)
                {
                    valoration = new CommentViewModel();
                    valoration.ID = item.Id;
                    valoration.Valor = item.Valor;
                    valoration.bookID = item.BookId;
                    string contenido = System.Text.Encoding.UTF8.GetString(item.Comentario);
                    valoration.Comentario = contenido;
                    valorationsList.Add(valoration);
                }
                return new OkObjectResult(valorationsList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } //fin getAll

        [Authorize]
		[HttpDelete("deleteById")]
		public async Task<IActionResult> DeleteById(Guid Id)
		{
			try
			{
				Valoracion entity = null;
				entity = _context.Valoraciones.FirstOrDefault(a => a.Id == Id);

				if (entity == null)
					return NotFound($"Valoration with id '{Id}' does not exist");

				_context.Valoraciones.Remove(entity);
				_context.SaveChanges();
				
				return new OkObjectResult($"Valoration with id '{Id}' was deleted");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Insert([FromBody] CommentViewModelUserId model)
        {
            try
            {
                Valoracion valoracion = new Valoracion();
                valoracion.BookId = model.bookID;
                valoracion.Id = model.ID;
                valoracion.Valor = model.Valor;
                valoracion.IdUsuario = model.IdUsuario;
                valoracion.Comentario = Encoding.ASCII.GetBytes(model.Comentario);
                _context.Valoraciones.Add(valoracion);

                await _context.SaveChangesAsync();

                String message = "ha funcionado"; 
                //return new OkObjectResult(' ');
                return Ok(new { message });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
