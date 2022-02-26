using AddressBookMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace AddressBookMVC.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            // Look for any contacts
            if (context.Contacts.Any())
            {
                return; // DB has been seeded
            }

            context.Contacts.AddRange(
                new Contact
                {
                    FirstName = "Adam",
                    LastName = "Mann",
                    Address1 = "123 Some Place",
                    Address2 = "",
                    City = "CityName",
                    State = "Texas",
                    Zip = 75201,
                    Email = "adam@email.com",
                    Phone = "(000) 111-2222"
                }
            );
            context.SaveChanges();
        }
    }
}
