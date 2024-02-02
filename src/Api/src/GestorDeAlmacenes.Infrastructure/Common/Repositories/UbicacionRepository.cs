using System.Transactions;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace GestorDeAlmacenes.Infrastructure.Repositories;

public class UbicacionRepository : IUbicacionRepository
{
  private readonly GestorDeAlmacenesDBContext _context;
  private DateTimeProvider _dateTimeProvider;

    public UbicacionRepository(GestorDeAlmacenesDBContext context)
    {
        _context = context;
        _dateTimeProvider = new DateTimeProvider();
    }

    public async Task AddUbicacionAsync(Ubicacion ubicacion)
    {
        if (await _context.Ubicaciones.Where(u => 
            u.ID_Producto == ubicacion.ID_Producto && u.ID_Casillero == ubicacion.ID_Casillero &&
            u.Fecha_Llegada == ubicacion.Fecha_Llegada && u.Fecha_Caducidad == ubicacion.Fecha_Caducidad
            ).FirstOrDefaultAsync() is Ubicacion ubicacion_exist)
        {
            ubicacion_exist.Cantidad += ubicacion.Cantidad;
            
            _context.Ubicaciones.Update(ubicacion_exist);
        }
        else
        {
            await _context.Ubicaciones.AddAsync(ubicacion);
        }

        await _context.SaveChangesAsync();
    }

    public async Task DeleteUbicacionAsync(Ubicacion ubicacion)
    {
        _context.Ubicaciones.Remove(ubicacion);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Ubicacion>> GetAllUbicacionesAsync()
    {
        return await _context.Ubicaciones.ToListAsync();
    }

    public async Task<ICollection<Ubicacion>> GetAllUbicacionesByCasilleroAsync(Guid iD_Casillero)
    {
        return await _context.Ubicaciones.Where(u => u.ID_Casillero == iD_Casillero).ToListAsync();
    }

    public async Task<ICollection<Ubicacion>> GetAllUbicacionesByProductoAsync(Guid iD_Producto)
    {
        return await _context.Ubicaciones.Where(u => u.ID_Producto == iD_Producto).ToListAsync();
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

    #region Servicios

    public async Task<ICollection<Ubicacion>> CheckedCaduceDateProductService()
    {
        var ubicaciones = await _context.Ubicaciones.ToListAsync();
        var today = _dateTimeProvider.UtcNow.Date;
        List<Ubicacion> mermas = new List<Ubicacion>();

        if (await _context.Racks.Where(rack => rack.Type == "wait").FirstOrDefaultAsync() is not Rack rack_wait)
        {
            return mermas;
        }

        if (await _context.Casilleros.Where(c => c.ID_Rack == rack_wait.ID_Rack).FirstOrDefaultAsync() is not Casillero casillero_wait)
        {
            return mermas;
        }

        foreach (var ubicacion in ubicaciones)
        {
            if (ubicacion.ID_Casillero != casillero_wait.ID_Casillero)
            {
                if (ubicacion.Fecha_Caducidad.Date <= today)
                {
                    mermas.Add(ubicacion);
                }
            }
        }

        return mermas;
    }

    #endregion
}