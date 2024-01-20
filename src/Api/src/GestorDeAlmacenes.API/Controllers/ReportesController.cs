using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.Racks.Query.GetReport;
using GestorDeAlmacenes.Application.DTO.Report;


namespace GestorDeAlmacenes.API.Controllers;

[Authorize]
[Route("report")]
public class ReporteController : ApiController
{
    private readonly ISender _mediator;

    public ReporteController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetReport()
    {
        var query = new GetReportQuery();

        ErrorOr<ReportResult> rackResultList = await _mediator.Send(query);
        
        return rackResultList.Match(
            result => Ok(rackResultList),
            errors => Problem(errors)
        );
    }
}