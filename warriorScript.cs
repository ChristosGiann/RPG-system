using UnityEngine;

public class Warrior : Player
{
    // Define skills using the Skill class
    private ManeuverSystem maneuverSystem;

    // Constructor to initialize skills
    public Warrior()
    {
        maneuverSystem = new ManeuverSystem();
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
        // Retrieve the first skill (index 0) from the maneuverList
        Skill rendingStrike = maneuverSystem.maneuverList[0];

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
        // Retrieve the second skill (index 1) from the maneuverList
        Skill puncture = maneuverSystem.maneuverList[1];

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
        // Retrieve the third skill (index 2) from the maneuverList
        Skill stomp = maneuverSystem.maneuverList[2];

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
        // Retrieve the fourth skill (index 3) from the maneuverList
        Skill whirlwind = maneuverSystem.maneuverList[3];

        // Activate skill and retrieve damage and cost
        (int damage, int cost) = whirlwind.activateSkill();

        // Decrease player's mana by the cost
        playerCurrentManaPoints -= cost;

        Debug.Log($"{playerName} uses {whirlwind.skillName}, dealing {damage} damage.");
        
        // Return the damage dealt by the skill
        return damage;
    }
}
