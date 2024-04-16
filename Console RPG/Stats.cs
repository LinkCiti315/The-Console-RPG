namespace Console_RPG
{
    //struts are useful for storong sime plain data.
    struct Stats
    {
        public int attack;
        public int defence;
        public int superAttack;
        public int ultimateAttack;

        public Stats(int attack, int defence, int superAttack, int ultimateAttack)
        {
            this.attack = attack;
            this.defence = defence;
            this.superAttack = superAttack;
            this.ultimateAttack = ultimateAttack;
        }
    }
}
