using UnityEngine;

public class Mage : Player
{
    public override int useAttack()
    {
        int damage = playerWeaponDamage;
        Debug.Log($"{playerName} performs a weak melee attack!");
        return damage;
    }

    public override int useSkill1()
    {
        int damage = 20; // Set the damage value for Fireball
        Debug.Log($"{playerName} uses Fireball, dealing {damage} damage.");
        return damage;
    }

    public override int useSkill2()
    {
        int damage = 40; // Set the damage value for Frostbolt
        Debug.Log($"{playerName} uses Frostbolt, dealing {damage} damage.");
        return damage;
    }

    public override int useSkill3()
    {
        int damage = 60; // Set the damage value for Call Lightning
        Debug.Log($"{playerName} uses Call Lightning, dealing {damage} damage.");
        return damage;
    }

    public override int useSkill4()
    {
        int damage = 80; // Set the damage value for Aeonian Bloom
        Debug.Log($"{playerName} uses Aeonian Bloom, dealing {damage} damage.");
        return damage;
    }
}
