using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    class Location
    {
        public static Location kameHouse = new Location("Kame House", "On a lonely island surrounded by miles of ocean");
        public static Location podLanding = new Location("Pod Landing", "grassy fields surrounded by mountains with a large crater with a space pod at the bottom of it", new BattleSystem(new List<Enemy>() { Enemy.raditz }));
        public static Location westCity = new Location("West City", "A large city on an island to the west", new BattleSystem(new List<Enemy>() { Enemy.android19, Enemy.android20, Enemy.android18, Enemy.android17, }));
        public static Location mountains = new Location("mountains", "large rocky mountains surround the area all around you for miles and miles", new BattleSystem(new List<Enemy>() { Enemy.nappa, Enemy.saibaman }));
        public static Location wasteLands = new Location("Wastelands", "A large deserty area stretching for miles with mountains", new BattleSystem(new List<Enemy>() { Enemy.dabura, Enemy.majinBuu, Enemy.superBuu }));
        public static Location capsuleCorp = new Location("Capsule Corp", "Where to get capsules", new Shop("Bulma", "Capsule Shop", new List<Item>() { HealthPotionItem.potionI, KiPotionItem.kiPotionI }));
        public static Location kamisLookout = new Location("Kami's Lookout", "A floating platform with a temple on it and home of Kami and Korrin and where to get Senzu Beans", new Shop("Korrin", "Senzu Shop", new List<Item>() { HealthPotionItem.potionI }));
        public static Location planetNamek = new Location("Planet Namek", "A Blue and Green planet, home of the Namekians who are creators of the Dragon Ball wish orbs", new BattleSystem(new List<Enemy>() { Enemy.zarbon, Enemy.dodoria, Enemy.appule, Enemy.freizaFirstForm, Enemy.freizaSecForm, Enemy.freiza3rdForm, Enemy.freizaFinalForm}));
        public static Location destroyedNamek = new Location("Destroyed Namek", "A now almost exploding planet Namek, hellish looking with valcanos exploding and giant cracks in the crust of the planet leading down into the core", new BattleSystem(new List<Enemy>() { Enemy.freizaFullPower }));
        public static Location cellGamesArena = new Location("The Cell Games Arena", "A large marble arena in a mountainous region", new BattleSystem( new List<Enemy>() { Enemy.semiperfectCell, Enemy.imperfectCell, Enemy.perfectCell, }));
        public static Location planetKai = new Location("Sacred World of the Kais", "A Green planet, home of the Kais who are the watchers of the universe", new BattleSystem(new List<Enemy>() { Enemy.kidBuu }));

        public string name;
        public string description;
        public PointOfInterest interaction;

        public Location north, east, south, west;

        public Location(string name, string description, PointOfInterest interaction = null)
        {

            this.name = name;
            this.description = description;
            this.interaction = interaction;
        }

        public void SetNearbyLocations(Location north = null, Location east = null, Location south = null, Location west = null)
        {
            
            if(!(north is null))
            {
                north.south = this;
                this.north = north;
            }
                

            if(!(east is null))
            {
                east.west = this;
                this.east = east;
            }
                

            if (!(south is null))
            {
                south.north = this;
                this.south = south;
            }
                

            if (!(west is null))
            {
                west.east = this;
                this.west = west;
            }
                
        }

        public void Resolve(List<Player> players, List<Ally> allies)
        {
            // Only resolve a battle if there is a battle to resolve. Null checking.
            interaction?.Resolve(players, allies);

            Console.WriteLine("You are at " + this.name + ".");
            Console.WriteLine(this.description);

            if (!(north is null))
                Console.WriteLine("NORTH:" + this.north.name);

            if (!(east is null))
                Console.WriteLine("EAST:" + this.east.name);

            if (!(south is null))
                Console.WriteLine("SOUTH:" + this.south.name);

            if (!(west is null))
                Console.WriteLine("WEST:" + this.west.name);

            string direction = Console.ReadLine();
            Location nextLocation = null;

            if (direction == "north")
                nextLocation = this.north;
            if (direction == "east")
                nextLocation = this.east;
            if (direction == "south")
                nextLocation = this.south;
            if (direction == "west")
                nextLocation = this.west;


            nextLocation.Resolve(players, allies);
        }
    }
}
