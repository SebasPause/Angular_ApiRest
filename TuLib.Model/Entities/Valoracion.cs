using System;
using System.Collections.Generic;
using System.Text;

namespace TuLib.Model.Entities
{
    public class Valoracion : Base
    {
        public Guid BookId { get; set; }
        public virtual Book Book { get; set; }
        public Guid IdUsuario { get; set; }
        public int Valor { get; set; }
        public byte[] Comentario { get; set; }
    }
}
 