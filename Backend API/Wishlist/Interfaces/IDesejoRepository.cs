using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wishlist.Domains;

namespace Wishlist.Interfaces
{
    interface IDesejoRepository
    {
        List<Desejo> Listar();
        List<Desejo> ListarTudo();
        Desejo BuscarPorId(int id);
        void Cadastrar(Desejo NovoDesejo);
        void Deletar(int id);
    }
}
