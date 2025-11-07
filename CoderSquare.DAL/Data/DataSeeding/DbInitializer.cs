namespace CoderSquare.DAL.Data.DataSeeding;
public class DbInitializer(CoderSquareDbContext coderSquareDb,
    UserManager<ApplicationUser> userManager, 
    RoleManager<IdentityRole> roleManager) 
    : IDbInitializer
{
    public async Task InitializeIdentityAsync()
    {
		try
		{
            if (!roleManager.Roles.Any())
            {
                var admin = new IdentityRole("Admin");
                await roleManager.CreateAsync(admin);
            }

            if (!userManager.Users.Any())
            {
                var user01 = new ApplicationUser
                {
                    UserName = "Muhvmd",
                    Email = "ma@gmail.com",
                    FirstName = "Mohamed",
                    LastName = "Anwer",
                    PhoneNumber = "01095181541"
                };

                var user02 = new ApplicationUser
                {
                    UserName = "Anwer",
                    Email = "am@gmail.com",
                    FirstName = "Anwer",
                    LastName = "Mohamed",
                    PhoneNumber = "01095181544"
                };

                var result = await userManager.CreateAsync(user01, "Muhvmd_442004");
                await userManager.CreateAsync(user02, "Muhvmd_442004");

                await userManager.AddToRoleAsync(user01, "Admin");
                await userManager.AddToRoleAsync(user02, "Admin");
            }

            await coderSquareDb.SaveChangesAsync();
        }
		catch (Exception ex)
		{
            Console.WriteLine(ex.Message);
		}
    }
}
