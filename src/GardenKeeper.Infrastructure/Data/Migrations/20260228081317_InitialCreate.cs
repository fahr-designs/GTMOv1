using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GardenKeeper.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    HardinessZone = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GardenBeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    WidthFeet = table.Column<int>(type: "INTEGER", nullable: false),
                    LengthFeet = table.Column<int>(type: "INTEGER", nullable: false),
                    Season = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GardenBeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CommonName = table.Column<string>(type: "TEXT", nullable: false),
                    ScientificName = table.Column<string>(type: "TEXT", nullable: false),
                    PlantType = table.Column<int>(type: "INTEGER", nullable: false),
                    HardinessZones = table.Column<string>(type: "TEXT", nullable: false),
                    DaysToMaturity = table.Column<int>(type: "INTEGER", nullable: false),
                    SpacingInches = table.Column<double>(type: "REAL", nullable: false),
                    SunRequirement = table.Column<int>(type: "INTEGER", nullable: false),
                    WaterRequirement = table.Column<int>(type: "INTEGER", nullable: false),
                    CompanionPlants = table.Column<string>(type: "TEXT", nullable: false),
                    CropRotationNotes = table.Column<string>(type: "TEXT", nullable: false),
                    TypicalStartMethod = table.Column<int>(type: "INTEGER", nullable: false),
                    DataSource = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GardenBedId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlantId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EntryType = table.Column<int>(type: "INTEGER", nullable: false),
                    StartMethod = table.Column<int>(type: "INTEGER", nullable: true),
                    ExpectedHarvestDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogEntries_GardenBeds_GardenBedId",
                        column: x => x.GardenBedId,
                        principalTable: "GardenBeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LogEntries_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "PlantPlacements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GardenBedId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlantId = table.Column<int>(type: "INTEGER", nullable: false),
                    GridX = table.Column<int>(type: "INTEGER", nullable: false),
                    GridY = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantPlacements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantPlacements_GardenBeds_GardenBedId",
                        column: x => x.GardenBedId,
                        principalTable: "GardenBeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantPlacements_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Plants",
                columns: new[] { "Id", "CommonName", "CompanionPlants", "CropRotationNotes", "DataSource", "DaysToMaturity", "HardinessZones", "Notes", "PlantType", "ScientificName", "SpacingInches", "SunRequirement", "TypicalStartMethod", "WaterRequirement" },
                values: new object[,]
                {
                    { 1, "Tomato", "Basil, Parsley, Carrot, Marigold", "Rotate out of nightshade family beds annually. Avoid planting after pepper or eggplant.", "USDA, OpenFarm", 75, "5b,6a,6b,7a", "Kansas staple; start seeds indoors 6-8 weeks before last frost (mid-April).", 0, "Solanum lycopersicum", 24.0, 0, 2, 1 },
                    { 2, "Bell Pepper", "Tomato, Basil, Carrot", "Nightshade family; rotate with brassicas or legumes.", "USDA, OpenFarm", 70, "5b,6a,6b,7a", "Needs warm soil; transplant after danger of frost has passed.", 0, "Capsicum annuum", 18.0, 0, 2, 1 },
                    { 3, "Cucumber", "Beans, Dill, Sunflower", "Cucurbit family; rotate annually to prevent cucumber beetles.", "USDA, OpenFarm", 55, "5b,6a,6b,7a", null, 0, "Cucumis sativus", 12.0, 0, 0, 2 },
                    { 4, "Zucchini", "Corn, Beans, Nasturtium", "Cucurbit family; rotate with nightshades or brassicas.", "USDA", 50, "5b,6a,6b,7a", null, 0, "Cucurbita pepo", 36.0, 0, 0, 1 },
                    { 5, "Green Bean", "Corn, Squash, Carrot, Cucumber", "Legume; fixes nitrogen — plant before heavy feeders like corn.", "USDA, OpenFarm", 55, "5b,6a,6b,7a", null, 0, "Phaseolus vulgaris", 6.0, 0, 0, 1 },
                    { 6, "Sweet Corn", "Beans, Squash, Sunflower", "Heavy feeder; rotate with legumes to replenish nitrogen.", "USDA", 80, "5b,6a,6b,7a", null, 0, "Zea mays", 12.0, 0, 0, 2 },
                    { 7, "Lettuce", "Carrot, Radish, Chives, Dill", "Light feeder; good following heavy feeders.", "USDA, OpenFarm", 45, "5b,6a,6b,7a", "Best as a spring or fall crop in Kansas; bolts in summer heat.", 0, "Lactuca sativa", 8.0, 1, 0, 1 },
                    { 8, "Spinach", "Strawberry, Peas, Brassicas", "Good following root crops; avoid planting with chard.", "USDA", 40, "5b,6a,6b,7a", null, 0, "Spinacia oleracea", 6.0, 1, 0, 1 },
                    { 9, "Carrot", "Tomato, Lettuce, Chives, Rosemary", "Root crop; rotate with leaf or fruit crops.", "USDA, OpenFarm", 70, "5b,6a,6b,7a", null, 0, "Daucus carota subsp. sativus", 3.0, 0, 0, 1 },
                    { 10, "Radish", "Lettuce, Spinach, Cucumber, Peas", "Brassica family; rotate annually.", "USDA", 25, "5b,6a,6b,7a", null, 0, "Raphanus sativus", 2.0, 0, 0, 1 },
                    { 11, "Beet", "Onion, Lettuce, Cabbage", "Avoid planting near spinach or chard; rotate with nightshades.", "USDA", 60, "5b,6a,6b,7a", null, 0, "Beta vulgaris", 4.0, 0, 0, 1 },
                    { 12, "Kale", "Beet, Celery, Onion, Herbs", "Brassica family; rotate annually to prevent clubroot.", "USDA, OpenFarm", 60, "5b,6a,6b,7a", "Cold-hardy; flavor improves after frost.", 0, "Brassica oleracea var. sabellica", 18.0, 0, 2, 1 },
                    { 13, "Broccoli", "Onion, Celery, Beet, Chamomile", "Brassica; do not follow other brassicas. Plant after legumes.", "USDA", 65, "5b,6a,6b,7a", null, 0, "Brassica oleracea var. italica", 18.0, 0, 2, 1 },
                    { 14, "Cabbage", "Dill, Celery, Onion, Potato", "Brassica; rotate with nightshades or cucurbits.", "USDA", 70, "5b,6a,6b,7a", null, 0, "Brassica oleracea var. capitata", 18.0, 0, 2, 1 },
                    { 15, "Onion", "Carrot, Beet, Lettuce, Chamomile", "Allium; rotate with brassicas or legumes.", "USDA, OpenFarm", 100, "5b,6a,6b,7a", null, 0, "Allium cepa", 4.0, 0, 2, 1 },
                    { 16, "Garlic", "Tomato, Pepper, Beet, Rose", "Allium; plant in fall, harvest summer. Rotate with brassicas.", "USDA", 240, "5b,6a,6b,7a", "Plant cloves in October; harvest late June in Kansas.", 0, "Allium sativum", 6.0, 0, 2, 0 },
                    { 17, "Pumpkin", "Corn, Beans, Marigold", "Cucurbit; rotate annually.", "USDA", 100, "5b,6a,6b,7a", null, 0, "Cucurbita pepo", 60.0, 0, 0, 1 },
                    { 18, "Butternut Squash", "Corn, Beans, Nasturtium", "Cucurbit family; 3-year rotation recommended.", "USDA, OpenFarm", 110, "5b,6a,6b,7a", null, 0, "Cucurbita moschata", 48.0, 0, 0, 1 },
                    { 19, "Sweet Potato", "Beans, Thyme, Oregano", "Avoid planting in same location as other morning-glories or tomatoes.", "USDA", 100, "6a,6b,7a", "Thrives in southern Kansas (zone 6b-7a); needs 100+ frost-free days.", 0, "Ipomoea batatas", 12.0, 0, 2, 0 },
                    { 20, "Potato", "Beans, Corn, Horseradish", "Nightshade; rotate with brassicas or legumes. Do not follow tomato.", "USDA", 80, "5b,6a,6b,7a", null, 0, "Solanum tuberosum", 12.0, 0, 0, 1 },
                    { 21, "Eggplant", "Tomato, Pepper, Basil", "Nightshade; rotate with legumes or brassicas.", "USDA", 80, "6a,6b,7a", null, 0, "Solanum melongena", 24.0, 0, 2, 1 },
                    { 22, "Swiss Chard", "Beans, Cabbage, Onion", "Related to beet; avoid following beet or spinach.", "USDA", 60, "5b,6a,6b,7a", null, 0, "Beta vulgaris subsp. vulgaris", 12.0, 0, 0, 1 },
                    { 23, "Strawberry", "Spinach, Lettuce, Thyme, Borage", "Perennial; replace bed every 3-4 years. Avoid planting with cabbage.", "USDA, OpenFarm", 30, "5b,6a,6b,7a", "June-bearing varieties most common in Kansas.", 1, "Fragaria × ananassa", 12.0, 0, 2, 1 },
                    { 24, "Watermelon", "Corn, Sunflower, Nasturtium", "Cucurbit; 3-year rotation. Kansas summers ideal.", "USDA", 85, "6a,6b,7a", null, 1, "Citrullus lanatus", 72.0, 0, 0, 2 },
                    { 25, "Cantaloupe", "Corn, Sunflower, Radish", "Cucurbit family; rotate with nightshades or brassicas.", "USDA", 80, "6a,6b,7a", null, 1, "Cucumis melo var. cantalupensis", 48.0, 0, 0, 1 },
                    { 26, "Blackberry", "Comfrey, Tansy, Marigold", "Perennial bramble; permanent planting. Keep away from raspberries.", "USDA", 365, "5b,6a,6b,7a", "Native-adjacent thorny varieties very well adapted to Kansas.", 1, "Rubus allegheniensis", 36.0, 0, 2, 0 },
                    { 27, "Basil", "Tomato, Pepper, Oregano", "Annual; rotate freely.", "OpenFarm", 30, "6a,6b,7a", "Repels aphids and whiteflies; excellent tomato companion.", 3, "Ocimum basilicum", 12.0, 0, 2, 1 },
                    { 28, "Cilantro", "Spinach, Lettuce, Dill, Carrot", "Annual herb; minimal rotation concern.", "OpenFarm", 45, "5b,6a,6b,7a", "Bolts quickly in Kansas summer; grow in spring/fall.", 3, "Coriandrum sativum", 6.0, 0, 0, 0 },
                    { 29, "Parsley", "Tomato, Asparagus, Rose", "Biennial; carrot family. Rotate with other families.", "USDA", 70, "5b,6a,6b,7a", null, 3, "Petroselinum crispum", 8.0, 0, 0, 1 },
                    { 30, "Dill", "Cucumber, Lettuce, Onion, Brassicas", "Carrot family annual; keep away from mature fennel.", "OpenFarm", 40, "5b,6a,6b,7a", null, 3, "Anethum graveolens", 12.0, 0, 0, 0 },
                    { 31, "Chives", "Carrot, Tomato, Apple, Rose", "Perennial allium; permanent planting in herb bed.", "USDA", 60, "5b,6a,6b,7a", null, 3, "Allium schoenoprasum", 6.0, 0, 0, 0 },
                    { 32, "Mint", "Tomato, Brassicas, Peas", "Perennial; contains aggressively — consider containers.", "OpenFarm", 90, "5b,6a,6b,7a", "Very invasive; grow in containers or with root barrier.", 3, "Mentha spicata", 24.0, 1, 2, 1 },
                    { 33, "Oregano", "Pepper, Tomato, Squash", "Perennial herb; permanent bed planting.", "OpenFarm", 80, "5b,6a,6b,7a", null, 3, "Origanum vulgare", 12.0, 0, 2, 0 },
                    { 34, "Thyme", "Tomato, Eggplant, Cabbage, Strawberry", "Perennial; low maintenance. Good border plant.", "USDA, OpenFarm", 90, "5b,6a,6b,7a", null, 3, "Thymus vulgaris", 12.0, 0, 2, 0 },
                    { 35, "Sage", "Tomato, Cabbage, Carrot, Strawberry", "Perennial shrubby herb; replace every 3-4 years.", "USDA", 75, "5b,6a,6b,7a", null, 3, "Salvia officinalis", 24.0, 0, 2, 0 },
                    { 36, "Lavender", "Rose, Sage, Thyme, Brassicas", "Perennial; permanent planting. Excellent pollinator attractor.", "USDA, OpenFarm", 90, "5b,6a,6b,7a", "Excellent deer-resistant pollinator plant for Kansas.", 3, "Lavandula angustifolia", 24.0, 0, 2, 0 },
                    { 37, "Purple Coneflower", "Black-eyed Susan, Wild Bergamot, Blazing Star", "Perennial native; leave seed heads for birds over winter.", "USDA", 365, "5b,6a,6b,7a", "Kansas native; drought-tolerant; blooms June-October.", 4, "Echinacea purpurea", 18.0, 0, 2, 0 },
                    { 38, "Black-eyed Susan", "Coneflower, Blazing Star, Wild Bergamot", "Biennial/perennial native; self-seeds readily.", "USDA", 365, "5b,6a,6b,7a", "Official wildflower of Maryland; widely naturalized in Kansas.", 4, "Rudbeckia hirta", 18.0, 0, 0, 0 },
                    { 39, "Wild Bergamot", "Coneflower, Black-eyed Susan, Prairie Clover", "Perennial native; spreads by rhizomes. Divide every 3 years.", "USDA", 365, "5b,6a,6b,7a", "Excellent native bee and butterfly plant; aromatic foliage.", 4, "Monarda fistulosa", 24.0, 0, 2, 0 },
                    { 40, "Prairie Blazing Star", "Coneflower, Black-eyed Susan, Wild Bergamot", "Perennial corm; permanent planting.", "USDA", 365, "5b,6a,6b,7a", "Kansas native; monarch butterfly magnet; blooms August-September.", 4, "Liatris pycnostachya", 18.0, 0, 2, 0 },
                    { 41, "Butterfly Weed", "Prairie Blazing Star, Coneflower, Goldenrod", "Deep tap root; do not transplant once established.", "USDA", 365, "5b,6a,6b,7a", "Essential monarch butterfly host plant; native milkweed.", 4, "Asclepias tuberosa", 18.0, 0, 0, 0 },
                    { 42, "Plains Sunflower", "Corn, Cucumber, Tomato", "Annual; excellent insectary plant and bird food source.", "USDA", 80, "5b,6a,6b,7a", "State flower of Kansas. Direct-sow after last frost.", 4, "Helianthus annuus", 24.0, 0, 0, 0 },
                    { 43, "Blue Wild Indigo", "Wild Bergamot, Prairie Clover, Coneflower", "Long-lived perennial; fixes nitrogen. Do not move once established.", "USDA", 365, "5b,6a,6b,7a", "Deep-rooted prairie legume; slow to establish but very long-lived.", 4, "Baptisia australis", 36.0, 0, 2, 0 },
                    { 44, "Compass Plant", "Prairie Blazing Star, Wild Bergamot, Compass Plant", "Perennial; tap root can reach 15 feet deep. Do not disturb.", "USDA", 365, "5b,6a,6b,7a", "Iconic tallgrass prairie species; leaves orient north-south.", 4, "Silphium laciniatum", 36.0, 0, 0, 0 },
                    { 45, "Ironweed", "Goldenrod, Wild Bergamot, Ironweed", "Perennial native; spreading clumps, divide every 4 years.", "USDA", 365, "5b,6a,6b,7a", "Brilliant purple blooms in late summer; attracts many butterfly species.", 4, "Vernonia fasciculata", 24.0, 0, 2, 1 },
                    { 46, "Wild Columbine", "Wild Ginger, Wild Bergamot, Ferns", "Perennial; self-seeds. Good woodland edge plant.", "USDA", 365, "5b,6a,6b,7a", "Native to eastern Kansas; hummingbird favorite; early spring bloomer.", 4, "Aquilegia canadensis", 12.0, 1, 0, 0 },
                    { 47, "Purple Prairie Clover", "Prairie Blazing Star, Wild Bergamot, Coneflower", "Perennial legume; fixes nitrogen. Permanent planting.", "USDA", 365, "5b,6a,6b,7a", "Essential native bee plant; extremely drought-tolerant.", 4, "Dalea purpurea", 18.0, 0, 0, 0 },
                    { 48, "Prairie Phlox", "Wild Columbine, Wild Bergamot, Coneflower", "Perennial; divide every 3 years to keep vigorous.", "USDA", 365, "5b,6a,6b,7a", "Fragrant spring bloomer; native to Kansas prairies.", 4, "Phlox pilosa", 12.0, 0, 2, 0 },
                    { 49, "Wild Petunia", "Wild Columbine, Prairie Phlox, Coneflower", "Perennial native; self-seeds freely.", "USDA", 365, "5b,6a,6b,7a", "Low-growing native great for garden edges and dry spots.", 4, "Ruellia humilis", 18.0, 1, 0, 0 },
                    { 50, "Prairie Dropseed", "Purple Prairie Clover, Coneflower, Wild Bergamot", "Perennial native grass; permanent planting.", "USDA", 365, "5b,6a,6b,7a", "Fragrant native bunchgrass; excellent four-season interest.", 4, "Sporobolus heterolepis", 24.0, 0, 2, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GardenBeds_UserId",
                table: "GardenBeds",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LogEntries_GardenBedId",
                table: "LogEntries",
                column: "GardenBedId");

            migrationBuilder.CreateIndex(
                name: "IX_LogEntries_PlantId",
                table: "LogEntries",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_LogEntries_UserId",
                table: "LogEntries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantPlacements_GardenBedId",
                table: "PlantPlacements",
                column: "GardenBedId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantPlacements_PlantId",
                table: "PlantPlacements",
                column: "PlantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "LogEntries");

            migrationBuilder.DropTable(
                name: "PlantPlacements");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "GardenBeds");

            migrationBuilder.DropTable(
                name: "Plants");
        }
    }
}
