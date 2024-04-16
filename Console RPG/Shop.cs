using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Shop : PointOfInterest
    {
        public string ownerName;
        public string shopname;
        public List<Item> items;

        public Shop(string ownerName, string shopname, List<Item> items) : base(false)
        {
            this.ownerName = ownerName;
            this.shopname = shopname;
            this.items = items;
        }

        public override void Resolve(List<Player> players, List<Ally> allies)
        {
            Console.WriteLine("Welcome to Capsule Corp!!");
            while (true)
            { Console.WriteLine("What do you want to do?");
                Console.WriteLine("BUY | SELL | LEAVE");
                string userInput = Console.ReadLine();
                if (userInput == "BUY")
                {
                    //Select Item
                    Item item = ChooseItem(this.items);
                    //Dedect from their money
                    Player.ZeniCount -= item.shopPrice;
                    //Add to inventory
                    Player.Inventory.Add(item);
                    //Tell them you got item
                    Console.WriteLine($"You bought a {item.name}!");
                }
                else if (userInput == "SELL")
                {
                    Item item = ChooseItem(Player.Inventory);
                    //Add to their money
                    Player.ZeniCount += item.shopPrice;
                    //take from inventory
                    Player.Inventory.Remove(item);
                    //Tell them you got item
                    Console.WriteLine($"You sold a {item.name}!");
                }
                else if (userInput == "LEAVE")
                {
                    break;
                }

            }

            Console.WriteLine("Thank you, come again");
        } 
        public Item ChooseItem(List<Item> choices)
        {
            Console.WriteLine("Type in the number of the item you want to use:");

            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {choices[i].name} ({choices[i].shopPrice})");
            }

            // Let the user choose item
            int index = Convert.ToInt32(Console.ReadLine());
            return choices[index - 1];
        }
    }
}
