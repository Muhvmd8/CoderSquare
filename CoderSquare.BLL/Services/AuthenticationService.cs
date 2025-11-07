namespace CoderSquare.BLL.Services;
public class AuthenticationService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
    : IAuthenticationService
{
    public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
    {
        var user = new ApplicationUser
        {
            Email = registerDto.Email,
            UserName = registerDto.Username,
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            PhoneNumber = registerDto.PhoneNumber
        };

        var result = await userManager.CreateAsync(user, registerDto.Password);

        if (result.Succeeded)
            return new UserDto
            {
                Email = registerDto.Email,
                DisplayName = $"{registerDto.FirstName} {registerDto.LastName}",
                Token = await _CreateTokenAsync(user)
            };
        else
        {
            var errors = result.Errors.Select(e => e.Description).ToList();
            throw new BadRequestException(errors);
        }
    }
    public async Task<UserDto> LoginAsync(LoginDto loginDto)
    {
        // Check if email is exists
        var user = await userManager.FindByEmailAsync(loginDto.Email) ?? 
            throw new UserNotFoundException(loginDto.Email);

        // Check password
        var isValidPassword = await userManager.CheckPasswordAsync(user, loginDto.Password);
        // return UserDto
        if (isValidPassword)
            return new UserDto
            {
                Email = loginDto.Email,
                DisplayName = $"{user.FirstName} {user.LastName}",
                Token = await _CreateTokenAsync(user)
            };
        else
            throw new UnauthorizedException();
    }
    public async Task<bool> CheckEmailAsync(string email)
    {
        var user = await userManager.FindByEmailAsync(email);
        return user is not null;
    }
    public async Task<UserDto> GetCurrentUserAsync(string email)
    {
        var user = await userManager.FindByEmailAsync(email)?? 
            throw new UserNotFoundException(email);

        return new UserDto
        {
            Email = email,
            DisplayName = $"{user.FirstName} {user.LastName}",
        };

    }
    private async Task<string> _CreateTokenAsync(ApplicationUser user)
    {
        // Claims
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Email, user.Email!),
            new Claim(ClaimTypes.Name, user.UserName!),
            new Claim(ClaimTypes.NameIdentifier, user.Id!)
        };

        var roles = await userManager.GetRolesAsync(user);

        foreach (var role in roles)
            claims.Add(new Claim(ClaimTypes.Role, role));

        var secretKey = configuration.GetSection("JWTOptions")["SecretKey"];
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: configuration["JWTOptions:Issuer"],
            audience: configuration["JWTOptions:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}