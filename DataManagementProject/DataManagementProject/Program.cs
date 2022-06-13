using System;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;

namespace JSON_Data_Management_Notes
{
    class Program
    {
        static void Main(string[] args)
        {
            static int SearchName(List<Weapon> aList, string item)
            {

                for (int i = 0; i < aList.Count; i++)
                {
                    if (aList[i].name == item) // using input to be able to match to list of available names to find the weapon
                    {
                        return i;
                    }
                }

                return -1;
            }

            static int removeFavourites(List<Weapon> aList, string item, List<User> users) // Call in a new users parameter to be able to call the favourites object in the class
            {

                for (int i = 0; i < users[0].faves.Count; i++)
                {
                    if (users[0].faves[i].name == item) // going at users[0] all the time because no other users are saved / can be accessed
                    {
                        return i;
                    }
                }

                return -1;
            }

            // Master list of weapons
            List<Weapon> weapons = new List<Weapon>(); // Adding database content to browse
            weapons.Add(new Weapon("Hyperion", "The Hyperion is a Legendary Sword. It is one of four refined Necron's Blade variants, alongside the Valkyrie, Astraea and Scylla. The Hyperion gives a bonus 300 Intelligence, though it loses 10 Damage in total. The Hyperion also grants +1 Damage and +2 Intelligence per Catacombs level of the player. As with any Necron's Blade, it deals +50% damage to Withers.", "sword", 260, 150));
            weapons.Add(new Weapon("Valkyrie", "The Valkyrie is a Legendary Sword. It is one of four refined Necron's Blade variants, alongside the Hyperion, Astraea and Scylla. The Valkyrie's strength when compared to the other Necron's Blade variants is its additional 30  Ferocity and 10  Intelligence, though it loses 5  Strength. The Valkyrie also grants +1 Damage and +1 Strength per Catacombs level of the player. As with any Necron's Blade, it deals +50% damage to Withers. It is often regarded as the best weapon in the game for Ferocity, and one of the best for melee DPS (Damage Per Second), making it ideal for Berserk.", "sword", 270, 145));
            weapons.Add(new Weapon("Scylla", "The Scylla is a Legendary Sword. It is one of four refined Necron's Blade variants, alongside the Valkyrie, Astraea and Hyperion. The Scylla’s strength when compared to the other Necron's Blade variants is its additional 12% Crit Chance and 35%  Crit Damage. The Scylla also grants +1 Damage and +1 Crit Damage per Catacombs level of the player.As with any Necron's Blade, it deals +50% damage to Withers. It deals the most single - hit melee damage of any Necron Blade, though it lacks the Ferocity, and as such DPS(Damage Per Second) of the Valkyrie, and the defense of the Astraea. However, the high Crit Damage can be useful for the Wither Shield scroll ability, as the more Crit Damage you have the more it will heal you.", "sword", 270, 150));
            weapons.Add(new Weapon("Astraea", "The Astraea is a Legendary Sword. It is one of four refined Necron's Blade variants, alongside the Valkyrie, Hyperion and Scylla. The Astraea's strength when compared to the other Necron's Blade variants is its additional 250 Defense and 20 True Defense. The Astraea also grants +1 Damage and +2 Defense per Catacombs level of the player. As with any Necron's Blade, it deals +50% damage to Withers. It is often regarded as the best weapon in the game for resisting attacks while in melee combat, making it ideal for the Tank class. Although it deals less damage than a Valkyrie or even Scylla, the Astraea's defensive stats make it a compelling choice for anyone involved in melee combat who is struggling with survival.", "sword", 270, 150));
            weapons.Add(new Weapon("Livid Dagger", "The Livid Dagger is a Legendary Dungeon Sword obtained from The Catacombs - Floor V. It has 100 Bonus Attack Speed and Crit Chance. It requires a The Catacombs - Floor V completion to use. When hitting an enemy from their back, critical hits deal 2x damage. When its ability is used, it throws a sword forward, dealing damage to enemies it hits.", "dagger", 210, 60));
              weapons.Add(new Weapon("Axe of the Shredded", "The Axe of the Shredded can be used as a melee weapon, as well as a ranged weapon. It deals 250% damage to Zombies and shields from 25% of incoming Zombie damage when held. It heals 50 HP when it hits a mob. When its ability is used, it throws an axe forward in a similar trajectory to that of the Livid Dagger’s ability. For each tick the axe is within the enemy's hitbox, it deals 10% of the damage it would do on a melee strike. The ability costs 20  Mana. Consecutive throws double both the damage multiplier and mana cost, up to a maximum of 4 times at 160% damage and 320 Mana cost; any throws after that have the same damage and mana cost. The axe projectile travels approximately 100 blocks before despawning. Unlike other melee weapons that have melee abilities like the Livid Dagger, the axe's ability hits trigger Enchantments like Thunderlord, Thunderbolt, Mana Steal, Life Steal and Syphon (pending for test: Fire Aspect, Lethality), apply the 50 HP healing on hit, trigger Pet abilities that usually only trigger with melee attacks like the Wither Skeleton Pet's Death Touch and the Phoenix Pet's Fourth Flare, and regenerate Mana within Dungeons. It also can activate Ferocity upon hitting a mob if within 4 blocks.The Throw ability ignores invincibility frames, causing it to hit multiple times per target.This is noticeable on big mobs such as Ender Dragon, Sadan's Giants and Bal.", "axe", 140, 115));
            weapons.Add(new Weapon("Raider's Axe", "The Raider Axe is a Rare Sword purchased from the Joyful Viking. It increases in power with mobs killed and wood collections, and earns coins on kill. The Raider Axe can be purchased from the Melancholic Viking for 130,000 coins once his quest is completed.", "axe", 80, 50));
            weapons.Add(new Weapon("Zombie Soldier Cutlass", "The Zombie Soldier Cutlass is a Rare or Epic Dungeon Sword that is dropped by Zombie Soldiers. It is special in the fact that it is one of few swords in the game that grants +100%  Bonus Attack Speed by default, which thereby instantly maximizes the player's  Bonus Attack Speed just by holding this weapon. Like all dropped dungeon gear, it always drops with a few Enchantments and a random Reforge.", "dagger", 100, 50));

            // Favourites list
            List <User> users = new List<User>();
           
            // Menu
            Console.Clear();
            Console.WriteLine("Welcome to the catalog!");
            Console.WriteLine("Before we begin, please create a new username to be able to utilise our database:");
            string newUsername = Console.ReadLine();
            Console.WriteLine("Excellent! Now please input a password to continue to keep your account safe!");
            string newPassword = Console.ReadLine();
            Console.WriteLine("Perfect! You are ready to browse! Enjoy your time!");
            users.Add(new User(newUsername, newPassword));
            string userInput;
            bool killswitch = false;


            while (killswitch != true) // Boolean used to keep while loop active until a certain input changes it to true, therefore stopping the loop and exiting the program.
            {
                Console.Clear();
                Console.WriteLine("-------Skyblock Swords-------");
                Console.WriteLine("Hello! What would you like to do?");
                Console.WriteLine("1. Display all data on swords (type 'display' or '1')"); // good idea to give options by either having a short phrase associated with action or just the number of which it is located.
                Console.WriteLine("2. Filter and search some of the data (type 'search' or '2')");
                Console.WriteLine("3. Add data to a favourites list (type 'add' or '3')");
                Console.WriteLine("4. Remove data from your favourites list (type 'remove' or '4')");
                Console.WriteLine("5. Display favourites list (type 'favourites' or '5')");
                Console.WriteLine("6. Exit (type 'exit' or '6')");
                userInput = Console.ReadLine(); // User input in order to know what command it is doing
                if (userInput.ToLower() == "display" | userInput.ToLower() == "1") // Displaying all possible items within database
                {
                    for (int i = 0; i < weapons.Count; i++)
                    {
                        Console.WriteLine(weapons[i]); // simple 'for' loop in order to loop through entire list efficiently
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(); // using ReadKey to get user input in order to progress + if it wasn't there, the program would instantly print what is given and not give the user any time to read what is written in Console.WriteLine.
                }
                else if (userInput.ToLower() == "search" | userInput.ToLower() == "2") // Finding the item in the database
                {
                    Console.WriteLine("Please enter the sword name that you want to search for:");
                    string searchInput = Console.ReadLine(); // User input in order to know what command it is doing
                    Console.WriteLine("Searching now...");
                    int result = SearchName(weapons, searchInput);
                    if (result == -1) // linear search returns -1 only when the input / word it is given cannot be found within the list / array that it is searching through, due to the position not being anything positive, it returns -1 because that is the earliest impossible position for an array / list, meaning it cannot find anything.
                    {
                        Console.WriteLine(searchInput + " was not found in the list!");
                    }
                    else
                    {
                        Console.WriteLine(searchInput + " was found! Displaying information right now...");
                        Console.WriteLine(weapons[result]);
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(); // using ReadKey to get user input in order to progress + if it wasn't there, the program would instantly print what is given and not give the user any time to read what is written in Console.WriteLine.
                }
                else if (userInput.ToLower() == "add" | userInput.ToLower() == "3") // Adding Favourites
                {
                    Console.WriteLine("Please enter the sword class that you want to search for to add to your favourites:");
                    string searchInput = Console.ReadLine();
                    int result = SearchName(weapons, searchInput);
                    if (result == -1) // linear search returns -1 only when the input / word it is given cannot be found within the list / array that it is searching through, due to the position not being anything positive, it returns -1 because that is the earliest impossible position for an array / list, meaning it cannot find anything.
                    {
                        Console.WriteLine(searchInput + " was not found in the list!");
                    }
                    else
                    {
                        Console.WriteLine(searchInput + " was found! Adding to favourites...");
                        users[0].faves.Add(weapons[result]);
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(); // using ReadKey to get user input in order to progress + if it wasn't there, the program would instantly print what is given and not give the user any time to read what is written in Console.WriteLine.
                }
                else if (userInput.ToLower() == "remove" | userInput.ToLower() == "4") // Removing Favourites
                {
                    Console.WriteLine("Please enter the sword class that you want to search for to remove from your favourites:");
                    string searchInput = Console.ReadLine();
                    int result = removeFavourites(weapons, searchInput, users);
                    if (result == -1) // linear search returns -1 only when the input / word it is given cannot be found within the list / array that it is searching through, due to the position not being anything positive, it returns -1 because that is the earliest impossible position for an array / list, meaning it cannot find anything.
                    {
                        Console.WriteLine(searchInput + " was not found in the list!");
                    }
                    else
                    {
                        Console.WriteLine(searchInput + " was found! Removing from favourites...");
                        users[0].faves.Remove(weapons[result]);
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(); // using ReadKey to get user input in order to progress + if it wasn't there, the program would instantly print what is given and not give the user any time to read what is written in Console.WriteLine.
                }
                else if (userInput.ToLower() == "favourites" | userInput.ToLower() == "5") // Displaying favourites 
                {
                    Console.WriteLine("Displaying all favourites: ");
                    for (int i = 0; i < users[0].faves.Count; i++) // simple 'for' loop in order to loop through entire list efficiently
                    {
                        Console.WriteLine(users[0].faves[i]);
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(); // using ReadKey to get user input in order to progress + if it wasn't there, the program would instantly print what is given and not give the user any time to read what is written in Console.WriteLine.
                }
                else if (userInput.ToLower() == "exit" | userInput.ToLower() == "6") // Ending the loop
                {
                    Console.WriteLine("Exiting the catalog. Press any key to continue...");
                    killswitch = true; // boolean for ending the program
                    Console.ReadKey(); // using ReadKey to get user input in order to progress + if it wasn't there, the program would instantly print what is given and not give the user any time to read what is written in Console.WriteLine.

                }
                else // failsafe in order to ensure that program doesn't end itself due to not knowing what to do when user inputs something that is not part of the list by putting a nice reminder with a readkey to ensure that they can read and understand better
                {
                    Console.WriteLine("This is not an available option to make! Please read the text! Press any key to continue...");
                    Console.ReadKey(); // using ReadKey to get user input in order to progress + if it wasn't there, the program would instantly print what is given and not give the user any time to read what is written in Console.WriteLine.
                }
            }
        }

        class Weapon
        {
            public string name;
            public string description;
            public string classification;
            public int damage;
            public int strength;


            public Weapon(string name, string description, string classification, int damage, int strength)
            {
                this.name = name;
                this.description = description;
                this.classification = classification;
                this.damage = damage;
                this.damage = strength;
            }

            public override string ToString() // how all the text will be displayed in the console when called upon in the   
            {
                return $"{this.name}: Type of weapon: {this.classification}, Damage: {this.damage}, Strength: {this.strength} -- {this.description}";
            } 
        }

        class User
        {
            public string username;
            public string password;
            public List<Weapon> faves;

            public User(string username, string password)
            {
                this.username = username;
                this.password = password;
                this.faves = new List<Weapon>();
            }
        }
    }
}


