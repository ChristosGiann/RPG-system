using UnityEngine;
using UnityEngine.UI;
using Rpg;

public class PlayerSetup : MonoBehaviour
{
    public Warrior warrior;
    public Mage mage;
    public Rogue rogue;
    
    public Text hpText; // Reference to the UI Text element for displaying HP
    public Text mpText; // Reference to the UI Text element for displaying MP

    void Start()
    {
        // Set up the player cube based on the selected class
        string selectedClass = PlayerPrefs.GetString("SelectedClass");
        
        if (selectedClass == "Warrior")
        {
            SetupWarrior();
            Debug.Log("Warrior class instantiated: " + (warrior != null));
        }
        else if (selectedClass == "Mage")
        {
            SetupMage();
            Debug.Log("Mage class instantiated: " + (mage != null));
        }
        else if (selectedClass == "Rogue")
        {
            SetupRogue();
            Debug.Log("Rogue class instantiated: " + (rogue != null));
        }
        else
        {
            Debug.LogError("Invalid player class selected");
        }
    }

    void SetupWarrior()
    {
        // Set up the player cube as a warrior
        warrior = new Warrior();
        warrior.setLevel(1); // Set initial level
        warrior.setPlayerHealthPoints(100); // Set initial health points
        warrior.setPlayerManaPoints(50); // Set initial mana points
        warrior.setPlayerGold(10); // Set initial gold
        warrior.setPlayerWeaponDamage(10); // Set initial weapon damage
        hpText.text = "HP: " + warrior.getPlayerHealthPoints().ToString();
        mpText.text = "MP: " + warrior.getPlayerManaPoints().ToString();
    }

    void SetupMage()
    {
        // Set up the player cube as a mage
        mage = new Mage();
        mage.setLevel(1); // Set initial level
        mage.setPlayerHealthPoints(50); // Set initial health points
        mage.setPlayerManaPoints(100); // Set initial mana points
        mage.setPlayerGold(10); // Set initial gold
        mage.setPlayerWeaponDamage(5); // Set initial weapon damage
        hpText.text = "HP: " + mage.getPlayerHealthPoints().ToString();
        mpText.text = "MP: " + mage.getPlayerManaPoints().ToString();
    }

    void SetupRogue()
    {
        // Set up the player cube as a rogue
        rogue = new Rogue();
        rogue.playerName = "Rogue";
        rogue.setLevel(1); // Set initial level
        rogue.setPlayerHealthPoints(75); // Set initial health points
        rogue.setPlayerManaPoints(75); // Set initial mana points
        rogue.setPlayerGold(10); // Set initial gold
        rogue.setPlayerWeaponDamage(20); // Set initial weapon damage
        hpText.text = "HP: " + rogue.getPlayerHealthPoints().ToString();
        mpText.text = "MP: " + rogue.getPlayerManaPoints().ToString();
    }
}
