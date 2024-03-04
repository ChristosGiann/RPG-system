using UnityEngine;

public class Warrior : Player
    {
        public override int useAttack()
        {
            int damage = 25;
            Debug.Log($"{playerName} performs a heavy melee attack!");
            return damage;
        }
        public override int useSkill1()
        {
            int damage = 30;
            Debug.Log($"{playerName} uses Rending Strike, dealing {damage} damage.");
            return damage;
        }

        public override int useSkill2()
        {
            int damage = 20;
            Debug.Log($"{playerName} uses Puncture, dealing {damage} damage.");
            return damage;
        }

        public override int useSkill3()
        {
            int damage = 10;
            Debug.Log($"{playerName} uses Stomp, dealing {damage} damage.");
            return damage;
        }

        public override int useSkill4()
        {
            int damage = 30;
            Debug.Log($"{playerName} uses Whirlwind, dealing {damage} damage.");
            return damage;
        }
    }