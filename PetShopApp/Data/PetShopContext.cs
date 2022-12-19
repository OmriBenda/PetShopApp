using Microsoft.EntityFrameworkCore;
using PetShopApp.Models;

namespace PetShopApp.Data
{
    public class PetShopContext : DbContext
    {
        public PetShopContext(DbContextOptions<PetShopContext> options):base(options)
        {

        }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new {CategoryId = 1, CategoryName = "Mammals"},
                new {CategoryId = 2, CategoryName = "Reptiles"},
                new {CategoryId = 3, CategoryName = "Birds"},
                new {CategoryId = 4, CategoryName = "Fish"},
                new {CategoryId = 5, CategoryName = "Invertebrates" }
                );
            modelBuilder.Entity<Animal>().HasData(
                new {AnimalId = 1 , Name = "Bear",Age = 2 , Description = "\r\nBears are mammals that belong to the family Ursidae. They can be as small as four feet long and about 60 pounds (the sun bear) to as big as eight feet long and more than a thousand pounds (the polar bear). They're found throughout North America, South America, Europe, and Asia.", PictureName = "~/images/bear.jpg", CategoryId = 1},
                new {AnimalId = 2, Name = "Tiger",Age = 3 , Description = "\r\nEasily recognized by its coat of reddish-orange with dark stripes, the tiger is the largest wild cat in the world. The big cat's tail is three feet long. On average the big cat weighs 450 pounds, about the same as eight ten-year-old kids.", PictureName = "~/images/Tiger.jpg", CategoryId = 1},
                new {AnimalId = 3, Name = "Whale",Age = 2, Description = "\r\nWhales are the largest animals on Earth and they live in every ocean. The massive mammals range from the 600-pound dwarf sperm whale to the colossal blue whale, which can weigh more than 200 tons and stretch up to 100 feet long—almost as long as a professional basketball court.", PictureName = "~/images/Whale.jpg", CategoryId = 1},
                new {AnimalId = 4, Name = "Turtels",Age = 10, Description = "\r\nturtle, any reptile with a body encased in a bony shell, including tortoises. Although numerous animals, from invertebrates to mammals, have evolved shells, none has an architecture like that of turtles. The turtle shell has a top (carapace) and a bottom (plastron).", PictureName = "~/images/turtle.webp", CategoryId = 2},
                new {AnimalId = 5, Name = "Crocodile",Age = 8, Description = "\r\nCrocodiles have powerful jaws with many conical teeth and short legs with clawed webbed toes. They share a unique body form that allows the eyes, ears, and nostrils to be above the water surface while most of the animal is hidden below. The tail is long and massive, and the skin is thick and plated.", PictureName = "~/images/Crocodile.jpg", CategoryId = 2},
                new {AnimalId = 6, Name = "Snake",Age = 4, Description = "\r\nsnake, Any member of about 19 reptile families (suborder Serpentes, order Squamata) that has no limbs, voice, external ears, or eyelids, only one functional lung, and a long, slender body. About 2,900 snake species are known to exist, most living in the tropics. Their skin is covered with scales.", PictureName = "~/images/snakes_02_2x1.webp", CategoryId = 2},
                new {AnimalId = 7, Name = "Ostrich",Age = 5, Description = "Ostriches are large, flightless birds that have long legs and a long neck that protrudes from a round body. Males have bold black-and-white coloring that they use to attract females. Females, on the other hand, are light brown. Ostriches are bigger than any other bird in the", PictureName = "~/images/ostrich.jpg", CategoryId = 3},
                new {AnimalId = 8, Name = "Peacook",Age = 7, Description = " peacock is a shiny blue bird who fans out his large colorful iridescent tail feathers, especially when he's flirting with the peahens. A peacock is a male peafowl. A male peacock is more flamboyant than his female counterpart — he's the one with those long brilliant tail feathers marked with eye-like designs.", PictureName = "~/images/Peacock.png", CategoryId = 3},
                new {AnimalId = 9, Name = "Eagle",Age = 11, Description = "an eagle is any bird of prey more powerful than a buteo. An eagle may resemble a vulture in build and flight characteristics but has a fully feathered (often crested) head and strong feet equipped with great curved talons. A further difference is in foraging habits: eagles subsist mainly on live prey.", PictureName = "~/images/eagle.jpg", CategoryId = 3},
                new {AnimalId = 10, Name = "Salmon",Age = 2, Description = "marine and freshwater food fish, Salmo salar, of the family Salmonidae, having pink flesh, inhabiting waters off the North Atlantic coasts of Europe and North America near the mouths of large rivers, which it enters to spawn.", PictureName = "~/images/salmon.jpg", CategoryId = 4},
                new {AnimalId = 11, Name = "Goldfish",Age = 2, Description = "Goldfish have two sets of paired fins and three sets of single fins. They don't have barbels, sensory organs some fish have that act like taste buds. Nor do they have scales on their heads. They also don't have teeth and instead crush their food in their throats.", PictureName = "~/images/goldfish.jpg", CategoryId = 4},
                new {AnimalId = 12, Name = "Guppy",Age = 3, Description = "The guppy is a small fish. Males are significantly smaller than females, measuring just 0.6-1.4 in (1.5-3.5 cm) long. Females, at about 1.2-2.4 in (3-6 cm) in length, are about twice the size. Males also tend to be more colorful, and extravagant, with ornamental fins absent in the females.", PictureName = "~/images/guppy.webp", CategoryId = 4},
                new {AnimalId = 13, Name = "Spider",Age = 3, Description = "Spiders are arthropods that have eight legs. They have more legs and different body parts than insects, and they also don't move around in the same way insects do. Spiders are in the arachnid class, but not all arachnids are spiders. There are about 40,000 known species of spiders.", PictureName = "~/images/spider.jpg", CategoryId = 5},
                new {AnimalId = 14, Name = "Ladybug",Age = 1, Description = "\r\nMost ladybugs have oval, dome-shaped bodies with six short legs. Depending on the species, they can have spots, stripes, or no markings at all. Seven-spotted ladybugs are red or orange with three spots on each side and one in the middle. They have a black head with white patches on either side.", PictureName = "~/images/ladybug.webp", CategoryId = 5},
                new {AnimalId = 15, Name = "Scorpion",Age = 1, Description = "Scorpions are arthropods, they have eight legs, two pedipalps, and a tail with a venom-injecting barb. Scorpions have two venom glands that produce venom used in hunting and self defense. Scorpions do not have bones instead they have an exoskeleton made of chitin, which is similar to the shell of a shrimp", PictureName = "~/images/scorpion.jpg", CategoryId = 5}

                );
            modelBuilder.Entity<Comments>().HasData(
                new { CommentsId = 1, AnimalId = 9, comment = "So Powerfull"},
                new { CommentsId = 2, AnimalId = 10, comment = "something"},
                new { CommentsId = 3, AnimalId = 11, comment = "something" },
                new { CommentsId = 4, AnimalId = 12, comment = "something"},
                new { CommentsId = 5, AnimalId = 13, comment = "something"},
                new { CommentsId = 6, AnimalId = 14, comment = "something"},
                new { CommentsId = 7, AnimalId = 15, comment = "something" },
                new { CommentsId = 8, AnimalId = 10, comment = "cute!" },
                new { CommentsId = 9, AnimalId = 9, comment = "So Cute" }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
