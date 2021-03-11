﻿// <auto-generated />
using ContactsChallenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ContactsChallenge.Migrations
{
    [DbContext(typeof(ContactsDBContext))]
    partial class ContactsDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ContactsChallenge.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            ContactId = 1,
                            Company = "JuanPerez S.A.",
                            Email = "juan@juanperezsa.com",
                            FirstName = "Juan",
                            LastName = "Perez",
                            PhoneNumber = "15-2222-3555"
                        },
                        new
                        {
                            ContactId = 2,
                            Company = "Estudio Contable",
                            Email = "maria@estudiocontable.com",
                            FirstName = "Maria",
                            LastName = "Martinez",
                            PhoneNumber = "11-4454-4545"
                        },
                        new
                        {
                            ContactId = 3,
                            Company = "Seguridad S.A.",
                            Email = "seguridad@seguridad.com",
                            FirstName = "Sebastian",
                            LastName = "Gimenez",
                            PhoneNumber = "11-2321-4878"
                        },
                        new
                        {
                            ContactId = 4,
                            Company = "JuanPerez S.A.",
                            Email = "pedro@juanperezsa.com",
                            FirstName = "Pedro",
                            LastName = "Lopez",
                            PhoneNumber = "11-2233-4460"
                        },
                        new
                        {
                            ContactId = 5,
                            Company = "JuanPerez S.A.",
                            Email = "Ramiro@juanperezsa.com",
                            FirstName = "Ramiro",
                            LastName = "Estevez",
                            PhoneNumber = "11-2233-4460"
                        },
                        new
                        {
                            ContactId = 6,
                            Company = "EstebanSoft",
                            Email = "josefina@estebansoft.com",
                            FirstName = "Josefina",
                            LastName = "Gomez",
                            PhoneNumber = "11-2233-4460"
                        },
                        new
                        {
                            ContactId = 7,
                            Company = "Roman Sanchez Contador",
                            Email = "RomanSanchezContador@gmail.com",
                            FirstName = "Roman",
                            LastName = "Sanchez",
                            PhoneNumber = "11-4453-4340"
                        },
                        new
                        {
                            ContactId = 8,
                            Company = "Remises y Transportes S.A.",
                            Email = "mariopomez@gmail.com",
                            FirstName = "Mario",
                            LastName = "Pomez",
                            PhoneNumber = "11-2211-2222"
                        },
                        new
                        {
                            ContactId = 9,
                            Company = "JuanPerez S.A.",
                            Email = "pepe@juanperezsa.com",
                            FirstName = "Tito",
                            LastName = "Perez",
                            PhoneNumber = "11-5555-2222"
                        },
                        new
                        {
                            ContactId = 10,
                            Company = "JuanPerez S.A.",
                            Email = "Sofia@juanperezsa.com",
                            FirstName = "Sofia",
                            LastName = "Perez",
                            PhoneNumber = "11-5555-2222"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
