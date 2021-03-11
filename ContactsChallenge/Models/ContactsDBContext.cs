using Microsoft.EntityFrameworkCore;

namespace ContactsChallenge.Models
{
    public class ContactsDBContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ingresar la connection string
            optionsBuilder
                .UseSqlServer(@"");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
                    new Contact
                    {
                        ContactId = 1,
                        FirstName = "Juan",
                        LastName = "Perez",
                        Company = "JuanPerez S.A.",
                        Email = "juan@juanperezsa.com",
                        PhoneNumber = "15-2222-3555"
                    },
                    new Contact
                    {
                        ContactId = 2,
                        FirstName = "Maria",
                        LastName = "Martinez",
                        Company = "Estudio Contable",
                        Email = "maria@estudiocontable.com",
                        PhoneNumber = "11-4454-4545"
                    },
                    new Contact
                    {
                        ContactId = 3,
                        FirstName = "Sebastian",
                        LastName = "Gimenez",
                        Company = "Seguridad S.A.",
                        Email = "seguridad@seguridad.com",
                        PhoneNumber = "11-2321-4878"
                    },
                    new Contact
                    {
                        ContactId = 4,
                        FirstName = "Pedro",
                        LastName = "Lopez",
                        Company = "JuanPerez S.A.",
                        Email = "pedro@juanperezsa.com",
                        PhoneNumber = "11-2233-4460"
                    },
                    new Contact
                    {
                        ContactId = 5,
                        FirstName = "Ramiro",
                        LastName = "Estevez",
                        Company = "JuanPerez S.A.",
                        Email = "Ramiro@juanperezsa.com",
                        PhoneNumber = "11-2233-4460"
                    },
                    new Contact
                    {
                        ContactId = 6,
                        FirstName = "Josefina",
                        LastName = "Gomez",
                        Company = "EstebanSoft",
                        Email = "josefina@estebansoft.com",
                        PhoneNumber = "11-2233-4460"
                    },
                    new Contact
                    {
                        ContactId = 7,
                        FirstName = "Roman",
                        LastName = "Sanchez",
                        Company = "Roman Sanchez Contador",
                        Email = "RomanSanchezContador@gmail.com",
                        PhoneNumber = "11-4453-4340"
                    },
                    new Contact
                    {
                        ContactId = 8,
                        FirstName = "Mario",
                        LastName = "Pomez",
                        Company = "Remises y Transportes S.A.",
                        Email = "mariopomez@gmail.com",
                        PhoneNumber = "11-2211-2222"
                    },
                    new Contact
                    {
                        ContactId = 9,
                        FirstName = "Tito",
                        LastName = "Perez",
                        Company = "Juan Perez S.A.",
                        Email = "pepe@juanperezsa.com",
                        PhoneNumber = "11-5555-2222"
                    },
                    new Contact
                    {
                        ContactId = 10,
                        FirstName = "Sofia",
                        LastName = "Perez",
                        Company = "Juan Perez S.A.",
                        Email = "Sofia@juanperezsa.com",
                        PhoneNumber = "11-5555-2222"
                    }
                );
        }
    }
}
