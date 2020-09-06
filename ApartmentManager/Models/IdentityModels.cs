using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace ApartmentManager.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ApplicationDbContext", throwIfV1Schema: false)
        {

        }
        //public DbSet<Customer> Customers { get; set; } // My domain model
        //public DbSet<Movie> Movies { get; set; }// My domain models      
        //public DbSet<MembershipType> MembershipTypes { get; set; }
        //public DbSet<GenreType> GenreTypes { get; set; }
        //public DbSet<Rental> Rentals { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<Apartment> Apartment { get; set; }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<Tenent> Tenent { get; set; }
        public DbSet<ApartmentType> ApartmentType { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}