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
