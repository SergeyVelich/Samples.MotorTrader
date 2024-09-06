using Microsoft.AspNetCore.Mvc;

namespace Samples.MT.Portal.Api.Controllers;

[ApiController]
[Route("api/default")]
public class DefaultController : ControllerBase
{
    [HttpGet("Hello")]
    public ActionResult<string> HelloWorld(CancellationToken cancellationToken)
    {
        return "Hello, World!";
    }
}