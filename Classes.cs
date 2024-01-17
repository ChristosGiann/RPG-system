using Rpg;
//classes for the character
    public class Warrior : Player
    {
        public override void useAttack()
        {
            Console.WriteLine($"{playerName} performs a powerful melee attack!");
        }
        public override void useSkill1()
        {
            Console.WriteLine($"{playerName} uses Skill 1.");
        }

        public override void useSkill2()
        {
            Console.WriteLine($"{playerName} uses Skill 2.");
        }

        public override void useSkill3()
        {
            Console.WriteLine($"{playerName} uses Skill 3.");
        }

        public override void useSkill4()
        {
            Console.WriteLine($"{playerName} uses Skill 4.");
        }

    }

    public class Mage : Player
    {

        public override void useAttack()
        {
            Console.WriteLine($"{playerName} performs a weak melee attack!");
        }
        public override void useSkill1()
        {
            Console.WriteLine($"{playerName} uses Skill 1.");
        }

        public override void useSkill2()
        {
            Console.WriteLine($"{playerName} uses Skill 2.");
        }

        public override void useSkill3()
        {
            Console.WriteLine($"{playerName} uses Skill 3.");
        }

        public override void useSkill4()
        {
            Console.WriteLine($"{playerName} uses Skill 4.");
        }

    }

    public class Rogue : Player
    {

        public override void useAttack()
        {
            Console.WriteLine($"{playerName} performs a critical melee attack!");
        }
        public override void useSkill1()
        {
            Console.WriteLine($"{playerName} uses Skill 1.");
        }

        public override void useSkill2()
        {
            Console.WriteLine($"{playerName} uses Skill 2.");
        }

        public override void useSkill3()
        {
            Console.WriteLine($"{playerName} uses Skill 3.");
        }

        public override void useSkill4()
        {
            Console.WriteLine($"{playerName} uses Skill 4.");
        }

    }

