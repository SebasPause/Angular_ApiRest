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
    public class BookController : ControllerBase
    {
        private readonly Context _context;


        public BookController(Context context) 
        {
            _context = context;
        }

        //api/book
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Book> libros;
            List<BookViewModel> librosList = new List<BookViewModel>();
            BookViewModel books;
            try
            {
                libros = _context.Books.ToList();
                foreach(Book item in libros)
                {
                    books = new BookViewModel();
                    books.ApplicationUserId = item.ApplicationUserId;
                    string descripcion = System.Text.Encoding.UTF8.GetString(item.Descripcion);
                    books.Descripcion = descripcion;
                    books.Autor = item.Autor;
                    books.FechaPublicado = item.FechaPublicado;
                    books.Publicado = item.Publicado;
                    books.Photo = item.Photo;
                    books.Titulo = item.Titulo;
                    books.nrPaginas = item.Pages.Count;
                    books.bookID = item.Id;
                    books.Estado = item.Estado;
                    if(!books.Estado.Equals("Sin Publicar"))
                    {
                        librosList.Add(books);
                    }

                    
                }
                return new OkObjectResult(librosList);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } //fin getAll

        //api/book
        [Authorize]
        [HttpGet("todos")]
        public async Task<IActionResult> GetAllBooks()
        {
            List<Book> libros;
            List<BookViewModel> librosList = new List<BookViewModel>();
            BookViewModel books;
            try
            {
                libros = _context.Books.ToList();
                foreach (Book item in libros)
                {
                    books = new BookViewModel();
                    books.ApplicationUserId = item.ApplicationUserId;
                    string descripcion = System.Text.Encoding.UTF8.GetString(item.Descripcion);
                    books.Descripcion = descripcion;
                    books.Autor = item.Autor;
                    books.FechaPublicado = item.FechaPublicado;
                    books.Publicado = item.Publicado;
                    books.Photo = item.Photo;
                    books.Titulo = item.Titulo;
                    books.nrPaginas = item.Pages.Count;
                    books.bookID = item.Id;
                    books.Estado = item.Estado;
                    librosList.Add(books);

                }
                return new OkObjectResult(librosList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } //fin getAll

        [Authorize]
		[HttpPut("update")]
		public async Task<IActionResult> Update([FromBody] BookViewModel model)
		{
			try
			{
				var entity = _context.Books.FirstOrDefault(a => a.Id == model.bookID);
				entity.Publicado = model.Publicado;
                entity.Estado = model.Estado;
                if(model.Estado.Equals("Sin Publicar"))
                {
                    entity.FechaPublicado = "";
                }
                else
                {
                    entity.FechaPublicado = model.FechaPublicado;
                }

                await _context.SaveChangesAsync();

                String message = "ha funcionado";
                return Ok(new { message });
            }
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Insert([FromBody] BookViewModel model)
        {
            try
            {
                Book libro = new Book();
                libro.Id = model.bookID;
                libro.ApplicationUserId = model.ApplicationUserId;
                libro.Titulo = model.Titulo;
                libro.Autor = model.Autor;
                libro.Descripcion = Encoding.ASCII.GetBytes(model.Descripcion);
                libro.Estado = model.Estado;
                libro.Publicado = model.Publicado;
                libro.Photo = model.Photo;
                _context.Books.Add(libro);

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
        [HttpPut("actualizarInfo")]
        public async Task<IActionResult> ActualizarInfo([FromBody] BookViewModel model)
        {
            try
            {
                var entity = _context.Books.FirstOrDefault(a => a.Id == model.bookID);
                entity.Photo = model.Photo;
                entity.Titulo = model.Titulo;
                entity.Autor = model.Autor;
                entity.Descripcion = Encoding.ASCII.GetBytes(model.Descripcion);

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
        [HttpDelete("deleteById")]
        public async Task<IActionResult> DeleteById(Guid Id)
        {
            try
            {
                Book entity = null;
                entity = _context.Books.FirstOrDefault(a => a.Id == Id);

                _context.Books.Remove(entity);
                _context.SaveChanges();

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
