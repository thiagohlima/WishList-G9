using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wishlist.Domains;

namespace Wishlist.Interfaces
{
    interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);
        List<Usuario> Listar();
        Usuario BuscarPorId(int id);

    }
}
