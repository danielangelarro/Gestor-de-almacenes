using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestorDeAlmacenes.Infrastructure.Repositories;

public class SalidaRepository : ISalidaRepository
{
    private readonly GestorDeAlmacenesDBContext _context;

    public SalidaRepository(GestorDeAlmacenesDBContext context)
    {
        _context = context;
    }

    public async Task AddSalidaAsync(Salida salida)
    {
        await _context.Salidas.AddAsync(salida);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSalidaAsync(Salida salida)
    {
        _context.Salidas.Remove(salida);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Salida>> GetAllSalidasAsync()
    {
        return await _context.Salidas.ToListAsync();
    }

    public async Task<Salida> GetSalidaByIdAsync(Guid id)
    {
        return await _context.Salidas.FindAsync(id);
    }

    public async Task UpdateSalidaAsync(Salida salida)
    {
        _context.Salidas.Update(salida);
        await _context.SaveChangesAsync();
    }
}