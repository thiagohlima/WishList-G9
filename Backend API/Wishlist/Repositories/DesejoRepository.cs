using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wishlist.Contexts;
using Wishlist.Domains;
using Wishlist.Interfaces;

namespace Wishlist.Repositories
{
    public class DesejoRepository : IDesejoRepository
    {
        WishlistContext ctx = new WishlistContext();
        public Desejo BuscarPorId(int id)
        {
            return ctx.Desejos.FirstOrDefault(e => e.IdDesejo == id);
        }

        public void Cadastrar(Desejo NovoDesejo)
        {
            ctx.Add(NovoDesejo);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Desejo DesejoBuscado = ctx.Desejos.Find(id);
            ctx.Desejos.Remove(DesejoBuscado);
            ctx.SaveChanges();
        }

        public List<Desejo> Listar()
        {
            return ctx.Desejos.ToList();
        }

        public List<Desejo> ListarTudo()
        {
            return ctx.Desejos
                   .Include(d => d.IdUsuarioNavigation)
                   .ToList();
        }
    }
}
