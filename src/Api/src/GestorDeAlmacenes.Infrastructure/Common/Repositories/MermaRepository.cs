using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestorDeAlmacenes.Infrastructure.Repositories
{
 public class MermaRepository : IMermaRepository
 {
    private readonly GestorDeAlmacenesDBContext _context;

    public MermaRepository(GestorDeAlmacenesDBContext context)
    {
        _context = context;
    }

    public async Task AddMermaAsync(Merma merma)
    {
        await _context.Mermas.AddAsync(merma);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteMermaAsync(Merma merma)
    {
        _context.Mermas.Remove(merma);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Merma>> GetAllMermasAsync()
    {
        return await _context.Mermas.ToListAsync();
    }

    public async Task<Merma> GetMermaByIdAsync(Guid id)
    {
        return await _context.Mermas.FindAsync(id);
    }

    public async Task UpdateMermaAsync(Merma merma)
    {
        _context.Mermas.Update(merma);
        await _context.SaveChangesAsync();
    }
 }
}
