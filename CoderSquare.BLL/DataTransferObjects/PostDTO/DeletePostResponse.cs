namespace CoderSquare.BLL.DataTransferObjects.PostDTO;
public class DeletePostResponse
{
    public Guid Id { get; set; }
    public DateTime DeletedAt { get; set; }
    public string Message { get; set; }
}
