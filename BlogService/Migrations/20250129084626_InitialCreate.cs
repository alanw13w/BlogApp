//using Microsoft.EntityFrameworkCore.Migrations;

//#nullable disable

//namespace BlogService.Migrations
//{
//    /// <inheritdoc />
//    public partial class InitialCreate : Migration
//    {
//        /// <inheritdoc />
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.CreateTable(
//                name: "Blogs",
//                columns: table => new
//                {
//                    BlogModelId = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Blogs", x => x.BlogModelId);
//                });

//            migrationBuilder.CreateTable(
//                name: "Users",
//                columns: table => new
//                {
//                    UserModelId = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    Pseudo = table.Column<string>(type: "nvarchar(max)", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Users", x => x.UserModelId);
//                });

//            migrationBuilder.CreateTable(
//                name: "Posts",
//                columns: table => new
//                {
//                    PostModelId = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    DateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
//                    BlogModelId = table.Column<int>(type: "int", nullable: false),
//                    UserModelId = table.Column<int>(type: "int", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Posts", x => x.PostModelId);
//                    table.ForeignKey(
//                        name: "FK_Posts_Blogs_BlogModelId",
//                        column: x => x.BlogModelId,
//                        principalTable: "Blogs",
//                        principalColumn: "BlogModelId",
//                        onDelete: ReferentialAction.Cascade);
//                    table.ForeignKey(
//                        name: "FK_Posts_Users_UserModelId",
//                        column: x => x.UserModelId,
//                        principalTable: "Users",
//                        principalColumn: "UserModelId",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateIndex(
//                name: "IX_Posts_BlogModelId",
//                table: "Posts",
//                column: "BlogModelId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Posts_UserModelId",
//                table: "Posts",
//                column: "UserModelId");
//        }

//        /// <inheritdoc />
//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropTable(
//                name: "Posts");

//            migrationBuilder.DropTable(
//                name: "Blogs");

//            migrationBuilder.DropTable(
//                name: "Users");
//        }
//    }
//}
