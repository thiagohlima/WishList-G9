using System;
using System.Collections.Generic;

#nullable disable

namespace Wishlist.Domains
{
    public partial class Desejo
    {
        public int IdDesejo { get; set; }
        public string NomeDesejo { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
