using GestorDeAlmacenes.Application.Entities;

namespace GestorDeAlmacenes.Application.Common.Interfaces;

public interface IClienteRepository
{
  Task<Cliente> GetClienteByIdAsync(Guid id);
  Task<ICollection<Cliente>> GetAllClientesAsync();
  Task AddClienteAsync(Cliente cliente);
  Task UpdateClienteAsync(Cliente cliente);
  Task DeleteClienteAsync(Cliente cliente);
}