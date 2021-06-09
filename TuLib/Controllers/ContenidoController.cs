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
    public class ContenidoController : ControllerBase
    {
        private readonly Context _context;

        public ContenidoController(Context context)
        {
            _context = context;
        }

        ///api/contenido/getbyid?bookId=10EC15DC-3CD9-4885-BCA9-9F3231977AD1
        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(Guid bookID)
        {
            List<Page> pages;
            List<PageViewModel> pagesList = new List<PageViewModel>();
            PageViewModel page;
            try
            {
                if (bookID == Guid.Empty && bookID == null)
                    return BadRequest("Invalid book id");
                pages = _context.Pages.Where(p => p.BookId == bookID).OrderBy(c => c.NrPagina).ToList();
                foreach(Page item in pages)
                {
                    page = new PageViewModel();
                    page.ID = item.Id;
                    page.BookId = item.BookId;
                    page.nrPagina = item.NrPagina;
                    string contenido = System.Text.Encoding.UTF8.GetString(item.Contenido);
                    page.Contenido = contenido;
                    pagesList.Add(page);
                }
                if (pages == null)
                    return NotFound($"Book with id '{bookID}' does not exist");
                return new OkObjectResult(pagesList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        ///api/contenido
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Page> pages;
            List<PageViewModel> pagesList = new List<PageViewModel>();
            PageViewModel page;
            try
            {
                pages = _context.Pages.ToList();
                foreach (Page item in pages)
                {
                    page = new PageViewModel();
                    page.ID = item.Id;
                    page.BookId = item.BookId;
                    page.nrPagina = item.NrPagina;
                    string contenido = System.Text.Encoding.UTF8.GetString(item.Contenido);
                    page.Contenido = contenido;
                    pagesList.Add(page);
                }
                return new OkObjectResult(pagesList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("insertPrimeraPagina")]
        public async Task<IActionResult> Insert([FromBody] PageViewModel model)
        {
            try
            {
                Page page = new Page();
                page.Id = model.ID;
                page.BookId = model.BookId;
                page.NrPagina = model.nrPagina;
                page.Contenido = Encoding.UTF8.GetBytes(model.Contenido);
                _context.Pages.Add(page);

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
        [HttpPut("actualizarPagina")]
        public async Task<IActionResult> actualizarPagina([FromBody] PageViewModel model)
        {
            try
            {
                var entity = _context.Pages.FirstOrDefault(a => (a.BookId == model.BookId && a.NrPagina == model.nrPagina));
                entity.Contenido = Encoding.UTF8.GetBytes(model.Contenido);

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
