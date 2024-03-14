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
