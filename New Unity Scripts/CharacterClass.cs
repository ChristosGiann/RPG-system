using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Character : MonoBehaviour
        {
            public virtual int useAttack()
            {
                Debug.Log("performs a basic attack.");
                return 0;
            }
        }
    public class Player : Character
        {
        public string playerName;
        public int playerLevel;
        public int playerExperiencePoints;
        public int playerHealthPoints;
        public int playerManaPoints;
        public int playerGold;
        public int playerWeaponDamage;

        public Player(){
            playerName = "";
            playerLevel = 0;
            playerExperiencePoints = 0;
            playerHealthPoints = 0;
            playerManaPoints = 0;
            playerGold = 0;
            playerWeaponDamage = 0;
            }

     

        public void setName(string newplayerName){
            playerName = newplayerName;
            }

        public string getName(){
            return playerName;
            }

        //Levels       
        public void setLevel(int newPlayerLevel){
            playerLevel = newPlayerLevel;
            }

        public int getLevel(){
            return playerLevel;
        }

        //ExperiencePoints
        public void setExperiencePoints(int updatedPlayerExperiencePoints){
            playerExperiencePoints = updatedPlayerExperiencePoints;
            }

        public int getExperiencePoints(){
            return playerExperiencePoints;
            }

        //HealthPoints
        public void setPlayerHealthPoints(int newPlayerHealthPoints){
            playerHealthPoints = newPlayerHealthPoints;
            }

        public int getPlayerHealthPoints(){
            return playerHealthPoints;
            } 

        //ManaPoints
        public void setPlayerManaPoints(int newPlayerManaPoints){
            playerManaPoints = newPlayerManaPoints;
            }

        public int getPlayerManaPoints(){
            return playerManaPoints;
            } 

        //Gold
        public void setPlayerGold(int newPlayerGold){
            playerGold = newPlayerGold;
            }

        public int getPlayerGold(){
            return playerGold;
            } 

        //Methods
        public int levelUp(){
            playerLevel += 1;
            return playerLevel;
        }

        public int gainExperience(){
            playerExperiencePoints += 1;
            return playerExperiencePoints;
        }

        public void GainExperience(int enemyExperience)
        {
            playerExperiencePoints += enemyExperience;
        }

        public void setPlayerWeaponDamage(int newPlayerWeaponDamage)
        {
        playerWeaponDamage = newPlayerWeaponDamage;
        }

        public void TakeDamage(int nonPlayerDamage)
        {
            playerHealthPoints -= nonPlayerDamage;
        }

        //Abilities
        public override int useAttack()
        {
            Debug.Log($"{playerName} performs a basic attack.");
            return 0;
        }
        public virtual int useSkill1()
        {
            Debug.Log($"{playerName} uses Skill 1.");
            return 0;
        }

        public virtual int useSkill2()
        {
            Debug.Log($"{playerName} uses Skill 2.");
            return 0;
        }

        public virtual int useSkill3()
        {
            Debug.Log($"{playerName} uses Skill 3.");
            return 0;
        }

        public virtual int useSkill4()
        {
            Debug.Log($"{playerName} uses Skill 4.");
            return 0;
        }
       } 


//classes for the character
   

    




public class NonPlayer : Character
        {
        public int nonPlayerLevel;
        public int nonPlayerHealthPoints;
        public int nonPlayerDamage;
        public string loot;
        private Player targetPlayer;
        public int enemyID;

        public NonPlayer(Player player)
            {
                nonPlayerLevel = 0;
                nonPlayerHealthPoints = 0;
                nonPlayerDamage = 0;
                loot = "";
                targetPlayer = player; 
            }
                
        public override int useAttack()
            {
                Debug.Log("Attacks player");
                return nonPlayerDamage;
            }

        //Damage
        public void TakeDamage(int playerWeaponDamage)
        {
            nonPlayerHealthPoints -= playerWeaponDamage;
            Debug.Log("NonPlayer takes damage");

            //Death
            if (nonPlayerHealthPoints <= 0)
            {
                NpcDeath();
            }
        }

        //Loot
        public string DropLoot()
        {
            return loot;
        }

        //Death
        private void NpcDeath()
        {
            Debug.Log("NonPlayer dies");
        }

}

