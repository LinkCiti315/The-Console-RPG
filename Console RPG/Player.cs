using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_RPG
{
    class Player : Entity
    {
        public static List<Item> Inventory = new List<Item>() { HealthPotionItem.potionI };
        public static int ZeniCount = 0;


        public static Player joe = new Player("Joe", 50, 50, new Stats(11, 10, 9, 11), 1); 

        public int level;

        public Player(string name, int hp, int Ki, Stats stats, int level) : base(name, hp, Ki, stats, level)
        {
            this.level = level;
        }

        public override Entity ChooseTarget(List<Entity> choices)
        {
            Console.WriteLine("Type in the number of the opponent you want to target:");

            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {choices[i].name}");
            }

            // Let the user choose enemy
            int index = Convert.ToInt32(Console.ReadLine());
            return choices[index - 1];
        }

        public Item ChooseItem(List<Item> choices)
        {
            Console.WriteLine("Type in the number of the item you want to use:");

            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {choices[i].name}");
            }

            // Let the user choose enemy
            int index = Convert.ToInt32(Console.ReadLine());
            return choices[index - 1];
        }

        public override void Attack(Entity target)
        {
            Console.WriteLine(this.name + " attacked " + target.name + "!");
        }

        public void UseItem(Item item, Entity target)
        {
            item.Use(this, target);
        }

        public override void DoTurn(List<Player> players, List<Ally> allies, List<Enemy> enemies)
        {
            Console.WriteLine("What would like to do?");
            Console.WriteLine("ATTACK | ITEM");
            string choice = Console.ReadLine();

            if (choice == "ATTACK")
            {
                Entity target = ChooseTarget(enemies.Cast<Entity>().ToList());
                Attack(target);
            }
            else if (choice == "ITEM")
            {
                Item item = ChooseItem(Inventory);
                Entity target = ChooseTarget(players.Cast<Entity>().ToList());

                item.Use(this, target);
                Inventory.Remove(item);
            }
        }
    }


}
