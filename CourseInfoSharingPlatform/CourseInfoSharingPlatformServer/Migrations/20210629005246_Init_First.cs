using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseInfoSharingPlatformServer.Migrations
{
    public partial class Init_First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ADMIN",
                columns: table => new
                {
                    AdminName = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN", x => x.AdminName);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "COURSE",
                columns: table => new
                {
                    CourseId = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TeacherName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Department = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BookName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Introduction = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HeatNum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COURSE", x => x.CourseId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "COURSE_USER_SCORE",
                columns: table => new
                {
                    CUSId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CourseId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COURSE_USER_SCORE", x => x.CUSId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Grade = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Introduction = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Major = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.UserName);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CourseUser",
                columns: table => new
                {
                    LikeCoursesCourseId = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserWhoLikedCourseUserName = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseUser", x => new { x.LikeCoursesCourseId, x.UserWhoLikedCourseUserName });
                    table.ForeignKey(
                        name: "FK_CourseUser_COURSE_LikeCoursesCourseId",
                        column: x => x.LikeCoursesCourseId,
                        principalTable: "COURSE",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseUser_USER_UserWhoLikedCourseUserName",
                        column: x => x.UserWhoLikedCourseUserName,
                        principalTable: "USER",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "QUESTION",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LikeNum = table.Column<int>(type: "int", nullable: false),
                    Detail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsReported = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Reason = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RelatedCourseCourseId = table.Column<string>(type: "varchar(95)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RelatedUserUserName = table.Column<string>(type: "varchar(95)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUESTION", x => x.QuestionId);
                    table.ForeignKey(
                        name: "FK_QUESTION_COURSE_RelatedCourseCourseId",
                        column: x => x.RelatedCourseCourseId,
                        principalTable: "COURSE",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QUESTION_USER_RelatedUserUserName",
                        column: x => x.RelatedUserUserName,
                        principalTable: "USER",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "COMMENT",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LikeNum = table.Column<int>(type: "int", nullable: false),
                    Detail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsReported = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Reason = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RelatedUserUserName = table.Column<string>(type: "varchar(95)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RelatedQuestionQuestionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMMENT", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_COMMENT_QUESTION_RelatedQuestionQuestionId",
                        column: x => x.RelatedQuestionQuestionId,
                        principalTable: "QUESTION",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COMMENT_USER_RelatedUserUserName",
                        column: x => x.RelatedUserUserName,
                        principalTable: "USER",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TAG",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Detail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LikeNum = table.Column<int>(type: "int", nullable: false),
                    RelatedQuestionQuestionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAG", x => x.TagId);
                    table.ForeignKey(
                        name: "FK_TAG_QUESTION_RelatedQuestionQuestionId",
                        column: x => x.RelatedQuestionQuestionId,
                        principalTable: "QUESTION",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_COMMENT_RelatedQuestionQuestionId",
                table: "COMMENT",
                column: "RelatedQuestionQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_COMMENT_RelatedUserUserName",
                table: "COMMENT",
                column: "RelatedUserUserName");

            migrationBuilder.CreateIndex(
                name: "IX_CourseUser_UserWhoLikedCourseUserName",
                table: "CourseUser",
                column: "UserWhoLikedCourseUserName");

            migrationBuilder.CreateIndex(
                name: "IX_QUESTION_RelatedCourseCourseId",
                table: "QUESTION",
                column: "RelatedCourseCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_QUESTION_RelatedUserUserName",
                table: "QUESTION",
                column: "RelatedUserUserName");

            migrationBuilder.CreateIndex(
                name: "IX_TAG_RelatedQuestionQuestionId",
                table: "TAG",
                column: "RelatedQuestionQuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ADMIN");

            migrationBuilder.DropTable(
                name: "COMMENT");

            migrationBuilder.DropTable(
                name: "COURSE_USER_SCORE");

            migrationBuilder.DropTable(
                name: "CourseUser");

            migrationBuilder.DropTable(
                name: "TAG");

            migrationBuilder.DropTable(
                name: "QUESTION");

            migrationBuilder.DropTable(
                name: "COURSE");

            migrationBuilder.DropTable(
                name: "USER");
        }
    }
}
