using GestorDeAlmacenes.Application.Entities;

namespace GestorDeAlmacenes.Application.DTO.Authentication;

public record AuthenticationResult(User user, string Token);