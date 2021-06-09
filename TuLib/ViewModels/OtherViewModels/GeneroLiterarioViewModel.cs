using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuLib.ViewModels.OtherViewModels
{
    public class GeneroLiterarioViewModel
    {
        public Guid ID { get; set; }
        public Guid bookId { get; set; }
        public string Genero { get; set; }
    }
}
