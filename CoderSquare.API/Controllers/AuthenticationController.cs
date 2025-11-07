namespace CoderSquare.API.Controllers;
public class AuthenticationController(IAuthenticationService authenticationService)
    : ApiController
{
    [HttpPost("Login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await authenticationService.LoginAsync(loginDto);
        return Ok(user);
    }
    [HttpPost("Register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        var user = await authenticationService.RegisterAsync(registerDto);
        return Ok(user);
    }
    [Authorize]
    [HttpGet("CurrentUser")]
    public async Task<ActionResult<UserDto>> GetCurrentUser()
    {
        var user = await authenticationService.GetCurrentUserAsync(GetEmailFromToken());
        return Ok(user);
    }
    [HttpGet("CheckEmail")]
    public async Task<ActionResult<bool>> CheckEmail([FromQuery] string email)
    {
        var result = await authenticationService.CheckEmailAsync(email);
        return Ok(result);
    }
}
