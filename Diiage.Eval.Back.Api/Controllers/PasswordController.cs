using Diiage.Eval.Back.Api.Models;
using Diiage.Eval.Back.Api.Models.Requests;
using Diiage.Eval.Back.Api.Models.Responses;
using Diiage.Eval.Back.Application.Contracts;
using Diiage.Eval.Back.Domain.Models.Passwords;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Diiage.Eval.Back.Api.Controllers;

public class PasswordController(IPasswordService passwordService, IMapper mapper) : ControllerBase
{
    [HttpPost(ApiRoutes.Passwords.BaseRoute)]
    public async Task<ActionResult<ApplicationResponse>> CreatePassword([FromBody] CreatePasswordRequest request,
        CancellationToken cancellationToken)
    {
        var application =
            await passwordService.CreatePassword(request.Password, request.ApplicationId, cancellationToken);

        return Ok(mapper.Map<PasswordBl, PasswordResponse>(application));
    }

    [HttpGet(ApiRoutes.Passwords.BaseRoute)]
    public async Task<ActionResult<List<ApplicationResponse>>> GetPasswords(CancellationToken cancellationToken)
    {
        var application =
            await passwordService.GetPasswords(cancellationToken);

        return Ok(mapper.Map<List<PasswordBl>, List<PasswordResponse>>(application));
    }

    [HttpDelete(ApiRoutes.Passwords.ById)]
    public async Task<ActionResult<List<ApplicationResponse>>> DeletePassword([FromRoute] int id,
        CancellationToken cancellationToken)
    {
        await passwordService.DeletePassword(id, cancellationToken);

        return Ok();
    }
}