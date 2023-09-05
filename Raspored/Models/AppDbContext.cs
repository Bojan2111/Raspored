using Raspored.Models.Login;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Raspored.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ShiftType> ShiftTypes { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<TeamMemberRole> TeamMemberRoles { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }
        public DbSet<RoleFeatureMapping> RoleFeatureMappings { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FeatureType> FeatureTypes { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            /*
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

            */
            builder.Entity<Position>().HasData(
                new Position()
                {
                    Id = 1,
                    Name = "Organizaciona sestra - tehničar"
                },
                new Position()
                {
                    Id = 2,
                    Name = "Edukator"
                },
                new Position()
                {
                    Id = 3,
                    Name = "Medicinska sestra - tehničar"
                },
                new Position()
                {
                    Id = 4,
                    Name = "Mikrobiološka sestra - tehničar"
                },
                new Position()
                {
                    Id = 5,
                    Name = "Administrativna sestra - tehničar"
                },
                new Position()
                {
                    Id = 6,
                    Name = "Sterilizacijska sestra - tehničar"
                }
            );

            builder.Entity<ContractType>().HasData(
                new ContractType()
                {
                    Id = 1,
                    Name = "Određeno"
                },
                new ContractType()
                {
                    Id = 2,
                    Name = "Neodređeno"
                },
                new ContractType()
                {
                    Id = 3,
                    Name = "Zamena"
                },
                new ContractType()
                {
                    Id = 4,
                    Name = "Stažiranje"
                },
                new ContractType()
                {
                    Id = 5,
                    Name = "Zamrznuto"
                },
                new ContractType()
                {
                    Id = 6,
                    Name = "Čeka prekid ugovora"
                },
                new ContractType()
                {
                    Id = 7,
                    Name = "Prekinut radni odnos"
                }
            );

            builder.Entity<FeatureType>().HasData(
                new FeatureType()
                {
                    Id = 1,
                    Name = "Raspored"
                },
                new FeatureType()
                {
                    Id = 2,
                    Name = "Timovi"
                },
                new FeatureType()
                {
                    Id = 3,
                    Name = "Zaposleni"
                },
                new FeatureType()
                {
                    Id = 4,
                    Name = "Podešavanja"
                },
                new FeatureType()
                {
                    Id = 5,
                    Name = "Profil"
                },
                new FeatureType()
                {
                    Id = 6,
                    Name = "RCZaglavlje"
                },
                new FeatureType()
                {
                    Id = 7,
                    Name = "RCImeClana"
                },
                new FeatureType()
                {
                    Id = 8,
                    Name = "RCDatumSmene"
                },
                new FeatureType()
                {
                    Id = 9,
                    Name = "RCSmena"
                }
            );

            builder.Entity<Feature>().HasData(
                new Feature() { Id = 1, Name = "", Description = "" },
                new Feature() { Id = 2, Name = "", Description = "" },
                new Feature() { Id = 3, Name = "", Description = "" },
                new Feature() { Id = 4, Name = "", Description = "" },
                new Feature() { Id = 5, Name = "", Description = "" },
                new Feature() { Id = 6, Name = "", Description = "" },
                new Feature() { Id = 7, Name = "", Description = "" },
                new Feature() { Id = 8, Name = "", Description = "" },
                new Feature() { Id = 9, Name = "", Description = "" },
                new Feature() { Id = 10, Name = "", Description = "" },
                new Feature() { Id = 11, Name = "", Description = "" },
                new Feature() { Id = 12, Name = "", Description = "" },
                new Feature() { Id = 13, Name = "", Description = "" },
                new Feature() { Id = 14, Name = "", Description = "" },
                new Feature() { Id = 15, Name = "", Description = "" },
                new Feature() { Id = 16, Name = "", Description = "" },
                new Feature() { Id = 17, Name = "", Description = "" },
                new Feature() { Id = 18, Name = "", Description = "" },
                new Feature() { Id = 19, Name = "", Description = "" },
                new Feature() { Id = 20, Name = "", Description = "" },
                new Feature() { Id = 21, Name = "", Description = "" },
                new Feature() { Id = 22, Name = "", Description = "" },
                new Feature() { Id = 23, Name = "", Description = "" },
                new Feature() { Id = 24, Name = "", Description = "" },
                new Feature() { Id = 25, Name = "", Description = "" },
                new Feature() { Id = 26, Name = "", Description = "" },
                new Feature() { Id = 27, Name = "", Description = "" },
                new Feature() { Id = 28, Name = "", Description = "" },
                new Feature() { Id = 29, Name = "", Description = "" },
                new Feature() { Id = 30, Name = "", Description = "" },
                new Feature() { Id = 31, Name = "", Description = "" },
                new Feature() { Id = 32, Name = "", Description = "" },
                new Feature() { Id = 33, Name = "", Description = "" }
            );
            /*
            var adminUser = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@example.com",
                FirstName = "admin",
                LastName = "admin",
                DateOfBirth = new DateTime(1985, 6, 25),
                YearOfEmployment = 2022,
                LicenseNumber = "OVO2131312341",
                ContractTypeId = 2,
                PositionId = 1,
                EmailConfirmed = true
            };

            var user1 = new ApplicationUser
            {
                UserName = "korisnik1",
                Email = "korisnik1@test.com",
                FirstName = "korisnik",
                LastName = "prvi",
                DateOfBirth = new DateTime(1995, 8, 15),
                YearOfEmployment = 2022,
                LicenseNumber = "OVO2156312341",
                ContractTypeId = 2,
                PositionId = 1,
            };

            var user2 = new ApplicationUser
            {
                UserName = "korisnik2",
                Email = "korisnik2@test.com",
                FirstName = "korisnik",
                LastName = "drugi",
                DateOfBirth = new DateTime(1985, 6, 25),
                YearOfEmployment = 2022,
                LicenseNumber = "OVO2131356341",
                ContractTypeId = 2,
                PositionId = 1,
            };

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Qwe-123");
            user1.PasswordHash = passwordHasher.HashPassword(user1, "Asdf-1234");
            user2.PasswordHash = passwordHasher.HashPassword(user2, "Zxc-987");

            builder.Entity<ApplicationUser>(entity =>
            {
                //entity.Property(u => u.ProfileImage).HasMaxLength(255);
                entity.HasData(adminUser, user1, user2);
            });
            */

            base.OnModelCreating(builder);
        }
    }
}
