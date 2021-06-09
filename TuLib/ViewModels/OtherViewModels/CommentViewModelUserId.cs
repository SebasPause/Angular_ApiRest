using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuLib.ViewModels.OtherViewModels
{
    public class CommentViewModelUserId
    {
        public Guid ID { get; set; }
        public Guid bookID { get; set; }
        public Guid IdUsuario { get; set; }
        public int Valor { get; set; }
        public string Comentario { get; set; }
    }
}
