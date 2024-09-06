using Ardalis.Result.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Samples.MT.Platform.Models.Requests;
using Samples.MT.Platform.Models.Responses;
using Samples.MT.Platform.Services.Abstractions;
using Swashbuckle.AspNetCore.Annotations;

namespace Samples.MT.Platform.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserManagementService _userManagementService;
    private readonly ILogger _logger;

    public UsersController(IUserManagementService userManagementService, ILoggerFactory loggerFactory)
    {
        _userManagementService = userManagementService;
        _logger = loggerFactory.CreateLogger(GetType().ToString());
    }

    [HttpGet("{id:guid}")]
    [ActionName(nameof(GetUserByIdAsync))]
    [SwaggerOperation(Summary = "Gets user by Id")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<UserResponse>> GetUserByIdAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var result = await _userManagementService.GetUserByIdAsync(id, cancellationToken);

        return this.ToActionResult(result);
    }

    [HttpGet]
    [ActionName(nameof(GetUsersAsync))]
    [SwaggerOperation(Summary = "Gets users")]
    [ProducesResponseType(typeof(List<UserResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<UserResponse>>> GetUsersAsync(CancellationToken cancellationToken)
    {
        var result = await _userManagementService.GetUsersAsync(cancellationToken);

        return this.ToActionResult(result);
    }

    [HttpPost("new")]
    [ActionName(nameof(CreateUserAsync))]
    [SwaggerOperation(Summary = "Creates user")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<UserResponse>> CreateUserAsync([FromBody] UserCreateRequest request, CancellationToken cancellationToken)
    {
        var result = await _userManagementService.CreateUserAsync(request, cancellationToken);

        return this.ToActionResult(result);
    }

    [HttpPut("{id:guid}")]
    [ActionName(nameof(UpdateUserAsync))]
    [SwaggerOperation(Summary = "Updates user")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]//TODO 200 or 201?
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<UserResponse>> UpdateUserAsync([FromRoute] Guid id, [FromBody] UserUpdateRequest request, CancellationToken cancellationToken)
    {
        var result = await _userManagementService.UpdateUserAsync(id, request, cancellationToken);

        return this.ToActionResult(result);
    }

    [HttpDelete("{id:guid}")]
    [ActionName(nameof(DeleteUserAsync))]
    [SwaggerOperation(Summary = "Deletes user")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteUserAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var result = await _userManagementService.DeleteUserAsync(id, cancellationToken);

        return this.ToActionResult(result);
    }
}