using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestorDeAlmacenes.Infrastructure.Repositories
{
   public class CasilleroRepository : ICasilleroRepository
   {
       private readonly GestorDeAlmacenesDBContext _context;

       public CasilleroRepository(GestorDeAlmacenesDBContext context)
       {
           _context = context;
       }

       public async Task AddCasilleroAsync(Casillero casillero)
       {
           await _context.Casilleros.AddAsync(casillero);
           await _context.SaveChangesAsync();
       }

       public async Task DeleteCasilleroAsync(Casillero casillero)
       {
           _context.Casilleros.Remove(casillero);
           await _context.SaveChangesAsync();
       }

       public async Task<ICollection<Casillero>> GetAllCasillerosAsync()
       {
           return await _context.Casilleros.ToListAsync();
       }

        public async Task<ICollection<Casillero>> GetAllCasillerosByIdAsync(ICollection<Guid> guids)
        {
            return await _context.Casilleros.Where(c => guids.Contains(c.ID_Casillero)).ToListAsync();
        }

        public async Task<Casillero> GetCasilleroByIdAsync(Guid id)
       {
           return await _context.Casilleros.FindAsync(id);
       }

       public async Task UpdateCasilleroAsync(Casillero casillero)
       {
           _context.Casilleros.Update(casillero);
           await _context.SaveChangesAsync();
       }
   }
}
