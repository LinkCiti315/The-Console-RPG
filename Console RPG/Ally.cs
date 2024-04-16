using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Console_RPG
{
    class Ally : Entity
    {

        public static Ally goku = new Ally("Goku", 50, 50, new Stats(10, 9, 8, 10), 1);
        public static Ally piccolo = new Ally("Piccolo", 50, 50, new Stats(10, 9, 8, 10), 1);

        public int level;

        public Ally(string name, int hp, int Ki, Stats stats, int level) : base(name, hp, Ki, stats, level)
        {
            this.level = level;
        }

        public override Entity ChooseTarget(List<Entity> targets)
        {
            return targets[0];
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
            Entity target = ChooseTarget(enemies.Cast<Entity>().ToList());
            Attack(target);
        }
    }
}
