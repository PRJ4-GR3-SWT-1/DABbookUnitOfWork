using Microsoft.EntityFrameworkCore.Migrations;

namespace QueriewsCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: false),
                    Level = table.Column<int>(nullable: false),
                    FullPrice = table.Column<float>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.Courses_dbo.Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseTags",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.CourseTags", x => new { x.CourseId, x.TagId });
                    table.ForeignKey(
                        name: "FK_dbo.CourseTags_dbo.Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.CourseTags_dbo.Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Covers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Covers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.Covers_dbo.Courses_Id",
                        column: x => x.Id,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mosh Hamedani" },
                    { 2, "Anthony Alicea" },
                    { 3, "Eric Wise" },
                    { 4, "Tom Owsiak" },
                    { 5, "John Smith" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "c#" },
                    { 2, "angularjs" },
                    { 3, "javascript" },
                    { 4, "nodejs" },
                    { 5, "oop" },
                    { 6, "linq" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "AuthorId", "Description", "FullPrice", "Level", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Description for C# Basics", 49f, 1, "C# Basics" },
                    { 2, 1, "Description for C# Intermediate", 49f, 2, "C# Intermediate" },
                    { 3, 1, "Description for C# Advanced", 69f, 3, "C# Advanced" },
                    { 4, 2, "Description for Javascript", 149f, 2, "Javascript: Understanding the Weird Parts" },
                    { 5, 2, "Description for AngularJS", 99f, 2, "Learn and Understand AngularJS" },
                    { 6, 2, "Description for NodeJS", 149f, 2, "Learn and Understand NodeJS" },
                    { 7, 3, "Description for Programming for Beginners", 45f, 1, "Programming for Complete Beginners" },
                    { 8, 4, "Description 16 Hour Course", 150f, 1, "A 16 Hour C# Course with Visual Studio 2013" },
                    { 9, 4, "Description Learn Javascript", 20f, 1, "Learn JavaScript Through Visual Studio 2013" }
                });

            migrationBuilder.InsertData(
                table: "CourseTags",
                columns: new[] { "CourseId", "TagId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 5 },
                    { 3, 1 },
                    { 4, 3 },
                    { 5, 2 },
                    { 6, 4 },
                    { 7, 1 },
                    { 8, 1 },
                    { 9, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorId",
                table: "Courses",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseId",
                table: "CourseTags",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TagId",
                table: "CourseTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Id",
                table: "Covers",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseTags");

            migrationBuilder.DropTable(
                name: "Covers");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
