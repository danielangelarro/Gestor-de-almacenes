using GestorDeAlmacenes.Application.Entities;

namespace GestorDeAlmacenes.Application.Services;

public interface IGetCurrentUserLoginService
{
    Task<User> Handle(string token);
}