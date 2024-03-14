using UnityEngine;

public class Rogue : Player
{
    // Define skills using the Skill class
    private Skill piercingStrike;
    private Skill fastSwings;
    private Skill backstab;
    private Skill oneStabMan;

    // Constructor to initialize skills
    public Rogue()
    {
        // Initialize skills with name, description, effect, value, and cost
        piercingStrike = new Skill("Piercing Strike", "A swift and precise thrust.", "Deals damage to vital points.", 30, 15);
        fastSwings = new Skill("Fast Swings", "A flurry of rapid strikes.", "Inflicts multiple hits on the target.", 20, 10);
        backstab = new Skill("Backstab", "A stealthy attack from behind.", "Deals massive damage with a surprise attack.", 60, 25);
        oneStabMan = new Skill("One Stab Man", "A lethal single strike.", "Instantly defeats the target with a deadly blow.", 100, 50);
    }

    // Override methods to use skills
    public override int useAttack()
    {
        int damage = playerWeaponDamage;
        Debug.Log($"{playerName} performs a critical melee attack!");
        return damage;
    }

    public override int useSkill1()
    {
        // Activate skill and retrieve damage and cost
        var (damage, cost) = piercingStrike.activateSkill();

        // Decrease player's mana by the cost
        // Assuming you have a property called 'playerCurrentManaPoints' in your Player class
        playerCurrentManaPoints -= cost;

        Debug.Log($"{playerName} uses {piercingStrike.skillName}, dealing {damage} damage.");
        
        // Return the damage dealt by the skill
        return damage;
    }

    public override int useSkill2()
    {
        // Activate skill and retrieve damage and cost
        var (damage, cost) = fastSwings.activateSkill();

        // Decrease player's mana by the cost
        playerCurrentManaPoints -= cost;

        Debug.Log($"{playerName} uses {fastSwings.skillName}, dealing {damage} damage.");

        // Return the damage dealt by the skill
        return damage;
    }

    public override int useSkill3()
    {
        // Activate skill and retrieve damage and cost
        var (damage, cost) = backstab.activateSkill();

        // Decrease player's mana by the cost
        playerCurrentManaPoints -= cost;

        Debug.Log($"{playerName} uses {backstab.skillName}, dealing {damage} damage.");

        // Return the damage dealt by the skill
        return damage;
    }

    public override int useSkill4()
    {
        // Activate skill and retrieve damage and cost
        var (damage, cost) = oneStabMan.activateSkill();

        // Decrease player's mana by the cost
        playerCurrentManaPoints -= cost;

        Debug.Log($"{playerName} uses {oneStabMan.skillName}, dealing {damage} damage.");

        // Return the damage dealt by the skill
        return damage;
    }
}
