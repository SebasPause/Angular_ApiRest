using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TuLib.Model.Entities
{
    public class Book : Base
    {
        public Guid ApplicationUserId { get; set; }
        //Usando virtual y  el nombre de la clase, se crea la relacion foreign key
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public byte[] Descripcion { get; set; }
        public string FechaPublicado { get; set; }
        public string Estado { get; set; }
        public bool Publicado { get; set; } 
        public string Photo { get; set; }
        public virtual ICollection<GeneroLiterario> Generos { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
        public virtual ICollection<Valoracion> Valoraciones { get; set; }
    }
}
