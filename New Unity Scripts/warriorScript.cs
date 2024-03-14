using UnityEngine;

public class Warrior : Player
{
    // Define skills using the Skill class
    private Skill rendingStrike;
    private Skill puncture;
    private Skill stomp;
    private Skill whirlwind;

    // Constructor to initialize skills
    public Warrior()
    {
        // Initialize skills with name, description, effect, value, and cost
        rendingStrike = new Skill("Rending Strike", "A powerful slashing attack.", "Deals damage to the target.", 30, 15);
        puncture = new Skill("Puncture", "A quick and precise thrust.", "Inflicts damage and may penetrate armor.", 20, 10);
        stomp = new Skill("Stomp", "A forceful ground pound.", "Knocks down enemies and deals area damage.", 10, 5);
        whirlwind = new Skill("Whirlwind", "A spinning attack with great reach.", "Hits multiple targets for damage.", 30, 20);
    }

    // Override methods to use skills
    public override int useAttack()
    {
        int damage = playerWeaponDamage;
        Debug.Log($"{playerName} performs a heavy melee attack!");
        return damage;
    }

    public override int useSkill1()
    {
        // Activate skill and retrieve damage and cost
        (int damage, int cost) = rendingStrike.activateSkill();

        // Decrease player's mana by the cost
        playerCurrentManaPoints -= cost;

        Debug.Log($"{playerName} uses {rendingStrike.skillName}, dealing {damage} damage.");

        // Return the damage dealt by the skill
        return damage;
    }

    public override int useSkill2()
    {
        // Activate skill and retrieve damage and cost
        (int damage, int cost) = puncture.activateSkill();

        // Decrease player's mana by the cost
        playerCurrentManaPoints -= cost;

        Debug.Log($"{playerName} uses {puncture.skillName}, dealing {damage} damage.");

        // Return the damage dealt by the skill
        return damage;
    }

    public override int useSkill3()
    {
        // Activate skill and retrieve damage and cost
        (int damage, int cost) = stomp.activateSkill();

        // Decrease player's mana by the cost
        playerCurrentManaPoints -= cost;

        Debug.Log($"{playerName} uses {stomp.skillName}, dealing {damage} damage.");

        // Return the damage dealt by the skill
        return damage;
    }

    public override int useSkill4()
    {
        // Activate skill and retrieve damage and cost
        (int damage, int cost) = whirlwind.activateSkill();

        // Decrease player's mana by the cost
        playerCurrentManaPoints -= cost;

        Debug.Log($"{playerName} uses {whirlwind.skillName}, dealing {damage} damage.");

        // Return the damage dealt by the skill
        return damage;
    }
}
