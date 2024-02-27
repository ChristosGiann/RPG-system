using UnityEngine;
using Rpg;

public class NonPlayer : Character
{
    public int nonPlayerLevel;
    public int nonPlayerHealthPoints;
    public int nonPlayerDamage;
    public string loot;

    public NonPlayer()
    {
        nonPlayerLevel = 0;
        nonPlayerHealthPoints = 0;
        nonPlayerDamage = 0;
        loot = "";
    }

    public override void useAttack()
    {
        Debug.Log("Attacks player");
    }

    // Damage
    public void TakeDamage(int playerWeaponDamage)
    {
        nonPlayerHealthPoints -= playerWeaponDamage;
        Debug.Log("NonPlayer takes damage");

        // Death
        if (nonPlayerHealthPoints <= 0)
        {
            NpcDeath();
        }
    }

    // Loot
    public string DropLoot()
    {
        return loot;
    }

    // Death
    private void NpcDeath()
    {
        Debug.Log("NonPlayer dies");
    }
}
