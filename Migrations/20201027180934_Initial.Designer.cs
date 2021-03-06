// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Queries.Persistence;

namespace QueriewsCore.Migrations
{
    [DbContext(typeof(PlutoContext))]
    [Migration("20201027180934_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Queries.Core.Domain.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mosh Hamedani"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Anthony Alicea"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Eric Wise"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Tom Owsiak"
                        },
                        new
                        {
                            Id = 5,
                            Name = "John Smith"
                        });
                });

            modelBuilder.Entity("Queries.Core.Domain.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<float>("FullPrice")
                        .HasColumnType("real");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId")
                        .HasName("IX_AuthorId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Description = "Description for C# Basics",
                            FullPrice = 49f,
                            Level = 1,
                            Name = "C# Basics"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 1,
                            Description = "Description for C# Intermediate",
                            FullPrice = 49f,
                            Level = 2,
                            Name = "C# Intermediate"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 1,
                            Description = "Description for C# Advanced",
                            FullPrice = 69f,
                            Level = 3,
                            Name = "C# Advanced"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 2,
                            Description = "Description for Javascript",
                            FullPrice = 149f,
                            Level = 2,
                            Name = "Javascript: Understanding the Weird Parts"
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 2,
                            Description = "Description for AngularJS",
                            FullPrice = 99f,
                            Level = 2,
                            Name = "Learn and Understand AngularJS"
                        },
                        new
                        {
                            Id = 6,
                            AuthorId = 2,
                            Description = "Description for NodeJS",
                            FullPrice = 149f,
                            Level = 2,
                            Name = "Learn and Understand NodeJS"
                        },
                        new
                        {
                            Id = 7,
                            AuthorId = 3,
                            Description = "Description for Programming for Beginners",
                            FullPrice = 45f,
                            Level = 1,
                            Name = "Programming for Complete Beginners"
                        },
                        new
                        {
                            Id = 8,
                            AuthorId = 4,
                            Description = "Description 16 Hour Course",
                            FullPrice = 150f,
                            Level = 1,
                            Name = "A 16 Hour C# Course with Visual Studio 2013"
                        },
                        new
                        {
                            Id = 9,
                            AuthorId = 4,
                            Description = "Description Learn Javascript",
                            FullPrice = 20f,
                            Level = 1,
                            Name = "Learn JavaScript Through Visual Studio 2013"
                        });
                });

            modelBuilder.Entity("Queries.Core.Domain.CourseTags", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "TagId")
                        .HasName("PK_dbo.CourseTags");

                    b.HasIndex("CourseId")
                        .HasName("IX_CourseId");

                    b.HasIndex("TagId")
                        .HasName("IX_TagId");

                    b.ToTable("CourseTags");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            TagId = 1
                        },
                        new
                        {
                            CourseId = 2,
                            TagId = 5
                        },
                        new
                        {
                            CourseId = 3,
                            TagId = 1
                        },
                        new
                        {
                            CourseId = 4,
                            TagId = 3
                        },
                        new
                        {
                            CourseId = 5,
                            TagId = 2
                        },
                        new
                        {
                            CourseId = 6,
                            TagId = 4
                        },
                        new
                        {
                            CourseId = 7,
                            TagId = 1
                        },
                        new
                        {
                            CourseId = 8,
                            TagId = 1
                        },
                        new
                        {
                            CourseId = 9,
                            TagId = 3
                        });
                });

            modelBuilder.Entity("Queries.Core.Domain.Cover", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasName("IX_Id");

                    b.ToTable("Covers");
                });

            modelBuilder.Entity("Queries.Core.Domain.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "c#"
                        },
                        new
                        {
                            Id = 2,
                            Name = "angularjs"
                        },
                        new
                        {
                            Id = 3,
                            Name = "javascript"
                        },
                        new
                        {
                            Id = 4,
                            Name = "nodejs"
                        },
                        new
                        {
                            Id = 5,
                            Name = "oop"
                        },
                        new
                        {
                            Id = 6,
                            Name = "linq"
                        });
                });

            modelBuilder.Entity("Queries.Core.Domain.Course", b =>
                {
                    b.HasOne("Queries.Core.Domain.Author", "Author")
                        .WithMany("Courses")
                        .HasForeignKey("AuthorId")
                        .HasConstraintName("FK_dbo.Courses_dbo.Authors_AuthorId")
                        .IsRequired();
                });

            modelBuilder.Entity("Queries.Core.Domain.CourseTags", b =>
                {
                    b.HasOne("Queries.Core.Domain.Course", "Course")
                        .WithMany("CourseTags")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("FK_dbo.CourseTags_dbo.Courses_CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Queries.Core.Domain.Tag", "Tag")
                        .WithMany("CourseTags")
                        .HasForeignKey("TagId")
                        .HasConstraintName("FK_dbo.CourseTags_dbo.Tags_TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Queries.Core.Domain.Cover", b =>
                {
                    b.HasOne("Queries.Core.Domain.Course", "IdNavigation")
                        .WithOne("Covers")
                        .HasForeignKey("Queries.Core.Domain.Cover", "Id")
                        .HasConstraintName("FK_dbo.Covers_dbo.Courses_Id")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
