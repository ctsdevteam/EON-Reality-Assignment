using EON_Reality_Assignment.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace EON_Reality_Assignment
{
    public class Program
    {

        public static void Main(string[] args)
        {
            #region CustomSeeding
            //Get connection string from APPSETTINGS.JSON 
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddCommandLine(args)
                .Build();
            var connectionString = config.GetConnectionString("AppDB_ConnString");
             
            using (var context = new RegisteredUserContext(connectionString))
            {
                context.Database.EnsureCreated();

                var totalItem = context.tblRegisteredUsers.Count();
                if (totalItem == 0)
                {
                    context.tblRegisteredUsers.Add(
                        new RegisteredUsers
                        {
                            UserName = "Eric Duong",
                            EmailAddress = "ericduong@mailinator.com",
                            Gender = true,
                            RegisterDate = DateTime.Now,
                            AdditionalRequest = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor",
                            SelectedDays = ""
                        }
                    );
                    context.tblRegisteredUsers.Add(
                        new RegisteredUsers
                        {
                            UserName = "Jen Tay",
                            EmailAddress = "jen@mailinator.com",
                            Gender = false,
                            RegisterDate = DateTime.Now,
                            AdditionalRequest = "Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes",
                            SelectedDays = ""
                        }
                    );
                    context.tblRegisteredUsers.Add(
                        new RegisteredUsers
                        {
                            UserName = "Bruce",
                            EmailAddress = "bruce@mailinator.com",
                            Gender = true,
                            RegisterDate = DateTime.Now,
                            AdditionalRequest = "Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem.",
                            SelectedDays = ""
                        }
                    );
                    context.SaveChanges();
                }
            }
            #endregion
            CreateWebHostBuilder(args).Build().Run();

            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
