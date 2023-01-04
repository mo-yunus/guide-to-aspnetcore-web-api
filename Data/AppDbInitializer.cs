using my_books.Data.Models;

namespace my_books.Data
{
    public class AppDbInitializer  
        //we're going to use this file to initialize our database
        //and inside this class we're also going create a method and use this method to add data to our database if our database is empty.
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "Harry Potter",
                        Description = "Hogwarts school of witches and wizards",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        CoverUrl = "https...",
                        DateAdded = DateTime.Now,
                    },
                    new Book()
                    {
                        Title = "Lord of the Rings",
                        Description = "Horror and Tragedy",
                        IsRead = false,
                        Genre = "Biography",
                        CoverUrl = "https...",
                        DateAdded = DateTime.Now,
                    }

                    );

                    context.SaveChanges();
                }
            }
        }
    }
}
