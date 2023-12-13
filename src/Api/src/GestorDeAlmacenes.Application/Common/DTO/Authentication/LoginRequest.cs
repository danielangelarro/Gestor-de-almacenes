namespace GestorDeAlmacenes.Application.DTO.Authentication;

public record LoginRequest(
    string Email,
    string Password);