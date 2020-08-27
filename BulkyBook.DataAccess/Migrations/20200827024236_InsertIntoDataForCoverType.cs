using Microsoft.EntityFrameworkCore.Migrations;

namespace BulkyBook.DataAccess.Migrations
{
    public partial class InsertIntoDataForCoverType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO CoverTypes(Name) VALUES ('Test')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
