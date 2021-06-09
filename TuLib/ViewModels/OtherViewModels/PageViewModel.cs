using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuLib.ViewModels.OtherViewModels
{
    public class PageViewModel
    {
        public Guid ID { get; set; }
        public Guid BookId { get; set; }
        public int nrPagina { get; set; }
        public string Contenido { get; set; }
    }
}
