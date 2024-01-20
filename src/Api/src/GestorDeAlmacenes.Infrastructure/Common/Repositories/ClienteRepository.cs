using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestorDeAlmacenes.Infrastructure.Repositories
{
  public class ClienteRepository : IClienteRepository
  {
      private readonly GestorDeAlmacenesDBContext _context;

      public ClienteRepository(GestorDeAlmacenesDBContext context)
      {
          _context = context;
      }

      public async Task AddClienteAsync(Cliente cliente)
      {
          await _context.Clientes.AddAsync(cliente);
          await _context.SaveChangesAsync();
      }

      public async Task DeleteClienteAsync(Cliente cliente)
      {
          _context.Clientes.Remove(cliente);
          await _context.SaveChangesAsync();
      }

      public async Task<ICollection<Cliente>> GetAllClientesAsync()
      {
          return await _context.Clientes.ToListAsync();
      }

      public async Task<Cliente> GetClienteByIdAsync(Guid id)
      {
          return await _context.Clientes.FindAsync(id);
      }

        public async Task<int> GetClienteCountAsync()
        {
            return await _context.Clientes.CountAsync();
        }

        public async Task UpdateClienteAsync(Cliente cliente)
      {
          _context.Clientes.Update(cliente);
          await _context.SaveChangesAsync();
      }
  }
}
