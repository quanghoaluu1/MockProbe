using MockProbe.Application.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MockProbe.Api.Controllers;

[ApiController]
[Route("api/system")]
public sealed class SystemController : ControllerBase
{
    [HttpGet("config")]
    public ActionResult<SystemConfigResponse> GetConfig(IOptions<AuthOptions> authOptions)
    {
        return Ok(new SystemConfigResponse(authOptions.Value.Mode));
    }
}
