using System;
using System.Collections.Generic;
using System.Text;

namespace TuLib.Model.Entities
{
    public class Page : Base
    {
        public Guid BookId { get; set; }
        public virtual Book Book { get; set; }
        public int NrPagina { get; set; }
        public byte[] Contenido { get; set; }
    }
}
