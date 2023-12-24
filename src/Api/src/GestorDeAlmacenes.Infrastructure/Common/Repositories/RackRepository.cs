using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestorDeAlmacenes.Infrastructure.Repositories;

public class RackRepository : IRackRepository
{
   private readonly GestorDeAlmacenesDBContext _context;

   public RackRepository(GestorDeAlmacenesDBContext context)
   {
       _context = context;
   }

   public async Task AddRackAsync(Rack rack)
   {
       _context.Racks.Add(rack);
       await _context.SaveChangesAsync();
   }

   public async Task DeleteRackAsync(Rack rack)
   {
       _context.Racks.Remove(rack);
       await _context.SaveChangesAsync();
   }

   public async Task<ICollection<Rack>> GetAllRacksAsync()
   {
       return await _context.Racks.ToListAsync();
   }

   public async Task<Rack> GetRackByIdAsync(Guid id)
   {
       return await _context.Racks.FindAsync(id);
   }

   public async Task UpdateRackAsync(Rack rack)
   {
       _context.Racks.Update(rack);
       await _context.SaveChangesAsync();
   }
}
