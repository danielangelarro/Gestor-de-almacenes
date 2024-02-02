using ErrorOr;
using MediatR;
using Aspose.Pdf;

namespace GestorDeAlmacenes.Application.Entradas.Query.GetAllRacksReport;

public record GetAllRacksReportQuery() : IRequest<ErrorOr<Document>>;
