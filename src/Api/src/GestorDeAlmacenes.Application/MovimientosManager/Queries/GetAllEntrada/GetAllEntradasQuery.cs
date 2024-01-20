using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Entradas;
using MediatR;

namespace GestorDeAlmacenes.Application.Entradas.Query.GetAllEntradas;

public record GetAllEntradasQuery() : IRequest<ErrorOr<EntradaResultList>>;
