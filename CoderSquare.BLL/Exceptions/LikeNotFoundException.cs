namespace CoderSquare.BLL.Exceptions;
public sealed class LikeNotFoundException(int id)
    : NotFoundException($"Like with id {id} is deleted!");