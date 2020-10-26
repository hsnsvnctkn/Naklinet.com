using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Naklinet.Repository.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CUSTOMER",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Surname = table.Column<string>(maxLength: 40, nullable: false),
                    Phone = table.Column<string>(maxLength: 14, nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DOCUMENTTYPES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOCUMENTTYPES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FACTORS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomCountFactor = table.Column<double>(nullable: false),
                    FloorFactor = table.Column<double>(nullable: false),
                    MontageFactor = table.Column<double>(nullable: false),
                    WayDiff = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FACTORS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PACKAGINGOPTIONS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionName = table.Column<string>(nullable: false),
                    OptionFactor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACKAGINGOPTIONS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RESERVATIONSTATUS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESERVATIONSTATUS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ROOMCOUNT",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<string>(nullable: false),
                    BasePrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROOMCOUNT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SHIPPERS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    TaxNumber = table.Column<string>(nullable: true),
                    TaxAuthority = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(maxLength: 14, nullable: false),
                    FoundingDate = table.Column<DateTime>(nullable: false),
                    Fax = table.Column<string>(maxLength: 14, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHIPPERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VEHICLETYPES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEHICLETYPES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DOCUMENTS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    TypeID = table.Column<int>(nullable: false),
                    ShipperID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOCUMENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DOCUMENTS_SHIPPERS_ShipperID",
                        column: x => x.ShipperID,
                        principalTable: "SHIPPERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DOCUMENTS_DOCUMENTTYPES_TypeID",
                        column: x => x.TypeID,
                        principalTable: "DOCUMENTTYPES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Surname = table.Column<string>(maxLength: 50, nullable: false),
                    Phone = table.Column<string>(maxLength: 14, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    RoleID = table.Column<int>(nullable: false),
                    ShipperID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EMPLOYEES_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EMPLOYEES_SHIPPERS_ShipperID",
                        column: x => x.ShipperID,
                        principalTable: "SHIPPERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VEHICLES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicensePlate = table.Column<string>(maxLength: 10, nullable: false),
                    TypeID = table.Column<int>(nullable: false),
                    ShipperID = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEHICLES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VEHICLES_SHIPPERS_ShipperID",
                        column: x => x.ShipperID,
                        principalTable: "SHIPPERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VEHICLES_VEHICLETYPES_TypeID",
                        column: x => x.TypeID,
                        principalTable: "VEHICLETYPES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RESERVATIONS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(nullable: false),
                    ShipperID = table.Column<int>(nullable: false),
                    PriceToCustomer = table.Column<double>(nullable: false),
                    PriceToShipper = table.Column<double>(nullable: false),
                    ReservationDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    TransportDate = table.Column<DateTime>(nullable: false),
                    Montage = table.Column<bool>(nullable: false),
                    PackagingOptionID = table.Column<int>(nullable: false),
                    DriverID = table.Column<int>(nullable: false),
                    StatusID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESERVATIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RESERVATIONS_CUSTOMER_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "CUSTOMER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RESERVATIONS_EMPLOYEES_DriverID",
                        column: x => x.DriverID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RESERVATIONS_PACKAGINGOPTIONS_PackagingOptionID",
                        column: x => x.PackagingOptionID,
                        principalTable: "PACKAGINGOPTIONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RESERVATIONS_SHIPPERS_ShipperID",
                        column: x => x.ShipperID,
                        principalTable: "SHIPPERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RESERVATIONS_RESERVATIONSTATUS_StatusID",
                        column: x => x.StatusID,
                        principalTable: "RESERVATIONSTATUS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "COMMENTS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipperID = table.Column<int>(nullable: false),
                    CustomerID = table.Column<int>(nullable: false),
                    ReservationID = table.Column<int>(nullable: false),
                    CommentDate = table.Column<DateTime>(nullable: false),
                    Check = table.Column<bool>(nullable: false),
                    Comment = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMMENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_COMMENTS_CUSTOMER_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "CUSTOMER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COMMENTS_RESERVATIONS_ReservationID",
                        column: x => x.ReservationID,
                        principalTable: "RESERVATIONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COMMENTS_SHIPPERS_ShipperID",
                        column: x => x.ShipperID,
                        principalTable: "SHIPPERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FROMADDRESSES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Elevator = table.Column<bool>(nullable: false),
                    City = table.Column<string>(maxLength: 20, nullable: false),
                    District = table.Column<string>(maxLength: 30, nullable: false),
                    State = table.Column<string>(nullable: false),
                    Floor = table.Column<int>(maxLength: 20, nullable: false),
                    RoomCountID = table.Column<int>(nullable: false),
                    ReservationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FROMADDRESSES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FROMADDRESSES_RESERVATIONS_ReservationID",
                        column: x => x.ReservationID,
                        principalTable: "RESERVATIONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FROMADDRESSES_ROOMCOUNT_RoomCountID",
                        column: x => x.RoomCountID,
                        principalTable: "ROOMCOUNT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "POINTS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipperID = table.Column<int>(nullable: false),
                    Time = table.Column<int>(maxLength: 10, nullable: false),
                    Contentment = table.Column<int>(maxLength: 10, nullable: false),
                    Cominication = table.Column<int>(maxLength: 10, nullable: false),
                    CustomerID = table.Column<int>(nullable: false),
                    ReservationID = table.Column<int>(nullable: false),
                    PointDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POINTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_POINTS_CUSTOMER_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "CUSTOMER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_POINTS_RESERVATIONS_ReservationID",
                        column: x => x.ReservationID,
                        principalTable: "RESERVATIONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_POINTS_SHIPPERS_ShipperID",
                        column: x => x.ShipperID,
                        principalTable: "SHIPPERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TOADDRESSES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Elevator = table.Column<bool>(nullable: false),
                    City = table.Column<string>(maxLength: 20, nullable: false),
                    District = table.Column<string>(maxLength: 30, nullable: false),
                    State = table.Column<string>(nullable: false),
                    Floor = table.Column<int>(maxLength: 20, nullable: false),
                    RoomCountID = table.Column<int>(nullable: false),
                    ReservationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TOADDRESSES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TOADDRESSES_RESERVATIONS_ReservationID",
                        column: x => x.ReservationID,
                        principalTable: "RESERVATIONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TOADDRESSES_ROOMCOUNT_RoomCountID",
                        column: x => x.RoomCountID,
                        principalTable: "ROOMCOUNT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CUSTOMER",
                columns: new[] { "ID", "Email", "Name", "Phone", "Surname" },
                values: new object[,]
                {
                    { 1, null, "Fatih", "05322716155", "Balcıoğlu" },
                    { 2, null, "Yunus", "05321111111", "Gülbeyen" }
                });

            migrationBuilder.InsertData(
                table: "DOCUMENTTYPES",
                columns: new[] { "ID", "TypeName" },
                values: new object[,]
                {
                    { 1, "İmza Sürküsü" },
                    { 2, "Vergi Levhası" }
                });

            migrationBuilder.InsertData(
                table: "FACTORS",
                columns: new[] { "ID", "FloorFactor", "MontageFactor", "RoomCountFactor", "WayDiff" },
                values: new object[] { 1, 100.0, 150.0, 120.0, 3.0 });

            migrationBuilder.InsertData(
                table: "PACKAGINGOPTIONS",
                columns: new[] { "ID", "OptionFactor", "OptionName" },
                values: new object[,]
                {
                    { 1, 1.7, "Bütün Eşyalar" },
                    { 2, 1.3, "Sadece Beyaz Eşyalar" },
                    { 3, 0.0, "Kendim Paketleyeceğim" }
                });

            migrationBuilder.InsertData(
                table: "RESERVATIONSTATUS",
                columns: new[] { "ID", "StatusName" },
                values: new object[,]
                {
                    { 4, "Tamamlandı" },
                    { 3, "Taşıma Durumunda" },
                    { 1, "Onay Bekliyor" },
                    { 2, "Onaylandı" }
                });

            migrationBuilder.InsertData(
                table: "ROOMCOUNT",
                columns: new[] { "ID", "BasePrice", "Count" },
                values: new object[,]
                {
                    { 1, 400.0, "1+1" },
                    { 2, 500.0, "2+1" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Yönetici" },
                    { 2, "Sürücü" },
                    { 3, "Çalışan" }
                });

            migrationBuilder.InsertData(
                table: "SHIPPERS",
                columns: new[] { "ID", "Address", "CreatedDate", "Fax", "FoundingDate", "Name", "Phone", "Status", "TaxAuthority", "TaxNumber" },
                values: new object[,]
                {
                    { 1, "Test Nakliyeci Adres 1", new DateTime(2020, 10, 16, 1, 37, 45, 713, DateTimeKind.Local).AddTicks(7562), null, new DateTime(2011, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test Nakliyeci Adı 1", "05363403660", true, "Samandıra", "124124123" },
                    { 2, "Test Nakliyeci Adres 2", new DateTime(2020, 10, 16, 1, 37, 45, 714, DateTimeKind.Local).AddTicks(7003), null, new DateTime(2012, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test Nakliyeci Adı 2", "05322322525", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "VEHICLETYPES",
                columns: new[] { "ID", "TypeName" },
                values: new object[,]
                {
                    { 1, "Kapalı Kasa" },
                    { 2, "Açık Kasa" }
                });

            migrationBuilder.InsertData(
                table: "DOCUMENTS",
                columns: new[] { "ID", "Name", "ShipperID", "TypeID" },
                values: new object[,]
                {
                    { 1, "İmza Sürküsü - 1", 1, 1 },
                    { 2, "Vergi Levhası - 1", 1, 2 },
                    { 3, "Vergi Levhası", 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "EMPLOYEES",
                columns: new[] { "ID", "Email", "Name", "Phone", "RoleID", "ShipperID", "Surname" },
                values: new object[,]
                {
                    { 1, null, "Çalışan 1", "05363403660", 3, 1, "Çalışan 1 Soyad" },
                    { 2, "test@gmail.com", "Yönetici", "05353563535", 1, 1, "Yönetici Soyad" },
                    { 3, null, "Sürücü 1", "05363403660", 2, 1, "Sürücü 1 Soyad" },
                    { 4, null, "Çalışan 2", "05363403660", 3, 1, "Çalışan 2 Soyad" },
                    { 5, null, "Yönetici 2. Nakliyeci", "05363403660", 1, 2, "Yönetici Soyad" }
                });

            migrationBuilder.InsertData(
                table: "VEHICLES",
                columns: new[] { "ID", "Height", "LicensePlate", "ShipperID", "TypeID", "Weight" },
                values: new object[,]
                {
                    { 1, 250, "06MNF20", 1, 1, 200 },
                    { 2, 180, "34GH7218", 1, 2, 130 },
                    { 3, 180, "34CRK350", 2, 2, 130 }
                });

            migrationBuilder.InsertData(
                table: "RESERVATIONS",
                columns: new[] { "ID", "CreatedDate", "CustomerID", "DriverID", "Montage", "PackagingOptionID", "PriceToCustomer", "PriceToShipper", "ReservationDate", "ShipperID", "StatusID", "TransportDate" },
                values: new object[] { 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, true, 1, 2200.0, 1900.0, new DateTime(2020, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, new DateTime(2020, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "RESERVATIONS",
                columns: new[] { "ID", "CreatedDate", "CustomerID", "DriverID", "Montage", "PackagingOptionID", "PriceToCustomer", "PriceToShipper", "ReservationDate", "ShipperID", "StatusID", "TransportDate" },
                values: new object[] { 2, new DateTime(2020, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, false, 1, 1700.0, 1500.0, new DateTime(2020, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "COMMENTS",
                columns: new[] { "ID", "Check", "Comment", "CommentDate", "CustomerID", "ReservationID", "ShipperID" },
                values: new object[] { 1, true, "Hasarsız taşındı eşyalarım fakat iletişim zayıf", new DateTime(2020, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "FROMADDRESSES",
                columns: new[] { "ID", "City", "District", "Elevator", "Floor", "ReservationID", "RoomCountID", "State" },
                values: new object[,]
                {
                    { 1, "Istanbul", "Sancaktepe", false, 3, 1, 2, "Osmangazi" },
                    { 2, "Istanbul", "Pendik", true, 2, 2, 2, "Kurtköy" }
                });

            migrationBuilder.InsertData(
                table: "POINTS",
                columns: new[] { "ID", "Cominication", "Contentment", "CustomerID", "PointDate", "ReservationID", "ShipperID", "Time" },
                values: new object[] { 1, 5, 8, 1, new DateTime(2020, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 9 });

            migrationBuilder.InsertData(
                table: "TOADDRESSES",
                columns: new[] { "ID", "City", "District", "Elevator", "Floor", "ReservationID", "RoomCountID", "State" },
                values: new object[,]
                {
                    { 1, "Istanbul", "Maltepe", true, 3, 1, 2, "Altayçeşme" },
                    { 2, "Istanbul", "Üsküdar", true, 1, 2, 1, "Kısıklı" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_COMMENTS_CustomerID",
                table: "COMMENTS",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_COMMENTS_ReservationID",
                table: "COMMENTS",
                column: "ReservationID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_COMMENTS_ShipperID",
                table: "COMMENTS",
                column: "ShipperID");

            migrationBuilder.CreateIndex(
                name: "IX_DOCUMENTS_ShipperID",
                table: "DOCUMENTS",
                column: "ShipperID");

            migrationBuilder.CreateIndex(
                name: "IX_DOCUMENTS_TypeID",
                table: "DOCUMENTS",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_RoleID",
                table: "EMPLOYEES",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_ShipperID",
                table: "EMPLOYEES",
                column: "ShipperID");

            migrationBuilder.CreateIndex(
                name: "IX_FROMADDRESSES_ReservationID",
                table: "FROMADDRESSES",
                column: "ReservationID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FROMADDRESSES_RoomCountID",
                table: "FROMADDRESSES",
                column: "RoomCountID");

            migrationBuilder.CreateIndex(
                name: "IX_POINTS_CustomerID",
                table: "POINTS",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_POINTS_ReservationID",
                table: "POINTS",
                column: "ReservationID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_POINTS_ShipperID",
                table: "POINTS",
                column: "ShipperID");

            migrationBuilder.CreateIndex(
                name: "IX_RESERVATIONS_CustomerID",
                table: "RESERVATIONS",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_RESERVATIONS_DriverID",
                table: "RESERVATIONS",
                column: "DriverID");

            migrationBuilder.CreateIndex(
                name: "IX_RESERVATIONS_PackagingOptionID",
                table: "RESERVATIONS",
                column: "PackagingOptionID");

            migrationBuilder.CreateIndex(
                name: "IX_RESERVATIONS_ShipperID",
                table: "RESERVATIONS",
                column: "ShipperID");

            migrationBuilder.CreateIndex(
                name: "IX_RESERVATIONS_StatusID",
                table: "RESERVATIONS",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_TOADDRESSES_ReservationID",
                table: "TOADDRESSES",
                column: "ReservationID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TOADDRESSES_RoomCountID",
                table: "TOADDRESSES",
                column: "RoomCountID");

            migrationBuilder.CreateIndex(
                name: "IX_VEHICLES_ShipperID",
                table: "VEHICLES",
                column: "ShipperID");

            migrationBuilder.CreateIndex(
                name: "IX_VEHICLES_TypeID",
                table: "VEHICLES",
                column: "TypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COMMENTS");

            migrationBuilder.DropTable(
                name: "DOCUMENTS");

            migrationBuilder.DropTable(
                name: "FACTORS");

            migrationBuilder.DropTable(
                name: "FROMADDRESSES");

            migrationBuilder.DropTable(
                name: "POINTS");

            migrationBuilder.DropTable(
                name: "TOADDRESSES");

            migrationBuilder.DropTable(
                name: "VEHICLES");

            migrationBuilder.DropTable(
                name: "DOCUMENTTYPES");

            migrationBuilder.DropTable(
                name: "RESERVATIONS");

            migrationBuilder.DropTable(
                name: "ROOMCOUNT");

            migrationBuilder.DropTable(
                name: "VEHICLETYPES");

            migrationBuilder.DropTable(
                name: "CUSTOMER");

            migrationBuilder.DropTable(
                name: "EMPLOYEES");

            migrationBuilder.DropTable(
                name: "PACKAGINGOPTIONS");

            migrationBuilder.DropTable(
                name: "RESERVATIONSTATUS");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "SHIPPERS");
        }
    }
}
