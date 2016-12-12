namespace BLOG.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    //exclusive to this application/namespace, cannot be inherited from any class
    internal sealed class Configuration : DbMigrationsConfiguration<BLOG.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BLOG.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            //lambda expression, shorthand expression for something bigger
            //start from inside object, going outward
            //go find an object represented by variable r, such that the Name property r is equal to the string admin
            //find me anything which matched this criteria
            //if you cant find that criteria, then do the following statement under the if
            // link ( lambda )
            
            //create role called "ADMIN"
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole("Admin"));
            }

            //added myself
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (!context.Users.Any(u => u.Email == "zxiong1008@gmail.com"))
            {
                userManager.Create( new ApplicationUser
                {
                    Email = "zxiong1008@gmail.com",
                    UserName = "zxiong1008@gmail.com",
                    FirstName = "Zeng",
                    LastName = "Xiong",
                    DisplayName = "ZengC"
                }, "Password-1");
            }
            //UPDATE[zxiong - portfolio].[dbo].[AspNetUsers]
            //SET FirstName = 'Zeng', LastName = 'Xiong'
            //WHERE UserName = 'zxiong1008@gmail.com';

            //set myself to admin
            var userID = userManager.FindByEmail("zxiong1008@gmail.com").Id;
            userManager.AddToRole(userID, "Admin");
        }
    }
}
