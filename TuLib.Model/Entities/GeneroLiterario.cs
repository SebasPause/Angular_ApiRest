using System;
using System.Collections.Generic;
using System.Text;

namespace TuLib.Model.Entities
{
    public class GeneroLiterario : Base
    {
        public Guid BookId { get; set; }
        public virtual Book Book { get; set; }
        public string Genero { get; set; } 
    }
}
