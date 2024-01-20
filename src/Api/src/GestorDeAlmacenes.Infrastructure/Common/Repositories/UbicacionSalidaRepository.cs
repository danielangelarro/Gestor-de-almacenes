using System.Transactions;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestorDeAlmacenes.Infrastructure.Repositories;

public class UbicacionSalidaRepository : IUbicacionSalidaRepository
{
  private readonly GestorDeAlmacenesDBContext _context;

    public UbicacionSalidaRepository(GestorDeAlmacenesDBContext context)
    {
        _context = context;
    }

    public async Task AddUbicacionSalidaAsync(Ubicacion_Salida ubicacion_salida)
    {
        await _context.Ubicacion_Salidas.AddAsync(ubicacion_salida);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUbicacionsSalidaAsync(Ubicacion_Salida ubicacion_salida)
    {
        _context.Ubicacion_Salidas.Remove(ubicacion_salida);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Ubicacion_Salida>> GetAllUbicacionesSalidasBySalidaAsync(Guid salida)
    {
        return await _context.Ubicacion_Salidas.Where(us => us.ID_Salida == salida).ToListAsync();
    }
    
    public async Task<ICollection<Ubicacion_Salida>> GetAllUbicacionesSalidasAsync()
    {
        return await _context.Ubicacion_Salidas.ToListAsync();
    }
}