using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Equipment : Item
    {
        public float duribility;
        public float rarity;
        public bool isEquipped;


        protected Equipment(string name, string description, int shopPrice, int sellPrice, float duribility, float rarity, int defence) : base(name, description, shopPrice, sellPrice)
        {
            this.duribility = duribility;
            this.rarity = rarity;
            this.isEquipped = false;
        }

    }

    class Armor : Equipment
    {
        public int defence;

        public Armor(string name, string description, int shopPrice, int sellPrice, float duribility, float rarity, int defence) : base(name, description, shopPrice, sellPrice, duribility, rarity, defence)
        {
            this.defence = defence;
        }

        public override void Use(Entity user, Entity target)
        {
            // Flip the value of whether or not it's equipped.
            this.isEquipped = !this.isEquipped;

            if (this.isEquipped)
            {
                // Increase def when equipped
                target.stats.defence += this.defence;
            }
            else
            {
                // Decrease def when dequipped
                target.stats.defence -= this.defence;
            }
        }
    }

    class Weapon : Equipment
    {
        public int attack;

        public Weapon(string name, string description, int shopPrice, int sellPrice, float duribility, float rarity, int attack) : base(name, description, shopPrice, sellPrice, duribility, rarity, attack)
        {
            this.attack = attack;
        }

        public override void Use(Entity user, Entity target)
        {
            // Flip the value of whether or not it's equipped.
            this.isEquipped = !this.isEquipped;

            if (this.isEquipped)
            {
                // Increase def when equipped
                target.stats.attack += this.attack;
            }
            else
            {
                // Decrease def when dequipped
                target.stats.attack -= this.attack;
            }
        }
    }
}
