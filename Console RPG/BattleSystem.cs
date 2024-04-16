using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Console_RPG
{
    class BattleSystem : PointOfInterest
    {
        public List<Enemy> enemies;

        public BattleSystem(List<Enemy> enemies) : base(false)
        {
            this.enemies = enemies;
        }

        public override void Resolve(List<Player> players, List<Ally> allies)
        {
            while (true)
            {
                // run this code on each of the players.
                foreach (var player in players)
                {
                    if (player.currentHP > 0)
                    {
                        Console.WriteLine("It's " + player.name + "'s turn.");
                        player.DoTurn(players, allies, enemies);
                    } 
                }

                // run this code on each of the players.
                foreach (var ally in allies)
                {
                    if (ally.currentHP > 0)
                    {
                        Console.WriteLine("It's " + ally.name + "'s turn.");
                        ally.DoTurn(players, allies, enemies);
                    }
                }

                // run this code on each of the enemies.
                foreach (var enemy in enemies)
                {
                    if (enemy.currentHP > 0)
                    {
                        Console.WriteLine("It's " + enemy.name + "'s turn.");
                        enemy.DoTurn(players, allies, enemies);
                    }
                }

                // If all the players die...
                if (players.TrueForAll(player => player.currentHP <= 0))
                {
                    Console.WriteLine("YOU DIED");
                    break;
                }

                // If all the enemies die...
                if (enemies.TrueForAll(enemies => enemies.currentHP <= 0))
                {
                    Console.WriteLine("W");
                    

                    int totalEXP = 0;
                    foreach (var item in enemies)
                    {
                        players[0].currentEXP += item.expDroppedOnDefeated;

                    }
                    break;
                }
            }
                // Anything that happens no matter who wins the battle...
        }
    }
}
