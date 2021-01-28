using System.Linq;

namespace CaSecurity.Models
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                context.AddRange(
                    new User { Name = "Adam", Surname = "Olesiewicz", Company = "BorgWarner", Role = "Control Engineer", PermitionLevel = 9, PersonalCardId = 3903, }
                    );
            }
            context.SaveChanges();
        }
    }
}
