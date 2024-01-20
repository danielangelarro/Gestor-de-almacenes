using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Report;
using MediatR;

namespace GestorDeAlmacenes.Application.Racks.Query.GetReport;

public record GetReportQuery() : IRequest<ErrorOr<ReportResult>>;
