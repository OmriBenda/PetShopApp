using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PetShopApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "animals",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PictureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_animals", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_animals_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentsId);
                    table.ForeignKey(
                        name: "FK_Comments_animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Mammals" },
                    { 2, "Reptiles" },
                    { 3, "Birds" },
                    { 4, "Fish" },
                    { 5, "Invertebrates" }
                });

            migrationBuilder.InsertData(
                table: "animals",
                columns: new[] { "AnimalId", "Age", "CategoryId", "Description", "Name", "PictureName" },
                values: new object[,]
                {
                    { 1, 2, 1, "\r\nBears are mammals that belong to the family Ursidae. They can be as small as four feet long and about 60 pounds (the sun bear) to as big as eight feet long and more than a thousand pounds (the polar bear). They're found throughout North America, South America, Europe, and Asia.", "Bear", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTYY1GGaVgrCod3zB5wcoamtjiH0XwEAd8hKBIc4UKG5CjkjVtEPYxA7RP8dpqNTrL_ctk&usqp=CAU" },
                    { 2, 3, 1, "\r\nEasily recognized by its coat of reddish-orange with dark stripes, the tiger is the largest wild cat in the world. The big cat's tail is three feet long. On average the big cat weighs 450 pounds, about the same as eight ten-year-old kids.", "Tiger", "https://animals.net/wp-content/uploads/2018/09/Tiger-2.jpg" },
                    { 3, 2, 1, "\r\nWhales are the largest animals on Earth and they live in every ocean. The massive mammals range from the 600-pound dwarf sperm whale to the colossal blue whale, which can weigh more than 200 tons and stretch up to 100 feet long—almost as long as a professional basketball court.", "Whale", "https://nationaltoday.com/wp-content/uploads/2021/12/Humpback-Whale-Awareness-Month--640x514.jpg" },
                    { 4, 10, 2, "\r\nturtle, any reptile with a body encased in a bony shell, including tortoises. Although numerous animals, from invertebrates to mammals, have evolved shells, none has an architecture like that of turtles. The turtle shell has a top (carapace) and a bottom (plastron).", "Turtels", "https://assets.petco.com/petco/image/upload/f_auto,q_auto/aquatic-turtle-care-sheet-hero" },
                    { 5, 8, 2, "\r\nCrocodiles have powerful jaws with many conical teeth and short legs with clawed webbed toes. They share a unique body form that allows the eyes, ears, and nostrils to be above the water surface while most of the animal is hidden below. The tail is long and massive, and the skin is thick and plated.", "Crocodile", "https://www.stockland.com.au/~/media/shopping-centre/common/everyday-ideas/kids/crocodile/0518_stocklandnational_crocodiles_900x6753.ashx" },
                    { 6, 4, 2, "\r\nsnake, Any member of about 19 reptile families (suborder Serpentes, order Squamata) that has no limbs, voice, external ears, or eyelids, only one functional lung, and a long, slender body. About 2,900 snake species are known to exist, most living in the tropics. Their skin is covered with scales.", "Snake", "https://i.natgeofe.com/n/d742b985-727d-4f14-85ff-5294fc44ef5e/snakes_02_2x1.jpg" },
                    { 7, 5, 3, "Ostriches are large, flightless birds that have long legs and a long neck that protrudes from a round body. Males have bold black-and-white coloring that they use to attract females. Females, on the other hand, are light brown. Ostriches are bigger than any other bird in the", "Ostrich", "https://cdn.mos.cms.futurecdn.net/tMnjLRtEm47ueTPt9Rkyxd-1200-80.jpg" },
                    { 8, 7, 3, " peacock is a shiny blue bird who fans out his large colorful iridescent tail feathers, especially when he's flirting with the peahens. A peacock is a male peafowl. A male peacock is more flamboyant than his female counterpart — he's the one with those long brilliant tail feathers marked with eye-like designs.", "Peacook", "https://animalcorner.org/wp-content/uploads/2015/02/Peafowl-Peacock.png" },
                    { 9, 11, 3, "an eagle is any bird of prey more powerful than a buteo. An eagle may resemble a vulture in build and flight characteristics but has a fully feathered (often crested) head and strong feet equipped with great curved talons. A further difference is in foraging habits: eagles subsist mainly on live prey.", "Eagle", "https://onekindplanet.org/wp-content/uploads/2016/09/az_bald-eagle-520x294.jpg" },
                    { 10, 2, 4, "marine and freshwater food fish, Salmo salar, of the family Salmonidae, having pink flesh, inhabiting waters off the North Atlantic coasts of Europe and North America near the mouths of large rivers, which it enters to spawn.", "Salmon", "https://cdn.britannica.com/50/117550-050-874E841A/Atlantic-salmon.jpg" },
                    { 11, 2, 4, "Goldfish have two sets of paired fins and three sets of single fins. They don't have barbels, sensory organs some fish have that act like taste buds. Nor do they have scales on their heads. They also don't have teeth and instead crush their food in their throats.", "Goldfish", "https://fish-guppy.com/wp-content/uploads/2020/09/gold-fish-start-2.jpg" },
                    { 12, 3, 4, "The guppy is a small fish. Males are significantly smaller than females, measuring just 0.6-1.4 in (1.5-3.5 cm) long. Females, at about 1.2-2.4 in (3-6 cm) in length, are about twice the size. Males also tend to be more colorful, and extravagant, with ornamental fins absent in the females.", "Guppy", "https://cdn-acgla.nitrocdn.com/bvIhcJyiWKFqlMsfAAXRLitDZjWdRlLX/assets/static/optimized/rev-5131b73/wp-content/uploads/2020/09/shutterstock_642230203-1.jpg" },
                    { 13, 3, 5, "Spiders are arthropods that have eight legs. They have more legs and different body parts than insects, and they also don't move around in the same way insects do. Spiders are in the arachnid class, but not all arachnids are spiders. There are about 40,000 known species of spiders.", "Spider", "https://i.pinimg.com/originals/3d/6b/58/3d6b58d97408757e577ee4c584c16087.jpg" },
                    { 14, 1, 5, "\r\nMost ladybugs have oval, dome-shaped bodies with six short legs. Depending on the species, they can have spots, stripes, or no markings at all. Seven-spotted ladybugs are red or orange with three spots on each side and one in the middle. They have a black head with white patches on either side.", "Ladybug", "https://i.natgeofe.com/k/d987f7b2-1895-4978-9216-3f365ea51a34/ladybug-daisy_4x3.jpg" },
                    { 15, 1, 5, "Scorpions are arthropods, they have eight legs, two pedipalps, and a tail with a venom-injecting barb. Scorpions have two venom glands that produce venom used in hunting and self defense. Scorpions do not have bones instead they have an exoskeleton made of chitin, which is similar to the shell of a shrimp", "Scorpion", "https://upload.wikimedia.org/wikipedia/commons/f/fe/Scorpion_Photograph_By_Shantanu_Kuveskar.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentsId", "AnimalId", "comment" },
                values: new object[,]
                {
                    { 1, 9, "So Powerfull" },
                    { 2, 10, "something" },
                    { 3, 11, "something" },
                    { 4, 12, "something" },
                    { 5, 13, "something" },
                    { 6, 14, "something" },
                    { 7, 15, "something" },
                    { 8, 10, "cute!" },
                    { 9, 9, "So Cute" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_animals_CategoryId",
                table: "animals",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AnimalId",
                table: "Comments",
                column: "AnimalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "animals");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
