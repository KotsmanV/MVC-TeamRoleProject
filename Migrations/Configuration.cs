namespace TeamRoleProject.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TeamRoleProject.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TeamRoleProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TeamRoleProject.Models.ApplicationDbContext context)
        {
            Book b1 = new Book() { Title = "The Fellowship of the Ring" };
            Book b2 = new Book() { Title = "The Two Towers" };
            Book b3 = new Book() { Title = "The Return of the King" };
            Book b4 = new Book() { Title = "The Children of Hurin" };
            Book b5 = new Book() { Title = "The Fall of Gondolin" };
            Book b6 = new Book() { Title = "The Silmarillion" };

            context.Books.AddOrUpdate(x => new { x.Title }, b1, b2, b3, b4, b5, b6);

            if (!context.Roles.Any(x=>x.Name=="Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };
                manager.Create(role);
            }

            if (!context.Roles.Any(x => x.Name == "Supervisor"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Supervisor" };
                manager.Create(role);
            }

            if (!context.Roles.Any(x => x.Name == "Customer"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Customer" };
                manager.Create(role);
            }

            var passwordHashish = new PasswordHasher();
            if (!context.Users.Any(x => x.UserName == "admin@admin.net"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "admin@admin.net",
                    Email = "admin@admin.net",
                    PasswordHash = passwordHashish.HashPassword("Abc123!")
                };

                manager.Create(user);
                manager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(x => x.UserName == "supervisor@admin.net"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "supervisor@admin.net",
                    Email = "supervisor@admin.net",
                    PasswordHash = passwordHashish.HashPassword("Abc123!")
                };

                manager.Create(user);
                manager.AddToRole(user.Id, "Supervisor");
            }

            if (!context.Users.Any(x => x.UserName == "customer@customer.net"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "customer@customer.net",
                    Email = "customer@customer.net",
                    PasswordHash = passwordHashish.HashPassword("Abc123!")
                };

                manager.Create(user);
                manager.AddToRole(user.Id, "Customer");
            }
        }
    }
}
