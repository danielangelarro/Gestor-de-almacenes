using GestorDeAlmacenes.Application.Common.Interfaces.Repository;
using GestorDeAlmacenes.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestorDeAlmacenes.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    public readonly GestorDeAlmacenesDBContext _context;

    public UserRepository(GestorDeAlmacenesDBContext context)
    {
        _context = context;
    }

    public async void Add(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetUserById(Guid id)
    {
        return await _context.Users.FirstOrDefaultAsync(user => user.ID_User == id);
    }
    
    public async Task<User?> GetUserByEmail(string email)
    {
        return await _context.Users.SingleOrDefaultAsync(user => user.Correo == email);
    }
}