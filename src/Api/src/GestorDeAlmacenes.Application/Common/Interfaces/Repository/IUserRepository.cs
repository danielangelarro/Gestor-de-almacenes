using GestorDeAlmacenes.Application.Entities;

namespace GestorDeAlmacenes.Application.Common.Interfaces.Repository;

public interface IUserRepository
{
    Task<User?> GetUserByEmail(string email);
    void Add(User user);
}