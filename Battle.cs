using Rpg;

public class Skill
    {
        public string skillName;
        public string skillDescription;
        public string skillEffect;

        public Skill()
            {
            skillName = "";
            skillDescription = "";
            skillEffect = "";
            }

        public void activateSkill()
          {
            Console.WriteLine($"Effect: {skillEffect}");
          }  
    }


public class  MagicSystem : Skill
    {
        public List<string> spells;
        public int manaPool;
        public int manaAmount;
        public int manaCost;

        public MagicSystem()
            {
            spells = new List<string>();
            manaPool = 0;
            }

        public void castSpell()
          {
              if (manaPool - manaCost >= 0)
            {
                 Console.WriteLine("Spell activated");
                manaPool -= manaCost;
            }
            else
            {
                Console.WriteLine("Not enough mana to cast the spell");
            }
          }  

        public void learnSpell()
          {
            spells.Add(skillName);
            Console.WriteLine("Spell learned");
          } 

        public void regenerateMana()
          {
            manaPool += manaAmount;
            Console.WriteLine("Mana regen");
          } 
        
    }

public class BattleSystem
{
        public List<Character> participants;
        private Queue<Character> turnOrder;

        public BattleSystem(List<Character> participants)
        {
            this.participants = participants;
            turnOrder = new Queue<Character>(participants);
        }

        public void startBattle()
          {
            while (turnOrder.Count > 1)
            {
                Character currentParticipant = turnOrder.Peek();

                currentParticipant.useAttack();

                MoveToBackOfQueue();

                Console.WriteLine("Press Enter for the next turn...");
                Console.ReadLine();
            }

            endBattle();
          } 

        private void MoveToBackOfQueue()
        {
            Character currentParticipant = turnOrder.Dequeue();
            turnOrder.Enqueue(currentParticipant);
        }
        public void endBattle()
          {
            Console.WriteLine("Battle ended!");
          } 
    }