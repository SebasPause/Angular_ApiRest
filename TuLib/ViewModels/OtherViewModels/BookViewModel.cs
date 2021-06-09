using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuLib.Model.Entities;

namespace TuLib.ViewModels.OtherViewModels
{
    public class BookViewModel
    {
        public Guid ApplicationUserId { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Descripcion { get; set; }
        public string FechaPublicado { get; set; }
        public string Estado { get; set; }
        public bool Publicado { get; set; }
        public string Photo { get; set; }
        public int nrPaginas { get; set; }
        public Guid bookID { get; set; }
    }
}
