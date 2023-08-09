using Raspored.Models.Login;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Emit;
using Raspored.Models.DTOs;

namespace Raspored.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ShiftType> ShiftTypes { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<TeamMemberRole> TeamMemberRoles { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<PersonalSchedule> PersonalSchedules { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

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
                YearOfEmployment = 2020,
                EmailConfirmed = true
            };

            var user2 = new ApplicationUser
            {
                UserName = "korisnik2",
                Email = "korisnik2@test.com",
                YearOfEmployment = 2023,
                EmailConfirmed = true
            };

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Qwe-123");
            user1.PasswordHash = passwordHasher.HashPassword(user1, "Asdf-1234");
            user2.PasswordHash = passwordHasher.HashPassword(user2, "Zxc-987");

            //builder.Entity<ApplicationUser>(entity =>
            //{
            //    entity.Property(u => u.ProfileImage).HasMaxLength(255);
            //    entity.HasData(adminUser, user1, user2);
            //});


            //builder.Entity<TipProjekcije>().HasData(
            //    new TipProjekcije() { Id = 1, Naziv = "2D" },
            //    new TipProjekcije() { Id = 2, Naziv = "3D" },
            //    new TipProjekcije() { Id = 3, Naziv = "4D" }
            //);
            
            //builder.Entity<Sala>().HasData(
            //    new Sala() { Id = 1, Naziv = "Mala sala" },
            //    new Sala() { Id = 2, Naziv = "Velika sala" },
            //    new Sala() { Id = 3, Naziv = "Ultimate sala" }
            //);

            //builder.Entity<Sediste>().HasData(
            //    new Sediste() { Id = 1, Broj = 1, SalaId = 1 },
            //    new Sediste() { Id = 2, Broj = 2, SalaId = 1 },
            //    new Sediste() { Id = 3, Broj = 3, SalaId = 1 },
            //    new Sediste() { Id = 4, Broj = 4, SalaId = 1 },
            //    new Sediste() { Id = 5, Broj = 5, SalaId = 1 },
            //    new Sediste() { Id = 6, Broj = 6, SalaId = 1 },
            //    new Sediste() { Id = 7, Broj = 7, SalaId = 1 },
            //    new Sediste() { Id = 8, Broj = 8, SalaId = 1 },
            //    new Sediste() { Id = 9, Broj = 9, SalaId = 1 },
            //    new Sediste() { Id = 10, Broj = 10, SalaId = 1 },
            //    new Sediste() { Id = 11, Broj = 1, SalaId = 2 },
            //    new Sediste() { Id = 12, Broj = 2, SalaId = 2 },
            //    new Sediste() { Id = 13, Broj = 3, SalaId = 2 },
            //    new Sediste() { Id = 14, Broj = 4, SalaId = 2 },
            //    new Sediste() { Id = 15, Broj = 5, SalaId = 2 },
            //    new Sediste() { Id = 16, Broj = 6, SalaId = 2 },
            //    new Sediste() { Id = 17, Broj = 7, SalaId = 2 },
            //    new Sediste() { Id = 18, Broj = 8, SalaId = 2 },
            //    new Sediste() { Id = 19, Broj = 9, SalaId = 2 },
            //    new Sediste() { Id = 20, Broj = 10, SalaId = 2 },
            //    new Sediste() { Id = 21, Broj = 11, SalaId = 2 },
            //    new Sediste() { Id = 22, Broj = 12, SalaId = 2 },
            //    new Sediste() { Id = 23, Broj = 13, SalaId = 2 },
            //    new Sediste() { Id = 24, Broj = 14, SalaId = 2 },
            //    new Sediste() { Id = 25, Broj = 15, SalaId = 2 },
            //    new Sediste() { Id = 26, Broj = 1, SalaId = 3 },
            //    new Sediste() { Id = 27, Broj = 2, SalaId = 3 },
            //    new Sediste() { Id = 28, Broj = 3, SalaId = 3 },
            //    new Sediste() { Id = 29, Broj = 4, SalaId = 3 },
            //    new Sediste() { Id = 30, Broj = 5, SalaId = 3 },
            //    new Sediste() { Id = 31, Broj = 6, SalaId = 3 },
            //    new Sediste() { Id = 32, Broj = 7, SalaId = 3 },
            //    new Sediste() { Id = 33, Broj = 8, SalaId = 3 },
            //    new Sediste() { Id = 34, Broj = 9, SalaId = 3 },
            //    new Sediste() { Id = 35, Broj = 10, SalaId = 3 },
            //    new Sediste() { Id = 36, Broj = 11, SalaId = 3 },
            //    new Sediste() { Id = 37, Broj = 12, SalaId = 3 },
            //    new Sediste() { Id = 38, Broj = 13, SalaId = 3 },
            //    new Sediste() { Id = 39, Broj = 14, SalaId = 3 },
            //    new Sediste() { Id = 40, Broj = 15, SalaId = 3 },
            //    new Sediste() { Id = 41, Broj = 16, SalaId = 3 },
            //    new Sediste() { Id = 42, Broj = 17, SalaId = 3 },
            //    new Sediste() { Id = 43, Broj = 18, SalaId = 3 },
            //    new Sediste() { Id = 44, Broj = 19, SalaId = 3 },
            //    new Sediste() { Id = 45, Broj = 20, SalaId = 3 }
            //);

