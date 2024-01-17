using System.Reflection.PortableExecutable;
using Rpg;

public class Item
    {
        public string itemName;
        public string itemDescription;
        public int itemWeight;
        public int itemValue;

        public Item()
            {
            itemName = "";
            itemDescription = "";
            itemWeight = 0;
            itemValue = 0;
            }
        
        public void Use()
        {
            Console.WriteLine("Item used");
        }
    }

public class Weapon
    {
        public int damagePoints;
        public int durability;

        public Weapon()
            {
            damagePoints = 0;
            durability = 0;
            }
        
        public void Attack(Player target)
        {
            Console.WriteLine("Attacked");
            target.TakeDamage(damagePoints);
        }
    }

public class Armor
    {
        public int defensePoints;
        public int durability;

        public Armor()
            {
            defensePoints = 0;
            durability = 0;
            }
        
        public void defend(Player target)
        {
            Console.WriteLine("Player defends with armor");
            target.playerHealthPoints += defensePoints;
        }
    }

public class Inventory
    {
        public List<string> items;
        public int capacity;

        public Inventory()
            {
            items = new List<string>();
            capacity = 0;
            }
        
        public void AddItem(string itemName)
        {
            if (CheckCapacity())
            {
                items.Add(itemName);
                Console.WriteLine($"{itemName} added to the inventory.");
            }
            else
            {
                Console.WriteLine("Inventory is at full capacity. Cannot add more items.");
            }
        }

        public void removeItem(string itemName)
        {
             items.Remove(itemName);
             Console.WriteLine($"{itemName} removed from the inventory.");
        }

         private bool CheckCapacity()
        {
            if (items.Count < capacity)
            {
                return true;
            }
            return false;
        }
    }
                                                    