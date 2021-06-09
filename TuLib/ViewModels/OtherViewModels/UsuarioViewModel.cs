using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuLib.Model.Entities;

namespace TuLib.ViewModels.OtherViewModels
{
    public class UsuarioViewModel
    {
        public Guid id { get; set; }
        public string fullName { get; set; }
        public string description { get; set; }
        public int age { get; set; }
        public string image { get; set; }
    }
}
