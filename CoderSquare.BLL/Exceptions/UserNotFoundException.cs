namespace CoderSquare.BLL.Exceptions;
public class UserNotFoundException(string email)
    : NotFoundException($"User with email address: {email} is not found.");