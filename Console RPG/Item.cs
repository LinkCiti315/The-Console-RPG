using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Item
    {
        public string name;
        public string description;

        public int shopPrice;
        public int maxAmount;

        public Item(string name, string description, int shopPrice, int maxAmount)
        {
            this.name = name;
            this.description = description;
            this.shopPrice = shopPrice;
            this.maxAmount = maxAmount;
        }

        public abstract void Use(Entity user, Entity target);
    }

    class HealthPotionItem : Item
    {
        public static HealthPotionItem potionI = new HealthPotionItem("Senzu Bean", "It will heal you.", 10, 20, 10);

        public int healAmount;

        public HealthPotionItem(string name, string description, int shopPrice, int maxAmount, int healAmount) : base(name, description, shopPrice, maxAmount)
        {
            this.healAmount = healAmount;
        }

        public override void Use(Entity user, Entity target)
        {
            user.currentHP += this.healAmount;
        }
    }

    class KiPotionItem : Item
    {
        public static KiPotionItem kiPotionI = new KiPotionItem("Power Capsule", "It will replenish your Ki.", 10, 20, 10);

        public int KiAmount;

        public KiPotionItem(string name, string description, int shopPrice, int maxAmount, int KiAmount) : base(name, description, shopPrice, maxAmount)
        {
            this.KiAmount = KiAmount;

        }

        public override void Use(Entity user, Entity target)
        {
            user.currentHP += this.KiAmount;
        }
    }

    class PowerPole : Item
    {
        public int damage;


        public PowerPole(string name, string description, int shopPrice, int maxAmount, int damage) : base(name, description, shopPrice, maxAmount)
        {
            this.damage = damage;
        
        }

        public override void Use(Entity user, Entity target)
        {
          

            target.currentHP -= this.damage;
           
        }
    }

}
