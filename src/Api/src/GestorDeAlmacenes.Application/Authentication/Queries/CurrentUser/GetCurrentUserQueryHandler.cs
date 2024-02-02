using System.Data;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.Common.Interfaces.Services;
using GestorDeAlmacenes.Application.Services;
using GestorDeAlmacenes.Application.DTO.Authentication;

namespace GestorDeAlmacenes.Application.Entradas.Commands.CurrentUser;

public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IMovimientoRepository _movimientoRepository;
    private readonly IProductoRepository _productoRepository;
    private readonly IProveedorRepository _proveedorRepository;
    private readonly IRackRepository _rackRepository;
    private readonly IUbicacionRepository _ubicacionRepository;
    private readonly ICasilleroRepository _casilleroRepository;
    private readonly IDateTimeProvider dateTimeProvider;
    private readonly IGetCurrentUserLoginService _getCurrentUserLoginService;

    public GetCurrentUserQueryHandler(
        IProductoRepository productoRepository,
        IMovimientoRepository movimientoRepository,
        IProveedorRepository proveedorRepository,
        IRackRepository rackRepository,
        IUbicacionRepository ubicacionRepository,
        ICasilleroRepository casilleroRepository,
        IGetCurrentUserLoginService getCurrentUserLoginService)
    {
        _productoRepository = productoRepository;
        _movimientoRepository = movimientoRepository;
        _proveedorRepository = proveedorRepository;
        _rackRepository = rackRepository;
        _ubicacionRepository = ubicacionRepository;
        _casilleroRepository = casilleroRepository;
        _getCurrentUserLoginService = getCurrentUserLoginService;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(GetCurrentUserQuery command, CancellationToken cancellationToken)
    {
        if (await _getCurrentUserLoginService.Handle(command.Token) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        return new AuthenticationResult(
            user, 
            command.Token
        );
    }
}
