using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Entradas;
using MediatR;
using Aspose.Pdf;

namespace GestorDeAlmacenes.Application.Entradas.Query.GetAllEntradaReport;

public record GetAllEntradasReportQuery() : IRequest<ErrorOr<Document>>;
