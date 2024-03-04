using UnityEngine;
    public class Rogue : Player
    {
        public override int useAttack()
        {
            int damage = 40;
            Debug.Log($"{playerName} performs a critical melee attack!");
            return damage;
        }
        public override int useSkill1()
        {
            int damage = 30;
            Debug.Log($"{playerName} uses Piercing Strike, dealing {damage} damage.");
            return damage;
        }

        public override int useSkill2()
        {
            int damage = 30;
            Debug.Log($"{playerName} uses Fast Swings, dealing {damage} damage.");
            return damage;
        }

        public override int useSkill3()
        {
            int damage = 60;
            Debug.Log($"{playerName} uses Backstab, dealing {damage} damage.");
            return damage;
        }

        public override int useSkill4()
        {
            int damage = 100;
            Debug.Log($"{playerName} uses One Stab Man, dealing {damage} damage.");
            return damage;
        }

    }