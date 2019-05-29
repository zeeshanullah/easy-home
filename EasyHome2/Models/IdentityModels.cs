using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EasyHome2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
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
        public DbSet<AdHomeProperty> AdHomeProperty { get; set; }
        public DbSet<AdCommecialProperty> AdCommercialProperty { get; set; }
        public DbSet<AdPlotProperty> AdPlotProperty { get; set; }

        public DbSet<HomeTypes> HomeType { get; set; }

        public DbSet<CommercialTypes> CommercialTypes { get; set; }
        public DbSet<PlotTypes> PlotType { get; set; }

        public DbSet<HomeImages> HomeImages { get; set; }

        public DbSet<CommercialImages> CommercialImages { get; set; }

        public DbSet<AddHomeTypeRental> AddHomeTypeRental { get; set; }
        public DbSet<RentalHomeImages> RentalHomeImages { get; set; }

        public DbSet<AddCommercialTypeRental> AddCommercialTypeRental { get; set; }
        public DbSet<RentalCommercialImages> RentalCommercialImages { get; set; }

        public DbSet<PayingGuest> PayingGuest { get; set; }

        public DbSet<PayingGuestImages> PayingGuestImages { get; set; }



        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}