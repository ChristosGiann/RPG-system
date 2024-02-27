using UnityEngine;
    public class Rogue : Player
    {

        public override void useAttack()
        {
            Debug.Log($"{playerName} performs a critical melee attack!");
        }
        public override void useSkill1()
        {
            Debug.Log($"{playerName} uses Skill 1.");
        }

        public override void useSkill2()
        {
            Debug.Log($"{playerName} uses Skill 2.");
        }

        public override void useSkill3()
        {
            Debug.Log($"{playerName} uses Skill 3.");
        }

        public override void useSkill4()
        {
            Debug.Log($"{playerName} uses Skill 4.");
        }

    }