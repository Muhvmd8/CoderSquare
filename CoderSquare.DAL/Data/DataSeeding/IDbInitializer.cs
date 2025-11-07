namespace CoderSquare.DAL.Data.DataSeeding;
public interface IDbInitializer
{
    Task InitializeIdentityAsync();
}