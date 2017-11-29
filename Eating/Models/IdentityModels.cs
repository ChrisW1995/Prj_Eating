using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace Eating.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // 注意 authenticationType 必須符合 CookieAuthenticationOptions.AuthenticationType 中定義的項目
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // 在這裡新增自訂使用者宣告
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<County> Counties{ get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Coupons> Coupons { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<WaitingLists> WaitingLists { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<Admins> Admins { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<SetReservationDetails> SetReservationDetails { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Area>()
                 .HasRequired<County>(c => c.County)
                 .WithMany(a => a.Areas)
                 .HasForeignKey(c => c.CountyId);

            modelBuilder.Entity<Coupons>()
                 .HasRequired<Restaurant>(r => r.Restaurant)
                 .WithMany(c => c.Coupons)
                 .HasForeignKey(c => c.R_Id);

            modelBuilder.Entity<Seat>()
                 .HasRequired<Restaurant>(r => r.Restaurant)
                 .WithMany(c => c.Seats)
                 .HasForeignKey(c => c.R_Id);

            modelBuilder.Entity<WaitingLists>()
                  .HasRequired<Restaurant>(r => r.Restaurant)
                  .WithMany(w => w.WaitingLists)
                  .HasForeignKey(r => r.R_Id);

            modelBuilder.Entity<WaitingLists>()
                 .HasRequired<Customer>(r => r.Customer)
                 .WithMany(w => w.WaitingLists)
                 .HasForeignKey(c => c.C_Id);

     
            modelBuilder.Entity<Reservations>()
                 .HasRequired<Customer>(r => r.Customer)
                 .WithMany(w => w.Reserves)
                 .HasForeignKey(c => c.C_Id);

            modelBuilder.Entity<Reservations>()
                .HasRequired<SetReservationDetails>(s => s.SetReservationDetails)
                .WithMany(r => r.Reservations)
                .HasForeignKey(i => i.ReservationTimeId);
                

            modelBuilder.Entity<SetReservationDetails>()
                .HasRequired<Seat>(s => s.Seat)
                .WithMany(s => s.SetReservationDetails)
                .HasForeignKey(i => i.SeatId);
              

            modelBuilder.Entity<Feedback>()
                .HasRequired(r => r.Restaurant)
                .WithMany(f => f.Feedbacks)
                .HasForeignKey(f => f.R_Id);

            modelBuilder.Entity<Feedback>()
                .HasRequired(c => c.Customer)
                .WithMany(f => f.Feedbacks)
                .HasForeignKey(f => f.C_Id);

            modelBuilder.Entity<Menu>()
               .HasRequired(r => r.Restaurant)
               .WithMany(m => m.Menus)
               .HasForeignKey(f => f.R_Id);

            modelBuilder.Entity<SetReservationDetails>()
               .HasRequired(r => r.Restaurant)
               .WithMany(m => m.SetReservationDetails)
               .HasForeignKey(i => i.R_id)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Coupons>()
                .HasMany(c =>c.Customers)
                .WithMany(c => c.Coupons)
                .Map(cc =>
                {
                    cc.MapLeftKey("Coupon_Id");
                    cc.MapRightKey("Coupon_CId");
                    cc.ToTable("CustomerCoupon");
                });

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}