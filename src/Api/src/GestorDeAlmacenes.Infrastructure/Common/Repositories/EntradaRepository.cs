using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestorDeAlmacenes.Infrastructure.Repositories
{
 public class EntradaRepository : IEntradaRepository
 {
     private readonly GestorDeAlmacenesDBContext _context;

     public EntradaRepository(GestorDeAlmacenesDBContext context)
     {
         _context = context;
     }

     public async Task AddEntradaAsync(Entrada entrada)
     {
         await _context.Entradas.AddAsync(entrada);
         await _context.SaveChangesAsync();
     }

     public async Task DeleteEntradaAsync(Entrada entrada)
     {
         _context.Entradas.Remove(entrada);
         await _context.SaveChangesAsync();
     }

     public async Task<ICollection<ITransaction>> GetAllEntradasAsync()
     {
         return await (_context.Entradas).Select(e => (ITransaction)e ).ToListAsync();
     }

     public async Task<Entrada> GetEntradaByIdAsync(Guid id)
     {
         return await _context.Entradas.FindAsync(id);
     }

     public async Task UpdateEntradaAsync(Entrada entrada)
     {
         _context.Entradas.Update(entrada);
         await _context.SaveChangesAsync();
     }
 }
}
