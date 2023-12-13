using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestorDeAlmacenes.Infrastructure.Repositories;

public class UbicacionRepository : IUbicacionRepository
{
  private readonly GestorDeAlmacenesDBContext _context;

    public UbicacionRepository(GestorDeAlmacenesDBContext context)
    {
        _context = context;
    }

    public async Task AddUbicacionAsync(Ubicacion ubicacion)
    {
        await _context.Ubicaciones.AddAsync(ubicacion);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUbicacionAsync(Ubicacion ubicacion)
    {
        _context.Ubicaciones.Remove(ubicacion);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Ubicacion>> GetAllUbicacionesAsync()
    {
        return await _context.Ubicaciones.ToListAsync();
    }

    public async Task<Ubicacion> GetUbicacionByIdAsync(Guid id)
    {
        return await _context.Ubicaciones.FindAsync(id);
    }

    public async Task UpdateUbicacionAsync(Ubicacion ubicacion)
    {
        _context.Ubicaciones.Update(ubicacion);
        await _context.SaveChangesAsync();
    }
}