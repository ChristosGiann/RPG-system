using UnityEngine;

public class Mage : Player
{
    // Define skills using the Skill class
    private MagicSystem magicSystem;
    // Constructor to initialize skills
    public Mage()
    {
        magicSystem = new MagicSystem();
    }

    // Override methods to use skills
    public override int useAttack()
    {
        int damage = playerWeaponDamage;
        Debug.Log($"{playerName} performs a weak melee attack!");
        return damage;
    }

    public override int useSkill1()
    {
        // Retrieve the first skill (index 0) from the spellList
        Skill fireball = magicSystem.spellList[0];

        // Activate skill and retrieve damage and cost
        (int damage, int cost) = fireball.activateSkill();

        // Decrease player's mana by the cost
        playerCurrentManaPoints -= cost;

        Debug.Log($"{playerName} uses {fireball.skillName}, dealing {damage} damage.");
        
        // Return the damage dealt by the skill
        return damage;
    }

    public override int useSkill2()
    {
        // Retrieve the second skill (index 1) from the spellList
        Skill frostbolt = magicSystem.spellList[1];

        // Activate skill and retrieve damage and cost
        (int damage, int cost) = frostbolt.activateSkill();

        // Decrease player's mana by the cost
        playerCurrentManaPoints -= cost;

        Debug.Log($"{playerName} uses {frostbolt.skillName}, dealing {damage} damage.");
        
        // Return the damage dealt by the skill
        return damage;
    }

    public override int useSkill3()
    {
        // Retrieve the third skill (index 2) from the spellList
        Skill callLightning = magicSystem.spellList[2];

        // Activate skill and retrieve damage and cost
        (int damage, int cost) = callLightning.activateSkill();

        // Decrease player's mana by the cost
        playerCurrentManaPoints -= cost;

        Debug.Log($"{playerName} uses {callLightning.skillName}, dealing {damage} damage.");
        
        // Return the damage dealt by the skill
        return damage;
    }

    public override int useSkill4()
    {
        // Retrieve the fourth skill (index 3) from the spellList
        Skill aeonianBloom = magicSystem.spellList[3];

        // Activate skill and retrieve damage and cost
        (int damage, int cost) = aeonianBloom.activateSkill();

        // Decrease player's mana by the cost
        playerCurrentManaPoints -= cost;

        Debug.Log($"{playerName} uses {aeonianBloom.skillName}, dealing {damage} damage.");
        
        // Return the damage dealt by the skill
        return damage;
    }
}
