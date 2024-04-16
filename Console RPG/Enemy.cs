using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_RPG
{
    class Enemy : Entity
    {
        public static Enemy raditz = new Enemy("Raditz", 40, 50, new Stats(15, 4, 8, 10), 20);
        public static Enemy nappa = new Enemy("Nappa", 45, 50, new Stats(17, 8, 11, 11), 22);
        public static Enemy saibaman = new Enemy("Saibaman", 20, 20, new Stats(5, 4, 6, 10), 5);
        public static Enemy appule = new Enemy("Appule", 20, 20, new Stats(5, 7, 8, 9), 7);
        public static Enemy dodoria = new Enemy("Dodoria", 45, 50, new Stats(17, 8, 11, 11), 22);
        public static Enemy zarbon = new Enemy("Zarbon", 47, 55, new Stats(17, 8, 11, 11), 22);
        public static Enemy freizaFirstForm = new Enemy("Freiza (1st Form)", 65, 65, new Stats(20, 10, 10, 12), 22);
        public static Enemy freizaSecForm = new Enemy("Freiza (2nd Form)", 69, 68, new Stats(22, 12, 12, 14), 25);
        public static Enemy freiza3rdForm = new Enemy("Freiza (3rd Form)", 70, 69, new Stats(23, 13, 13, 14), 25);
        public static Enemy freizaFinalForm = new Enemy("Freiza (Final Form)", 75, 72, new Stats(25, 15, 15, 18), 30);
        public static Enemy freizaFullPower = new Enemy("Freiza (Full Power)", 75, 75, new Stats(30, 15, 15, 18), 30);
        public static Enemy android20 = new Enemy("Andoid 20", 50, 50, new Stats(17, 7, 8, 10), 20);
        public static Enemy android19 = new Enemy("Andoid 19", 50, 50, new Stats(17, 7, 8, 10), 19);
        public static Enemy android18 = new Enemy("Andoid 18", 60, 60, new Stats(18, 8, 8, 10), 20);
        public static Enemy android17 = new Enemy("Andoid 17", 60, 60, new Stats(18, 8, 9, 10), 20);
        public static Enemy imperfectCell = new Enemy("Cell (1st Form)", 65, 65, new Stats(20, 10, 10, 12), 22);
        public static Enemy semiperfectCell = new Enemy("Cell (2nd Form)", 69, 68, new Stats(22, 12, 12, 14), 25);
        public static Enemy perfectCell = new Enemy("Perfect Cell", 75, 72, new Stats(25, 15, 15, 18), 30);
        public static Enemy dabura = new Enemy("Dabura", 75, 72, new Stats(25, 15, 15, 18), 30);
        public static Enemy majinBuu = new Enemy("Majin Buu", 80, 76, new Stats(30, 27, 27, 20), 35);
        public static Enemy superBuu = new Enemy("Super Buu", 85, 80, new Stats(33, 30, 30, 23), 38);
        public static Enemy kidBuu = new Enemy("Kid Buu", 90, 85, new Stats(36, 35, 27, 35), 40);




        public int expDroppedOnDefeated;

        public Enemy(string name, int hp, int Ki, Stats stats, int expDroppedOnDefeated) : base(name, hp, Ki, stats, expDroppedOnDefeated)
        {
            this.expDroppedOnDefeated = expDroppedOnDefeated;
        }

        public override Entity ChooseTarget(List<Entity> targets)
        {
            Random random = new Random();
            return targets[random.Next(targets.Count)];
        }

        public override void Attack(Entity target)
        {
            Console.WriteLine(this.name + " attacked " + target.name + "!");
        }

        public override void DoTurn(List<Player> players, List<Ally> allies, List<Enemy> enemies)
        {
            List<Entity> targets = new List<Entity>();
            targets.AddRange(players);
            targets.AddRange(allies);
            Entity target = ChooseTarget(targets);
            Attack(target);
        }
    }


}
