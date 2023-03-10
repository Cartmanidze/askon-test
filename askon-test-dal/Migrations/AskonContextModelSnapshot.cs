// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using askon_test_dal.Context;

#nullable disable

namespace askon_test_dal.Migrations
{
    [DbContext(typeof(AskonContext))]
    partial class AskonContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("askon_test_domain.Templates.Template", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Html")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserInfoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserInfoId")
                        .IsUnique();

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("askon_test_domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6edc3e92-5937-39db-9ced-4eda4ea8c121"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9341a26e-c91a-4633-8ade-fcf24bd12ed5",
                            Email = "diam.lorem@outlook.org",
                            EmailConfirmed = false,
                            FirstName = "Claudia",
                            LastName = "Walls",
                            LockoutEnabled = true,
                            NormalizedEmail = "DIAM.LOREM@OUTLOOK.ORG",
                            NormalizedUserName = "DIAM",
                            PasswordHash = "AQAAAAEAACcQAAAAEMp2ciXjmT/xGKxPbglnV52X3uvTukEI1yZm5dCHW9+dbW5FEEDKp44bSCwp5teaLA==",
                            PhoneNumber = "(206) 830-5808",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "6XFRJNPJGUXVVLV7ZZVWDTWE4NACVWZ4",
                            TwoFactorEnabled = false,
                            UserName = "diam"
                        },
                        new
                        {
                            Id = new Guid("f24dc889-9dd8-2223-92a4-8ca677e11914"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c0e1d55a-d588-4d35-ad81-91abaafa971a",
                            Email = "suspendisse.ac@yahoo.com",
                            EmailConfirmed = false,
                            FirstName = "Darius",
                            LastName = "Freeman",
                            LockoutEnabled = true,
                            NormalizedEmail = "SUSPENDISSE.AC@YAHOO.COM",
                            NormalizedUserName = "SUSPENDISSE",
                            PasswordHash = "AQAAAAEAACcQAAAAEAuQwjzrDTP1YRIMe9E/D0eRdyz5YpQx6YAfhpgxCuhcyTrX9Vn4NpL8/ndivu0yFg==",
                            PhoneNumber = "(887) 873-7358",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "XD4YMHWL5WU7P7MSYMX3IIJOFUZL7NQL",
                            TwoFactorEnabled = false,
                            UserName = "suspendisse"
                        });
                });

            modelBuilder.Entity("askon_test_domain.Users.UserInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserInfo");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6cc638f4-e49a-4fc1-dd42-8864aa042007"),
                            BirthDate = new DateTime(1986, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Test description",
                            NickName = "ClWalls",
                            UserId = new Guid("6edc3e92-5937-39db-9ced-4eda4ea8c121")
                        },
                        new
                        {
                            Id = new Guid("3c8c320e-bc6f-3015-643d-830d2692a9f3"),
                            BirthDate = new DateTime(1996, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Test description 2",
                            NickName = "DariusF",
                            UserId = new Guid("f24dc889-9dd8-2223-92a4-8ca677e11914")
                        });
                });

            modelBuilder.Entity("askon_test_domain.Templates.Template", b =>
                {
                    b.HasOne("askon_test_domain.Users.UserInfo", "UserInfo")
                        .WithOne("Template")
                        .HasForeignKey("askon_test_domain.Templates.Template", "UserInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("askon_test_domain.Users.UserInfo", b =>
                {
                    b.HasOne("askon_test_domain.Users.User", "User")
                        .WithOne("UserInfo")
                        .HasForeignKey("askon_test_domain.Users.UserInfo", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("askon_test_domain.Users.User", b =>
                {
                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("askon_test_domain.Users.UserInfo", b =>
                {
                    b.Navigation("Template");
                });
#pragma warning restore 612, 618
        }
    }
}
