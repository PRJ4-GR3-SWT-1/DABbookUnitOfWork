using Queries.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Queries.Persistence
{
    public partial class PlutoContext : DbContext
    {
        public PlutoContext()
        {
        }

        public PlutoContext(DbContextOptions<PlutoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<CourseTags> CourseTags { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Cover> Covers { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\DABServer;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseTags>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.TagId })
                    .HasName("PK_dbo.CourseTags");

                entity.HasIndex(e => e.CourseId)
                    .HasName("IX_CourseId");

                entity.HasIndex(e => e.TagId)
                    .HasName("IX_TagId");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseTags)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_dbo.CourseTags_dbo.Courses_CourseId");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.CourseTags)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("FK_dbo.CourseTags_dbo.Tags_TagId");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasIndex(e => e.AuthorId)
                    .HasName("IX_AuthorId");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Courses_dbo.Authors_AuthorId");
            });

            modelBuilder.Entity<Cover>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("IX_Id");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Covers)
                    .HasForeignKey<Cover>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Covers_dbo.Courses_Id");
            });

            Seed(modelBuilder);
            

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


        private void Seed(ModelBuilder modelBuilder)
        {
            #region Add Tags
            var tags = new Dictionary<string, Tag>
            {
                {"c#", new Tag {Id = 1, Name = "c#"}},
                {"angularjs", new Tag {Id = 2, Name = "angularjs"}},
                {"javascript", new Tag {Id = 3, Name = "javascript"}},
                {"nodejs", new Tag {Id = 4, Name = "nodejs"}},
                {"oop", new Tag {Id = 5, Name = "oop"}},
                {"linq", new Tag {Id = 6, Name = "linq"}},
            };


            foreach (var tag in tags.Values)

                modelBuilder.Entity<Tag>().HasData(tag);
            #endregion

            #region Add Authors
            var authors = new List<Author>
            {
                new Author
                {
                    Id = 1,
                    Name = "Mosh Hamedani"
                },
                new Author
                {
                    Id = 2,
                    Name = "Anthony Alicea"
                },
                new Author
                {
                    Id = 3,
                    Name = "Eric Wise"
                },
                new Author
                {
                    Id = 4,
                    Name = "Tom Owsiak"
                },
                new Author
                {
                    Id = 5,
                    Name = "John Smith"
                }
            };

            foreach (var author in authors)
                modelBuilder.Entity<Author>().HasData(author);
            #endregion

            #region Add Courses
            var courses = new List<Course>
            {
                new Course //0
                {
                    Id = 1,
                    Name = "C# Basics",
                    //Author = authors[0],
                    AuthorId = authors[0].Id,
                    FullPrice = 49,
                    Description = "Description for C# Basics",
                    Level = 1
                    //CourseTags = new Collection<CourseTags>()
                    //{
                    //  new CourseTags(){TagId= tags["c#"].Id }
                    //}
                },
                new Course //1
                {
                    Id = 2,
                    Name = "C# Intermediate",
                    //Author = authors[0],
                    AuthorId = authors[0].Id,
                    FullPrice = 49,
                    Description = "Description for C# Intermediate",
                    Level = 2
                    //CourseTags = new Collection<CourseTags>()
                    //{
                    //    new CourseTags(){TagId= tags["c#"].Id },
                    //    new CourseTags(){TagId= tags["oop"].Id }
                    //}
                },
                new Course //2
                {
                    Id = 3,
                    Name = "C# Advanced",
                    //Author = authors[0],
                    AuthorId = authors[0].Id,
                    FullPrice = 69,
                    Description = "Description for C# Advanced",
                    Level = 3
                    // CourseTags = new Collection<CourseTags>()
                    //{
                    //     new CourseTags(){TagId= tags["c#"].Id }
                    //}
                },
                new Course // 3
                {
                    Id = 4,
                    Name = "Javascript: Understanding the Weird Parts",
                    //Author = authors[1],
                    AuthorId = authors[1].Id,
                    FullPrice = 149,
                    Description = "Description for Javascript",
                    Level = 2
                    // CourseTags = new Collection<CourseTags>()
                    //{
                    //    new CourseTags(){TagId= tags["javascript"].Id }
                    //}
                },
                new Course // 4
                 {
                    Id = 5,
                    Name = "Learn and Understand AngularJS",
                    //Author = authors[1],
                    AuthorId = authors[1].Id,
                    FullPrice = 99,
                    Description = "Description for AngularJS",
                    Level = 2
                    // CourseTags = new Collection<CourseTags>()
                    //{
                    //      new CourseTags(){TagId= tags["angularjs"].Id }
                    //}
                },
                new Course //5
                {
                    Id = 6,
                    Name = "Learn and Understand NodeJS",
                    //Author = authors[1],
                    AuthorId = authors[1].Id,
                    FullPrice = 149,
                    Description = "Description for NodeJS",
                    Level = 2
                    // CourseTags = new Collection<CourseTags>()
                    //{
                    //    new CourseTags(){TagId= tags["nodejs"].Id }
                    //}
                },
                new Course // 6
                {
                    Id = 7,
                    Name = "Programming for Complete Beginners",
                    //Author = authors[2],
                    AuthorId = authors[2].Id,
                    FullPrice = 45,
                    Description = "Description for Programming for Beginners",
                    Level = 1
                    // CourseTags = new Collection<CourseTags>()
                    //{
                    //     new CourseTags(){TagId= tags["c#"].Id }
                    // }
                },
                new Course //7
                {
                    Id = 8,
                    Name = "A 16 Hour C# Course with Visual Studio 2013",
                    //Author = authors[3],
                    AuthorId = authors[3].Id,
                    FullPrice = 150,
                    Description = "Description 16 Hour Course",
                    Level = 1
                    // CourseTags = new Collection<CourseTags>()
                    //{
                    //    new CourseTags(){TagId= tags["c#"].Id }
                    //}
                },
                new Course //8
                {
                   
                    Id = 9,
                    Name = "Learn JavaScript Through Visual Studio 2013",
                    //Author = authors[3],
                    AuthorId = authors[3].Id,
                    FullPrice = 20,
                    Description = "Description Learn Javascript",
                    Level = 1,
                     
                }
            };

            foreach (var course in courses)
                 modelBuilder.Entity<Course>().HasData(course);
            #endregion

            #region Add CourseTags
            var ct = new List<CourseTags>
            {
                new CourseTags //1
                {
                     TagId = tags["c#"].Id,
                    CourseId = 1
                },
                 new CourseTags //2
                {
                     TagId = tags["oop"].Id,
                    CourseId = 2
                },
                 new CourseTags //3
                {
                     TagId = tags["c#"].Id,
                    CourseId = 3
                },

                new CourseTags //4
                {
                     TagId = tags["javascript"].Id,
                    CourseId = 4
                },
               new CourseTags //5
                {
                     TagId = tags["angularjs"].Id,
                    CourseId = 5
                },
               new CourseTags //6
                {
                     TagId = tags["nodejs"].Id,
                    CourseId = 6
                },
                new CourseTags //7
                {
                     TagId = tags["c#"].Id,
                    CourseId = 7
                },
                new CourseTags //8
                {
                     TagId = tags["c#"].Id,
                    CourseId = 8
                },
                new CourseTags //9
                {
                     TagId = tags["javascript"].Id,
                    CourseId = 9
                }
                
            };

            foreach (var ctag in ct)
                modelBuilder.Entity<CourseTags>().HasData(ctag);
            #endregion
        }
    }
}
//public class PlutoContext : DbContext
//{
//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {
//        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PlutoContext.Basics;Trusted_Connection=True;ConnectRetryCount=0");
//    }

//    public virtual DbSet<Author> Authors { get; set; }
//    public virtual DbSet<Course> Courses { get; set; }
//    public virtual DbSet<Tag> Tags { get; set; }

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Course>(c => c.Description)
//           .IsRequired()
//           .HasMaxLength(2000);

//        modelBuilder.Entity<Course>(c => c.Name)
//            .IsRequired()
//            .HasMaxLength(255);

//        modelBuilder.Entity<Course>.HasRequired(c => c.Author)
//            .WithMany(a => a.Courses)
                                                  //            .HasForeignKey(c => c.AuthorId)
                                                  //            .WillCascadeOnDelete(false);

//        HasRequired(c => c.Cover)
//            .WithRequiredPrincipal(c => c.Course);

//        HasMany(c => c.Tags)
//            .WithMany(t => t.Courses)
//            .Map(m =>
//            {
//                m.ToTable("CourseTags");
//                m.MapLeftKey("CourseId");
//                m.MapRightKey("TagId");
//            });

//        //modelBuilder.   Configurations.Add(new CourseConfiguration());
//    }
