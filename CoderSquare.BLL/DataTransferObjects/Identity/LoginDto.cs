namespace CoderSquare.BLL.DataTransferObjects.Identity;
public class LoginDto
{
    [EmailAddress]
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
