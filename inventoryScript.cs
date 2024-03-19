using UnityEngine;
using System.Collections.Generic;

public class Inventory
{
    private List<Item> items; // List to store items
    private int capacity; // Capacity of the inventory

    // Constructor to initialize the inventory with a specified capacity
    public Inventory(int capacity)
    {
        this.capacity = capacity;
        items = new List<Item>(); // Initialize the list of items
    }

    // Method to add an item to the inventory
    public void AddItem(Item item)
    {
        // Check if the inventory is not full
        if (items.Count < capacity)
        {
            items.Add(item); // Add the item to the list
            Debug.Log($"Added {item.Name} to the inventory.");
        }
        else
        {
            Debug.Log("Inventory is full. Cannot add item.");
        }
    }

    // Method to remove an item from the inventory
    public void RemoveItem(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item); // Remove the item from the list
            Debug.Log($"Removed {item.Name} from the inventory.");
        }
        else
        {
            Debug.Log($"{item.Name} not found in the inventory.");
        }
    }

    // Method to check the remaining capacity of the inventory
    public int CheckCapacity()
    {
        return capacity - items.Count;
    }
}

public class Item
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public float Weight { get; private set; }
    public int Value { get; private set; }

    // Constructor to initialize the item
    public Item(string name, string description, float weight, int value)
    {
        Name = name;
        Description = description;
        Weight = weight;
        Value = value;
    }

    // Method to use the item
    public virtual void Use()
    {
        Debug.Log($"Using {Name}...");
        // Add logic here for how the item is used
    }
}

// Weapon class
public class Weapon
{
    public int weaponDamage;
    public int durability;

    // Constructor
    public Weapon(int damage, int durability)
    {
        this.weaponDamage = damage;
        this.durability = durability;
    }

    // Method to perform an attack
    public int Attack()
    {
        return weaponDamage; // Return weapon damage
    }

     // Method to check if the weapon is destroyed
    public bool Destroyed()
    {
        return durability <= 0;
    }

}

// Armor class
public class Armor
{
    public int defensePoints;
    public int durability;

    // Constructor
    public Armor(int defense, int durability)
    {
        this.defensePoints = defense;
        this.durability = durability;
    }

    // Method to perform defense
    public int Defend(int healthPoints)
    {
        return defensePoints;
    }

     // Method to check if the armor is destroyed
    public bool Destroyed()
    {
        return durability <= 0;
    }
}
