using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectricitydataStore.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Electrycity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tinklas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Obt_Pavadinmas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Obj_Gv_Tipas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Obj_Numeris = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pplus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pl_T = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pminus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Electrycity", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Electrycity");
        }
    }
}
