using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{

    // Classes are useful for storing complex objects.
    abstract class Entity
    {
        public string name;

        public int currentHP, maxHP;
        public int currentKi, maxKi;
        public int currentEXP; 

        // This is called composition.
        public Stats stats;

        public Entity(string name, int hp, int Ki, Stats stats, int EXP)
        {
            this.name = name;
            this.currentHP = hp;
            this.maxHP = hp;
            this.currentKi = Ki;
            this.maxKi = Ki;
            this.stats = stats;
            this.currentEXP = EXP;
        }

        public abstract void DoTurn(List<Player> players, List<Ally> allies, List<Enemy> enemies);
        public abstract Entity ChooseTarget(List<Entity> targets);
        public abstract void Attack(Entity target);

    }


}
