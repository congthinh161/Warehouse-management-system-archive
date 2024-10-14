using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WHM.Data.EF.Migrations
{
    public partial class Init_Db_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WHM_Account",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreateUser = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateUser = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WHM_Account", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "WHM_Attribute",
                columns: table => new
                {
                    AttributeId = table.Column<Guid>(type: "uuid", nullable: false),
                    AttributeName = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    AttributeDescription = table.Column<string>(type: "text", nullable: true),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreateUser = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateUser = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WHM_Attribute", x => x.AttributeId);
                });

            migrationBuilder.CreateTable(
                name: "WHM_Category",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryName = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CategoryDescription = table.Column<string>(type: "text", nullable: true),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreateUser = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateUser = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WHM_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "WHM_Client",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    DisplayName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    MoreInfo = table.Column<string>(type: "text", nullable: true),
                    IsVip = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreateUser = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateUser = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WHM_Client", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "WHM_ServiceType",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WHM_ServiceType", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "WHM_Suplier",
                columns: table => new
                {
                    SuplierId = table.Column<Guid>(type: "uuid", nullable: false),
                    DisplayName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    MoreInfo = table.Column<string>(type: "text", nullable: true),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreateUser = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateUser = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WHM_Suplier", x => x.SuplierId);
                });

            migrationBuilder.CreateTable(
                name: "WHM_AttributeValue",
                columns: table => new
                {
                    AttributeValueId = table.Column<Guid>(type: "uuid", nullable: false),
                    AttributeId = table.Column<Guid>(type: "uuid", nullable: false),
                    AttributeValue = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    AttributeValueDescription = table.Column<string>(type: "text", nullable: true),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreateUser = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateUser = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WHM_AttributeValue", x => x.AttributeValueId);
                    table.ForeignKey(
                        name: "FK_WHM_AttributeValue_WHM_Attribute_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "WHM_Attribute",
                        principalColumn: "AttributeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WHM_CategoryAttribute",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    AttributeId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryAttributeId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreateUser = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateUser = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WHM_CategoryAttribute", x => new { x.CategoryId, x.AttributeId });
                    table.ForeignKey(
                        name: "FK_WHM_CategoryAttribute_WHM_Attribute_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "WHM_Attribute",
                        principalColumn: "AttributeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WHM_CategoryAttribute_WHM_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "WHM_Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WHM_Product",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductName = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    ProductDescription = table.Column<string>(type: "text", nullable: true),
                    EstimatedPrice = table.Column<float>(type: "real", nullable: false),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreateUser = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateUser = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WHM_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_WHM_Product_WHM_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "WHM_Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WHM_ProductOuput",
                columns: table => new
                {
                    ProdOuputId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    ServiceFee = table.Column<float>(type: "real", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    PrePayment = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ServiceTypeId = table.Column<int>(type: "integer", nullable: false),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreateUser = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateUser = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WHM_ProductOuput", x => x.ProdOuputId);
                    table.ForeignKey(
                        name: "FK_WHM_ProductOuput_WHM_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "WHM_Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WHM_ProductOuput_WHM_ServiceType_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "WHM_ServiceType",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WHM_ProductInput",
                columns: table => new
                {
                    ProdInputId = table.Column<Guid>(type: "uuid", nullable: false),
                    SuplierId = table.Column<Guid>(type: "uuid", nullable: false),
                    PreMoney = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreateUser = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateUser = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WHM_ProductInput", x => x.ProdInputId);
                    table.ForeignKey(
                        name: "FK_WHM_ProductInput_WHM_Suplier_SuplierId",
                        column: x => x.SuplierId,
                        principalTable: "WHM_Suplier",
                        principalColumn: "SuplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WHM_ProductAttributeValue",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    AttributeValueId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreateUser = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateUser = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WHM_ProductAttributeValue", x => new { x.ProductId, x.AttributeValueId });
                    table.ForeignKey(
                        name: "FK_WHM_ProductAttributeValue_WHM_AttributeValue_AttributeValue~",
                        column: x => x.AttributeValueId,
                        principalTable: "WHM_AttributeValue",
                        principalColumn: "AttributeValueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WHM_ProductAttributeValue_WHM_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "WHM_Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WHM_ProductOutputDetails",
                columns: table => new
                {
                    ProdOutputDetailId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProdOutputId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    OutputPrice = table.Column<float>(type: "real", nullable: false),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreateUser = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateUser = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WHM_ProductOutputDetails", x => x.ProdOutputDetailId);
                    table.ForeignKey(
                        name: "FK_WHM_ProductOutputDetails_WHM_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "WHM_Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WHM_ProductOutputDetails_WHM_ProductOuput_ProdOutputId",
                        column: x => x.ProdOutputId,
                        principalTable: "WHM_ProductOuput",
                        principalColumn: "ProdOuputId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WHM_ProductInputDetails",
                columns: table => new
                {
                    ProdInputDetailId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProdInputId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    InputPrice = table.Column<float>(type: "real", nullable: false),
                    IsDelete = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreateUser = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateUser = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WHM_ProductInputDetails", x => x.ProdInputDetailId);
                    table.ForeignKey(
                        name: "FK_WHM_ProductInputDetails_WHM_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "WHM_Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WHM_ProductInputDetails_WHM_ProductInput_ProdInputId",
                        column: x => x.ProdInputId,
                        principalTable: "WHM_ProductInput",
                        principalColumn: "ProdInputId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WHM_AttributeValue_AttributeId",
                table: "WHM_AttributeValue",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_WHM_CategoryAttribute_AttributeId",
                table: "WHM_CategoryAttribute",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_WHM_Product_CategoryId",
                table: "WHM_Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WHM_ProductAttributeValue_AttributeValueId",
                table: "WHM_ProductAttributeValue",
                column: "AttributeValueId");

            migrationBuilder.CreateIndex(
                name: "IX_WHM_ProductInput_SuplierId",
                table: "WHM_ProductInput",
                column: "SuplierId");

            migrationBuilder.CreateIndex(
                name: "IX_WHM_ProductInputDetails_ProdInputId",
                table: "WHM_ProductInputDetails",
                column: "ProdInputId");

            migrationBuilder.CreateIndex(
                name: "IX_WHM_ProductInputDetails_ProductId",
                table: "WHM_ProductInputDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WHM_ProductOuput_ClientId",
                table: "WHM_ProductOuput",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_WHM_ProductOuput_ServiceTypeId",
                table: "WHM_ProductOuput",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WHM_ProductOutputDetails_ProdOutputId",
                table: "WHM_ProductOutputDetails",
                column: "ProdOutputId");

            migrationBuilder.CreateIndex(
                name: "IX_WHM_ProductOutputDetails_ProductId",
                table: "WHM_ProductOutputDetails",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WHM_Account");

            migrationBuilder.DropTable(
                name: "WHM_CategoryAttribute");

            migrationBuilder.DropTable(
                name: "WHM_ProductAttributeValue");

            migrationBuilder.DropTable(
                name: "WHM_ProductInputDetails");

            migrationBuilder.DropTable(
                name: "WHM_ProductOutputDetails");

            migrationBuilder.DropTable(
                name: "WHM_AttributeValue");

            migrationBuilder.DropTable(
                name: "WHM_ProductInput");

            migrationBuilder.DropTable(
                name: "WHM_Product");

            migrationBuilder.DropTable(
                name: "WHM_ProductOuput");

            migrationBuilder.DropTable(
                name: "WHM_Attribute");

            migrationBuilder.DropTable(
                name: "WHM_Suplier");

            migrationBuilder.DropTable(
                name: "WHM_Category");

            migrationBuilder.DropTable(
                name: "WHM_Client");

            migrationBuilder.DropTable(
                name: "WHM_ServiceType");
        }
    }
}
