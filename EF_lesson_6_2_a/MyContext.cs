using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_lesson_6_2_a
{
    class MyContext : DbContext 
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Company> Companies { get; set; }
        public MyContext () : base ("EF_lesson_6_2_a")
        { }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Phone>()
            //    .HasMany(p => p.Companies)
            //    .WithMany(c => c.Phones);
            modelBuilder.Entity<Phone>()
                .HasMany(p => p.Companies)
                .WithMany(c => c.Phones)
                .Map(m =>
                {
                    m.ToTable("MobileCompanies");
                    m.MapLeftKey("MobileId");
                    m.MapRightKey("CompanyId");
                });
        }
        static MyContext()
        {
            Database.SetInitializer(new MyContextInitializer());
        }
    }
}