            //builder.Entity<Film>().HasData(
            //    new Film()
            //    {
            //        Id = 1,
            //        Naziv = "Film 1",
            //        Reziser = "Reziser 1",
            //        Glumci = "Glumci 1",
            //        Zanrovi = "Zanrovi 1",
            //        Trajanje = 120,
            //        Distributer = "Distr 1",
            //        ZemljaPorekla = "Zemlja 1",
            //        GodinaProizvodnje = 1985,
            //        Opis = "Opis 1"
            //    },
            //    new Film()
            //    {
            //        Id = 2,
            //        Naziv = "Film 2",
            //        Reziser = "Reziser 2",
            //        Glumci = "Glumci 2",
            //        Zanrovi = "Zanrovi 2",
            //        Trajanje = 110,
            //        Distributer = "Distr 2",
            //        ZemljaPorekla = "Zemlja 2",
            //        GodinaProizvodnje = 1984,
            //        Opis = "Opis 2"
            //    },
            //    new Film()
            //    {
            //        Id = 3,
            //        Naziv = "Spaceballs",
            //        Reziser = "Mel Brooks",
            //        Glumci = "Mel Brooks, John Candy, Rick Moranis, Bill Pullman, Daphne Zuniga",
            //        Zanrovi = "Sci-Fi, Komedija, Avantura",
            //        Trajanje = 96,
            //        Distributer = "Metro Goldwyn Mayer",
            //        ZemljaPorekla = "USA",
            //        GodinaProizvodnje = 1987,
            //        Opis = "Opis"
            //    },
            //    new Film()
            //    {
            //        Id = 4,
            //        Naziv = "Film 4",
            //        Reziser = "Reziser 4",
            //        Glumci = "Glumci 4",
            //        Zanrovi = "Zanrovi 4",
            //        Trajanje = 90,
            //        Distributer = "Distr 4",
            //        ZemljaPorekla = "Zemlja 4",
            //        GodinaProizvodnje = 1991,
            //        Opis = "Opis 4"
            //    },
            //    new Film()
            //    {
            //        Id = 5,
            //        Naziv = "Film 5",
            //        Reziser = "Reziser 5",
            //        Glumci = "Glumci 5",
            //        Zanrovi = "Zanrovi 5",
            //        Trajanje = 98,
            //        Distributer = "Distr 5",
            //        ZemljaPorekla = "Zemlja 5",
            //        GodinaProizvodnje = 2001,
            //        Opis = "Opis 5"
            //    }
            //);

            base.OnModelCreating(builder);
        }
    }
}
