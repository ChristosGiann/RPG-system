using Rpg;

public class NonPlayer : Character
        {
        public int nonPlayerLevel;
        public int nonPlayerHealthPoints;
        public int nonPlayerDamage;
        public string loot;
        private Player targetPlayer;

        public NonPlayer(Player player)
            {
                nonPlayerLevel = 0;
                nonPlayerHealthPoints = 0;
                nonPlayerDamage = 0;
                loot = "";
                targetPlayer = player; 
            }
                
        public override void useAttack()
            {
                Console.WriteLine("Attacks player");
                // Assuming there is a reference to the player object, adjust the following line accordingly
                targetPlayer.TakeDamage(nonPlayerDamage);
            }

        //Damage
        public void TakeDamage(int playerWeaponDamage)
        {
            nonPlayerHealthPoints -= playerWeaponDamage;
            Console.WriteLine("NonPlayer takes damage");

            //Death
            if (nonPlayerHealthPoints <= 0)
            {
                NpcDeath();
            }
        }

        //Loot
        public string DropLoot()
        {
            return loot;
        }

        //Death
        private void NpcDeath()
        {
            Console.WriteLine("NonPlayer dies");
        }

}