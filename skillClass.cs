using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Skill
{
    public string skillName;
    public string skillDescription;
    public string skillEffect;
    public int Value;
    public int Cost;

    public Skill(string name, string description, string effect, int value, int cost)
    {
        skillName = name;
        skillDescription = description;
        skillEffect = effect;
        Value = value; // Initialize value
        Cost = cost;   // Initialize cost
    }

    // Modified activateSkill method to return a tuple containing damage and cost
    public (int value, int cost) activateSkill()
    {
        return (Value, Cost);
    }
}


public class MagicSystem
{
    public List<Skill> spellList = new List<Skill>(); // List to store spellList
    public int manaPool; // Mana pool

     // Constructor to initialize the spell list
    public MagicSystem()
    {
        spellList = new List<Skill>();

        // Create and add Fireball skill
        Skill fireball = new Skill("Fireball", "Launches a fiery projectile.", "Deals damage to the target.", 20, 10);
        spellList.Add(fireball);

        // Create and add Frostbolt skill
        Skill frostbolt = new Skill("Frostbolt", "Shoots a freezing bolt.", "Inflicts frost damage on the target.", 40, 15);
        spellList.Add(frostbolt);

        // Create and add Call Lightning skill
        Skill callLightning = new Skill("Call Lightning", "Summons a lightning bolt.", "Strikes the target with lightning.", 60, 20);
        spellList.Add(callLightning);

        // Create and add Aeonian Bloom skill
        Skill aeonianBloom = new Skill("Aeonian Bloom", "Unleashes a powerful arcane explosion.", "Causes massive damage to the target.", 80, 25);
        spellList.Add(aeonianBloom);
    }
    // Method to cast a spell
    public void CastSpell(Skill spell)
    {
        // Check if the spell is in the list of spellList known to the player
        if (!spellList.Contains(spell))
        {
            Debug.Log("You have not learned this spell yet.");
            return;
        }

        // Assume the spell's damage and cost are known attributes of the spell
        (int value, int cost) = spell.activateSkill();

        // Check if there is enough mana to cast the spell
        if (manaPool >= spell.Cost)
        {
            // Reduce mana pool by the mana cost of the spell
            manaPool -= spell.Cost;

            // Activate the spell
            Debug.Log($"Casting {spell.skillName}. Damage dealt: {value}");
        }
        else
        {
            Debug.Log("Not enough mana to cast the spell.");
        }
    }
    // Method to learn a new spell
    public void LearnSpell(Skill newSpell)
    {
        if (!spellList.Contains(newSpell))
        {
            spellList.Add(newSpell);
            Debug.Log($"Learned new spell: {newSpell.skillName}");
        }
        else
        {
            Debug.Log("You have already learned this spell.");
        }
    }

    // Method to regenerate mana
    public void RegenerateMana(int amount)
    {
        manaPool += amount;
        Debug.Log($"Regenerated {amount} mana. Current mana pool: {manaPool}");
    }
}


public class ManeuverSystem
{
    public List<Skill> maneuverList = new List<Skill>(); // List to store maneuverList

    // Constructor to initialize the maneuver list
    public ManeuverSystem()
    {
        maneuverList = new List<Skill>();

        // Create and add Rending Strike maneuver
        Skill rendingStrike = new Skill("Rending Strike", "A powerful slashing attack.", "Deals damage to the target.", 30, 15);
        maneuverList.Add(rendingStrike);

        // Create and add Puncture maneuver
        Skill puncture = new Skill("Puncture", "A quick and precise thrust.", "Inflicts damage and may penetrate armor.", 20, 10);
        maneuverList.Add(puncture);

        // Create and add Stomp maneuver
        Skill stomp = new Skill("Stomp", "A forceful ground pound.", "Knocks down enemies and deals area damage.", 10, 5);
        maneuverList.Add(stomp);

        // Create and add Whirlwind maneuver
        Skill whirlwind = new Skill("Whirlwind", "A spinning attack with great reach.", "Hits multiple targets for damage.", 30, 20);
        maneuverList.Add(whirlwind);
    }

    // Method to activate a maneuver
    public void ActivateManeuver(Skill maneuver)
    {
        // Check if the maneuver is in the list of maneuverList known to the player
        if (!maneuverList.Contains(maneuver))
        {
            Debug.Log("You have not learned this maneuver yet.");
            return;
        }

        // Assume the maneuver's damage and cost are known attributes of the maneuver
        (int value, int cost) = maneuver.activateSkill();

        // Implement logic to activate the maneuver (e.g., apply damage to the target)
        Debug.Log($"Activating {maneuver.skillName}. Damage dealt: {value}");
    }

    // Method to learn a new maneuver
    public void LearnManeuver(Skill newManeuver)
    {
        if (!maneuverList.Contains(newManeuver))
        {
            maneuverList.Add(newManeuver);
            Debug.Log($"Learned new maneuver: {newManeuver.skillName}");
        }
        else
        {
            Debug.Log("You have already learned this maneuver.");
        }
    }
}

public class ShenanigansSystem
{
    public List<Skill> shenanigansList = new List<Skill>(); // List to store shenanigans

    // Constructor to initialize the shenanigans list
    public ShenanigansSystem()
    {
        shenanigansList = new List<Skill>();

        // Create and add Piercing Strike shenanigan
        Skill piercingStrike = new Skill("Piercing Strike", "A swift and precise thrust.", "Deals damage to vital points.", 30, 15);
        shenanigansList.Add(piercingStrike);

        // Create and add Fast Swings shenanigan
        Skill fastSwings = new Skill("Fast Swings", "A flurry of rapid strikes.", "Inflicts multiple hits on the target.", 20, 10);
        shenanigansList.Add(fastSwings);

        // Create and add Backstab shenanigan
        Skill backstab = new Skill("Backstab", "A stealthy attack from behind.", "Deals massive damage with a surprise attack.", 60, 25);
        shenanigansList.Add(backstab);

        // Create and add One Stab Man shenanigan
        Skill oneStabMan = new Skill("One Stab Man", "A lethal single strike.", "Instantly defeats the target with a deadly blow.", 100, 50);
        shenanigansList.Add(oneStabMan);
    }

    // Method to activate a shenanigan
    public void ActivateShenanigan(Skill shenanigan)
    {
        // Check if the shenanigan is in the list of shenanigans known to the player
        if (!shenanigansList.Contains(shenanigan))
        {
            Debug.Log("You have not learned this shenanigan yet.");
            return;
        }

        // Assume the shenanigan's damage and cost are known attributes of the shenanigan
        (int damage, int cost) = shenanigan.activateSkill();

        // Activate the shenanigan
        Debug.Log($"Using {shenanigan.skillName}. Damage dealt: {damage}");
    }

    // Method to learn a new shenanigan
    public void LearnShenanigan(Skill newShenanigan)
    {
        if (!shenanigansList.Contains(newShenanigan))
        {
            shenanigansList.Add(newShenanigan);
            Debug.Log($"Learned new shenanigan: {newShenanigan.skillName}");
        }
        else
        {
            Debug.Log("You have already learned this shenanigan.");
        }
    }
}


