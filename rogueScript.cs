using UnityEngine;

public class Rogue : Player
{
    // Define the shenanigans system
    private ShenanigansSystem shenanigansSystem;

    // Constructor to initialize shenanigans
    public Rogue()
    {
        // Initialize the shenanigans system
        shenanigansSystem = new ShenanigansSystem();
    }

    // Override method to use attack
    public override int useAttack()
    {
        int damage = playerWeaponDamage;
        Debug.Log($"{playerName} performs a critical melee attack!");
        return damage;
    }

    // Override method to use skill 1
    public override int useSkill1()
    {
        // Retrieve the first shenanigan (index 0) from the shenanigans list
        Skill piercingStrike = shenanigansSystem.shenanigansList[0];

        // Activate shenanigan and retrieve damage and cost
        (int damage, int cost) = piercingStrike.activateSkill();

        // Decrease player's mana by the cost
        playerCurrentManaPoints -= cost;

        Debug.Log($"{playerName} uses {piercingStrike.skillName}, dealing {damage} damage.");
        
        // Return the damage dealt by the shenanigan
        return damage;
    }

    // Override method to use skill 2
    public override int useSkill2()
    {
        // Retrieve the second shenanigan (index 1) from the shenanigans list
        Skill fastSwings = shenanigansSystem.shenanigansList[1];

        // Activate shenanigan and retrieve damage and cost
        (int damage, int cost) = fastSwings.activateSkill();

        // Decrease player's mana by the cost
        playerCurrentManaPoints -= cost;

        Debug.Log($"{playerName} uses {fastSwings.skillName}, dealing {damage} damage.");

        // Return the damage dealt by the shenanigan
        return damage;
    }

    // Override method to use skill 3
    public override int useSkill3()
    {
        // Retrieve the third shenanigan (index 2) from the shenanigans list
        Skill backstab = shenanigansSystem.shenanigansList[2];

        // Activate shenanigan and retrieve damage and cost
        (int damage, int cost) = backstab.activateSkill();

        // Decrease player's mana by the cost
        playerCurrentManaPoints -= cost;

        Debug.Log($"{playerName} uses {backstab.skillName}, dealing {damage} damage.");

        // Return the damage dealt by the shenanigan
        return damage;
    }

    // Override method to use skill 4
    public override int useSkill4()
    {
        // Retrieve the fourth shenanigan (index 3) from the shenanigans list
        Skill oneStabMan = shenanigansSystem.shenanigansList[3];

        // Activate shenanigan and retrieve damage and cost
        (int damage, int cost) = oneStabMan.activateSkill();

        // Decrease player's mana by the cost
        playerCurrentManaPoints -= cost;

        Debug.Log($"{playerName} uses {oneStabMan.skillName}, dealing {damage} damage.");

        // Return the damage dealt by the shenanigan
        return damage;
    }
}
