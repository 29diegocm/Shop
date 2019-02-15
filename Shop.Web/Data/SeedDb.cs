namespace Shop.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using Microsoft.AspNetCore.Identity;
    using Shop.Web.Helpers;
   

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private readonly Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userHelper.GetUserByEmailAsync("diegocardonam1998@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Diego",
                    LastName = "Cardona",
                    Email = "diegocardonam1998@gmail.com",
                    UserName = "diegocardonam1998@gmail.com",
                    PhoneNumber = "3217148396"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }



            if (!this.context.Products.Any())
            {
                this.AddProduct("Iphone x", user);
                this.AddProduct("Magic Mouse", user);
                this.AddProduct("Iwatch series 4", user);
                this.AddProduct("note S9", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(1000),
                IsAvailabe = true,
                Stock = this.random.Next(100),
                User = user
            });
        }
    }

}
