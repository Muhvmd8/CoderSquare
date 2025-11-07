namespace CoderSquare.BLL.Exceptions;
public sealed class PostNotFoundException(string postId)
    : NotFoundException($"Post with id: {postId} is not found.");
