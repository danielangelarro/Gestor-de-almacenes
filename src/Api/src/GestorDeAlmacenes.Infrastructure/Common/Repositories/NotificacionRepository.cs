using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestorDeAlmacenes.Infrastructure.Repositories
{
    public class NotificacionRepository : INotificacionRepository
    {
        private readonly GestorDeAlmacenesDBContext _context;

        public NotificacionRepository(GestorDeAlmacenesDBContext context)
        {
            _context = context;
        }

        public async Task AddNotificacionAsync(Notificacion notificacion)
        {
            await _context.Notificaciones.AddAsync(notificacion);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNotificacionAsync(Notificacion notificacion)
        {
            _context.Notificaciones.Remove(notificacion);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Notificacion>> GetAllNotificacionsAsync()
        {
            return await _context.Notificaciones.ToListAsync();
        }

        public async Task<Notificacion> GetNotificacionByIdAsync(Guid id)
        {
            return await _context.Notificaciones.FindAsync(id);
        }

        public async Task<ICollection<Notificacion>> GetAllNotificacionesByUserAsync(Guid ID_Usuario)
        {
            return await _context.Notificaciones.Where(n => n.ID_Usuario == ID_Usuario).ToListAsync();
        }

        public async Task AddDiffusionNotificacionAsync(string Mensaje, string Tipo, DateTime Fecha)
        {
            var users = await _context.Users.ToListAsync();

            foreach (var user in users)
            {
                _context.Notificaciones.AddAsync(new Notificacion {
                    ID_Notificacion = Guid.NewGuid(),
                    ID_Usuario = user.ID_User,
                    Description = Mensaje,
                    Tipo = Tipo,
                    Fecha = Fecha
                });
            }
        }
    }
}
