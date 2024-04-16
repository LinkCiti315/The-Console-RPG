using System;
using System.Collections.Generic;

namespace Console_RPG
{
    class Program
    {
        static void Main(string[] args)
        {



            Player.joe.UseItem(HealthPotionItem.potionI, Player.joe);
            Ally.goku.UseItem(HealthPotionItem.potionI, Ally.goku);
            Ally.piccolo.UseItem(HealthPotionItem.potionI, Ally.piccolo);

            Location.kameHouse.SetNearbyLocations(north: Location.podLanding, west: Location.capsuleCorp);
            Location.podLanding.SetNearbyLocations(south: Location.kameHouse, west: Location.westCity, north: Location.cellGamesArena);
            Location.capsuleCorp.SetNearbyLocations(east: Location.kameHouse, west: Location.westCity, south: Location.wasteLands, north: Location.planetNamek);
            Location.mountains.SetNearbyLocations(south: Location.kamisLookout);
            Location.westCity.SetNearbyLocations(east: Location.capsuleCorp, south: Location.wasteLands, west: Location.kamisLookout);
            Location.wasteLands.SetNearbyLocations(north: Location.capsuleCorp);
            Location.kamisLookout.SetNearbyLocations(east: Location.westCity, north: Location.mountains, south: Location.wasteLands);
            Location.planetNamek.SetNearbyLocations(south: Location.capsuleCorp, north: Location.planetKai, east: Location.destroyedNamek);
            Location.destroyedNamek.SetNearbyLocations(west: Location.planetNamek, north: Location.planetKai);
            Location.planetKai.SetNearbyLocations(south: Location.planetNamek);
            

            Location.kameHouse.Resolve(new List<Player>() { Player.joe, }, new List<Ally>() { Ally.goku, Ally.piccolo });



            
        }
    }
}
