using System.Linq;
using Comparis.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Comparis.Data
{
    public static class SeedDb
    {
        public static void Populate(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<PetInsuranceDbContext>());
            }
        }
        private static void SeedData(PetInsuranceDbContext context) 
        {
            if(!context.InsuranceCompanies.Any())
            {
                System.Console.WriteLine("Seeding data...");

                context.InsuranceCompanies.AddRange
                (
                    new InsuranceCompany() 
                    {
                        Name = "Animalia",
                        Description = "Protecting all nine lives.",
                        Address = "Der Zug 5",
                        PhoneNumber = "+41 555 555"
                    },
                    new InsuranceCompany() 
                    {
                        Name = "wau-miau",
                        Description = "We also treat cats and dogs who speak other dialects besides of wau and miau.",
                        Address = "Die Haltestelle 5",
                        PhoneNumber = "+41 555 555"
                    },
                    new InsuranceCompany() 
                    {
                        Name = "Little Flea",
                        Description = "We treat a variety of birds, including chickens, parakeets and cassowaries.",
                        Address = "Die Rechnung 6",
                        PhoneNumber = "+41 555 555"
                    },                  
                    new InsuranceCompany() 
                    {
                        Name = "The Happy Rooster",
                        Description = "Best care for your feathered pets!",
                        Address = "Grass Strasse 6",
                        PhoneNumber = "+41 555 555"
                    },
                    new InsuranceCompany() 
                    {
                        Name = "O'Malley Peppers",
                        Description = "Named after our favourite duck which inspired our mission.",
                        Address = "Feather street 5",
                        PhoneNumber = "+41 555 555"
                    }
                );

                context.SaveChanges();
            }
        }
    } 
}