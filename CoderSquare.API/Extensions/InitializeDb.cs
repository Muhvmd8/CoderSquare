namespace CoderSquare.API.Extensions;
public static class InitializeDb
{
    public async static Task InitializeDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        await dbInitializer.InitializeIdentityAsync();
    }
}
