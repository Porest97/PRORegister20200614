using Microsoft.EntityFrameworkCore.Migrations;

namespace PRORegister.Migrations
{
    public partial class IdentityUserFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_IdentityUser_SiteId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUser_Company_CompanyId",
                table: "IdentityUser");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUser_Person_PersonId",
                table: "IdentityUser");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUser_Person_PersonId1",
                table: "IdentityUser");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUser_SiteRole_SiteRoleId",
                table: "IdentityUser");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUser_SiteStatus_SiteStatusId",
                table: "IdentityUser");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUser_SiteType_SiteTypeId",
                table: "IdentityUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Incident_IdentityUser_SiteId",
                table: "Incident");

            migrationBuilder.DropForeignKey(
                name: "FK_Offer_IdentityUser_SiteId",
                table: "Offer");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_IdentityUser_SiteId",
                table: "Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUser",
                table: "IdentityUser");

            migrationBuilder.RenameTable(
                name: "IdentityUser",
                newName: "Site");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUser_SiteTypeId",
                table: "Site",
                newName: "IX_Site_SiteTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUser_SiteStatusId",
                table: "Site",
                newName: "IX_Site_SiteStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUser_SiteRoleId",
                table: "Site",
                newName: "IX_Site_SiteRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUser_PersonId1",
                table: "Site",
                newName: "IX_Site_PersonId1");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUser_PersonId",
                table: "Site",
                newName: "IX_Site_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUser_CompanyId",
                table: "Site",
                newName: "IX_Site_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Site",
                table: "Site",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_Site_SiteId",
                table: "Asset",
                column: "SiteId",
                principalTable: "Site",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Incident_Site_SiteId",
                table: "Incident",
                column: "SiteId",
                principalTable: "Site",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_Site_SiteId",
                table: "Offer",
                column: "SiteId",
                principalTable: "Site",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Site_SiteId",
                table: "Project",
                column: "SiteId",
                principalTable: "Site",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Site_Company_CompanyId",
                table: "Site",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Site_Person_PersonId",
                table: "Site",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Site_Person_PersonId1",
                table: "Site",
                column: "PersonId1",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Site_SiteRole_SiteRoleId",
                table: "Site",
                column: "SiteRoleId",
                principalTable: "SiteRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Site_SiteStatus_SiteStatusId",
                table: "Site",
                column: "SiteStatusId",
                principalTable: "SiteStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Site_SiteType_SiteTypeId",
                table: "Site",
                column: "SiteTypeId",
                principalTable: "SiteType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asset_Site_SiteId",
                table: "Asset");

            migrationBuilder.DropForeignKey(
                name: "FK_Incident_Site_SiteId",
                table: "Incident");

            migrationBuilder.DropForeignKey(
                name: "FK_Offer_Site_SiteId",
                table: "Offer");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Site_SiteId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Site_Company_CompanyId",
                table: "Site");

            migrationBuilder.DropForeignKey(
                name: "FK_Site_Person_PersonId",
                table: "Site");

            migrationBuilder.DropForeignKey(
                name: "FK_Site_Person_PersonId1",
                table: "Site");

            migrationBuilder.DropForeignKey(
                name: "FK_Site_SiteRole_SiteRoleId",
                table: "Site");

            migrationBuilder.DropForeignKey(
                name: "FK_Site_SiteStatus_SiteStatusId",
                table: "Site");

            migrationBuilder.DropForeignKey(
                name: "FK_Site_SiteType_SiteTypeId",
                table: "Site");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Site",
                table: "Site");

            migrationBuilder.RenameTable(
                name: "Site",
                newName: "IdentityUser");

            migrationBuilder.RenameIndex(
                name: "IX_Site_SiteTypeId",
                table: "IdentityUser",
                newName: "IX_IdentityUser_SiteTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Site_SiteStatusId",
                table: "IdentityUser",
                newName: "IX_IdentityUser_SiteStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Site_SiteRoleId",
                table: "IdentityUser",
                newName: "IX_IdentityUser_SiteRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Site_PersonId1",
                table: "IdentityUser",
                newName: "IX_IdentityUser_PersonId1");

            migrationBuilder.RenameIndex(
                name: "IX_Site_PersonId",
                table: "IdentityUser",
                newName: "IX_IdentityUser_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Site_CompanyId",
                table: "IdentityUser",
                newName: "IX_IdentityUser_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUser",
                table: "IdentityUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Asset_IdentityUser_SiteId",
                table: "Asset",
                column: "SiteId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUser_Company_CompanyId",
                table: "IdentityUser",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUser_Person_PersonId",
                table: "IdentityUser",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUser_Person_PersonId1",
                table: "IdentityUser",
                column: "PersonId1",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUser_SiteRole_SiteRoleId",
                table: "IdentityUser",
                column: "SiteRoleId",
                principalTable: "SiteRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUser_SiteStatus_SiteStatusId",
                table: "IdentityUser",
                column: "SiteStatusId",
                principalTable: "SiteStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUser_SiteType_SiteTypeId",
                table: "IdentityUser",
                column: "SiteTypeId",
                principalTable: "SiteType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Incident_IdentityUser_SiteId",
                table: "Incident",
                column: "SiteId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_IdentityUser_SiteId",
                table: "Offer",
                column: "SiteId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_IdentityUser_SiteId",
                table: "Project",
                column: "SiteId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
