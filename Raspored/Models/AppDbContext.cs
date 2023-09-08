using Raspored.Models.Login;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Raspored.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly string zaposleni = "95df2068-389d-457f-a0e6-eb8b4e1bc906";
        private readonly string admin = "b1a25eb0-1475-4ba0-afdf-2e8cf754d01f";
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
                    Name = "RCSmena"
                },
                new FeatureType()
                {
                    Id = 9,
                    Name = "RCDatumSmene"
                }
            );

            builder.Entity<Feature>().HasData(
                new Feature() { Id = 1, Name = "Lični", Description = "Lični raspored za tekući mesec" },
                new Feature() { Id = 2, Name = "Timski", Description = "Timski raspored za tekući mesec" },
                new Feature() { Id = 3, Name = "Odeljenski", Description = "Pregled svih timskih rasporeda za tekući mesec" },
                new Feature() { Id = 4, Name = "Smenski", Description = "Brzi pregled svih tehničara u timu po datumu i smeni" },
                new Feature() { Id = 5, Name = "Kreiraj", Description = "Kreiranje rasporeda za naredni mesec za sve timove" },
                new Feature() { Id = 6, Name = "Lista", Description = "Lista postojećih timova" },
                new Feature() { Id = 7, Name = "Dodaj", Description = "Dodavanje novog tima" },
                new Feature() { Id = 8, Name = "Izmeni", Description = "Izmena postojećeg tima" },
                new Feature() { Id = 9, Name = "Obriši", Description = "Brisanje postojećeg tima" },
                new Feature() { Id = 10, Name = "Lista", Description = "Spisak svih zaposlenih" },
                new Feature() { Id = 11, Name = "Dodaj", Description = "Dodaj novog zaposlenog" },
                new Feature() { Id = 12, Name = "Izmeni", Description = "Izmena podataka zaposlenih" },
                new Feature() { Id = 13, Name = "Obriši", Description = "Obriši zaposlenog - podaci se arhiviraju!" },
                new Feature() { Id = 14, Name = "Pretraga", Description = "Pretraga zaposlenih po različitim kriterijumima" },
                new Feature() { Id = 15, Name = "Aplikacija", Description = "Podešavanja izgleda i funkcionalnosti aplikacije" },
                new Feature() { Id = 16, Name = "Administracija", Description = "Administrativna podešavanja aplikacije i podataka" },
                new Feature() { Id = 17, Name = "Timovi", Description = "Podešavanja organizacije timova" },
                new Feature() { Id = 18, Name = "Prikaz", Description = "Prikaz osnovnih podataka korisnika" },
                new Feature() { Id = 19, Name = "Izmena", Description = "Izmena osnovnih podataka korisnika" },
                new Feature() { Id = 20, Name = "Izmeni", Description = "Izmeni podatke u zaglavlju izabranog rasporeda" },
                new Feature() { Id = 21, Name = "Dodaj/promeni ulogu", Description = "Dodavanje / promena uloge u sklopu tima" },
                new Feature() { Id = 22, Name = "Prebaci u drugi tim", Description = "Prebacivanje zaposlenog u drugi tim" },
                new Feature() { Id = 23, Name = "Dodaj smenu", Description = "Dodavanje smene zaposlenom" },
                new Feature() { Id = 24, Name = "Promeni smenu", Description = "Promena tipa smene" },
                new Feature() { Id = 25, Name = "Obriši smenu", Description = "Brisanje smene sa rasporeda" },
                new Feature() { Id = 26, Name = "Dodeli smenu", Description = "Dodela smene za ceo tim" },
                new Feature() { Id = 27, Name = "Izmeni smenu", Description = "Izmena smene za ceo tim" },
                new Feature() { Id = 28, Name = "Obriši smenu", Description = "Brisanje smene za ceo tim" }
            );
            
            builder.Entity<RoleFeatureMapping>().HasData(
                new RoleFeatureMapping() { Id = 1, RoleId = zaposleni, FeatureTypeId = 1, FeatureId = 1 },
                new RoleFeatureMapping() { Id = 2, RoleId = zaposleni, FeatureTypeId = 1, FeatureId = 2 },
                new RoleFeatureMapping() { Id = 3, RoleId = zaposleni, FeatureTypeId = 1, FeatureId = 3 },
                new RoleFeatureMapping() { Id = 4, RoleId = zaposleni, FeatureTypeId = 1, FeatureId = 4 },
                new RoleFeatureMapping() { Id = 5, RoleId = admin, FeatureTypeId = 1, FeatureId = 1 },
                new RoleFeatureMapping() { Id = 6, RoleId = admin, FeatureTypeId = 1, FeatureId = 2 },
                new RoleFeatureMapping() { Id = 7, RoleId = admin, FeatureTypeId = 1, FeatureId = 3 },
                new RoleFeatureMapping() { Id = 8, RoleId = admin, FeatureTypeId = 1, FeatureId = 4 },
                new RoleFeatureMapping() { Id = 9, RoleId = admin, FeatureTypeId = 1, FeatureId = 5 },
                new RoleFeatureMapping() { Id = 10, RoleId = admin, FeatureTypeId = 2, FeatureId = 6 },
                new RoleFeatureMapping() { Id = 11, RoleId = admin, FeatureTypeId = 2, FeatureId = 7 },
                new RoleFeatureMapping() { Id = 12, RoleId = admin, FeatureTypeId = 2, FeatureId = 8 },
                new RoleFeatureMapping() { Id = 13, RoleId = admin, FeatureTypeId = 2, FeatureId = 9 },
                new RoleFeatureMapping() { Id = 14, RoleId = admin, FeatureTypeId = 3, FeatureId = 10 },
                new RoleFeatureMapping() { Id = 15, RoleId = admin, FeatureTypeId = 3, FeatureId = 11 },
                new RoleFeatureMapping() { Id = 16, RoleId = admin, FeatureTypeId = 3, FeatureId = 12 },
                new RoleFeatureMapping() { Id = 17, RoleId = admin, FeatureTypeId = 3, FeatureId = 13 },
                new RoleFeatureMapping() { Id = 18, RoleId = admin, FeatureTypeId = 3, FeatureId = 14 },
                new RoleFeatureMapping() { Id = 19, RoleId = zaposleni, FeatureTypeId = 4, FeatureId = 15 },
                new RoleFeatureMapping() { Id = 20, RoleId = admin, FeatureTypeId = 4, FeatureId = 15 },
                new RoleFeatureMapping() { Id = 21, RoleId = admin, FeatureTypeId = 4, FeatureId = 16 },
                new RoleFeatureMapping() { Id = 22, RoleId = admin, FeatureTypeId = 4, FeatureId = 17 },
                new RoleFeatureMapping() { Id = 23, RoleId = zaposleni, FeatureTypeId = 5, FeatureId = 18 },
                new RoleFeatureMapping() { Id = 24, RoleId = zaposleni, FeatureTypeId = 5, FeatureId = 19 },
                new RoleFeatureMapping() { Id = 25, RoleId = admin, FeatureTypeId = 5, FeatureId = 18 },
                new RoleFeatureMapping() { Id = 26, RoleId = admin, FeatureTypeId = 5, FeatureId = 19 },
                new RoleFeatureMapping() { Id = 27, RoleId = admin, FeatureTypeId = 6, FeatureId = 20 },
                new RoleFeatureMapping() { Id = 28, RoleId = admin, FeatureTypeId = 7, FeatureId = 21 },
                new RoleFeatureMapping() { Id = 29, RoleId = admin, FeatureTypeId = 7, FeatureId = 22 },
                new RoleFeatureMapping() { Id = 30, RoleId = admin, FeatureTypeId = 8, FeatureId = 23 },
                new RoleFeatureMapping() { Id = 31, RoleId = admin, FeatureTypeId = 8, FeatureId = 24 },
                new RoleFeatureMapping() { Id = 32, RoleId = admin, FeatureTypeId = 8, FeatureId = 25 },
                new RoleFeatureMapping() { Id = 33, RoleId = admin, FeatureTypeId = 9, FeatureId = 26 },
                new RoleFeatureMapping() { Id = 34, RoleId = admin, FeatureTypeId = 9, FeatureId = 27 },
                new RoleFeatureMapping() { Id = 35, RoleId = admin, FeatureTypeId = 9, FeatureId = 28 }
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
