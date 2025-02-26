using Diiage.Eval.Back.Api.Models;
using Diiage.Eval.Back.Api.Models.Requests;
using Diiage.Eval.Back.Api.Models.Responses;
using Diiage.Eval.Back.Application.Contracts;
using Diiage.Eval.Back.Domain.Models.Applications;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diiage.Eval.Back.Api.Controllers;

public class ApplicationController(IApplicationService applicationService, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Create an application.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The created application.</returns>
    [HttpPost(ApiRoutes.Applications.BaseRoute)]
    public async Task<ActionResult<ApplicationResponse>> CreateApplication([FromBody] CreateApplicationRequest request,
        CancellationToken cancellationToken)
    {
        var application = await applicationService.CreateApplicationAsync(request.Name, request.ApplicationType, cancellationToken);

        return Ok(mapper.Map<ApplicationBl, ApplicationResponse>(application));
    }

    /// <summary>
    /// Get all applications.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The applications.</returns>
    [HttpGet(ApiRoutes.Applications.BaseRoute)]
    public async Task<ActionResult<List<ApplicationResponse>>> GetApplications(CancellationToken cancellationToken)
    {
        var application = await applicationService.GetApplicationsAsync(cancellationToken);

        return Ok(mapper.Map<List<ApplicationBl>, List<ApplicationResponse>>(application));
    }
}