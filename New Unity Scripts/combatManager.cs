using UnityEngine;
using UnityEngine.UI;

public class combatManager : MonoBehaviour
{
    public GameObject[] playerPrefabs; // Array of player prefabs (warrior, mage, rogue)
    public GameObject[] enemyPrefabs; // Array of enemy prefabs
    public Slider playerHealthSlider;
    public Slider playerManaSlider;
    public Slider enemyHealthSlider;

    private void Start()
    {
        // Spawn the player prefab based on the selected class
        SpawnPlayer();

        // Spawn the active enemy prefab
        SpawnActiveEnemy();
    }

    private void SpawnPlayer()
    {
        // Find the player object with the "Player" tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Debug.Log("Player found.");

            // Set the player's position
            player.transform.position = new Vector3(0f, 0f, 5f);

            // Disable the PlayerController script
            PlayerController playerController = player.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.enabled = false;
                Debug.Log("PlayerController script disabled.");
            }
            else
            {
                Debug.LogError("PlayerController script not found on the player.");
            }

            // Disable the PlayerInteraction script
            PlayerInteraction playerInteraction = player.GetComponent<PlayerInteraction>();
            if (playerInteraction != null)
            {
                playerInteraction.enabled = false;
                Debug.Log("PlayerInteraction script disabled.");
            }
            else
            {
                Debug.LogError("PlayerInteraction script not found on the player.");
            }

           // Get the component based on the player's class
            if (player.GetComponent<Warrior>() != null)
            {
                // If the player is a warrior
                Warrior warriorComponent = player.GetComponent<Warrior>();
                UpdateHealthSlider(warriorComponent.getPlayerHealthPoints());
                UpdateManaSlider(warriorComponent.getPlayerManaPoints());
            }
            else if (player.GetComponent<Mage>() != null)
            {
                // If the player is a mage
                Mage mageComponent = player.GetComponent<Mage>();
                UpdateHealthSlider(mageComponent.getPlayerHealthPoints());
                UpdateManaSlider(mageComponent.getPlayerManaPoints());
            }
            else if (player.GetComponent<Rogue>() != null)
            {
                // If the player is a rogue
                Rogue rogueComponent = player.GetComponent<Rogue>();
                UpdateHealthSlider(rogueComponent.getPlayerHealthPoints());
                UpdateManaSlider(rogueComponent.getPlayerManaPoints());
            }
            else
            {
                Debug.LogError("Player class not recognized.");
            }
        }
        else
        {
            Debug.LogError("Player not found. Make sure the player object is tagged with 'Player'.");
        }
    }


    private void SpawnActiveEnemy()
{
    // Get the active enemy ID from PlayerPrefs
    int activeEnemyID = PlayerPrefs.GetInt("ActiveEnemyID");

    // Find existing enemy objects with the "Enemy" tag
    GameObject[] existingEnemies = GameObject.FindGameObjectsWithTag("Enemy");

    if (existingEnemies.Length > 0)
    {
        // Iterate through existing enemies to find the one with the matching ID
        foreach (GameObject enemy in existingEnemies)
        {
            NonPlayer enemyComponent = enemy.GetComponent<NonPlayer>();
            if (enemyComponent != null && enemyComponent.enemyID == activeEnemyID)
            {
                // If an existing enemy with the matching ID is found, update its position
                Debug.Log($"Updating position of existing enemy with ID: {activeEnemyID}");

                // Move the enemy to the new position
                enemy.transform.position = new Vector3(5f, 0f, 5f); // Change the position as needed

                // Update the enemy's health slider
                UpdateEnemyHealthSlider(enemyComponent);

                return; // Exit the method after updating the enemy
            }
        }
    }

    // If no existing enemy with the matching ID is found, spawn a new enemy prefab
    if (activeEnemyID >= 0 && activeEnemyID < enemyPrefabs.Length)
    {
        GameObject enemyPrefab = enemyPrefabs[activeEnemyID];
        if (enemyPrefab != null)
        {
            // Instantiate the enemy prefab
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(5f, 0f, 5f), Quaternion.identity);
            Debug.Log("New enemy spawned.");

            // Set the position of the enemy based on the spawn position
            // Set other properties of the enemy as needed
        }
        else
        {
            Debug.LogError("Enemy prefab is null.");
        }
    }
    else
    {
        Debug.LogError("Invalid active enemy ID: " + activeEnemyID);
    }
}


    // Method to update the health slider with the given health points
    private void UpdateHealthSlider(float healthPoints)
    {
        if (playerHealthSlider != null)
        {
            // Update the player's health slider value based on the player's health points
            playerHealthSlider.value = healthPoints;
            Debug.Log("Player health slider updated.");
        }
        else
        {
            Debug.LogError("Player health slider reference is missing.");
        }
    }

    // Method to update the mana slider with the given mana points
    private void UpdateManaSlider(float manaPoints)
    {
        if (playerManaSlider != null)
        {
            // Update the player's mana slider value based on the player's mana points
            playerManaSlider.value = manaPoints;
            Debug.Log("Player mana slider updated.");
        }
        else
        {
            Debug.LogError("Player mana slider reference is missing.");
        }
    }

    // Method to update the health slider with the given health points for the enemy
    private void UpdateEnemyHealthSlider(NonPlayer enemy)
    {
    if (playerHealthSlider != null)
    {
        // Update the enemy's health slider value based on the enemy's current health points
        playerHealthSlider.value = enemy.nonPlayerHealthPoints;
        Debug.Log("Enemy health slider updated.");
    }
    else
    {
        Debug.LogError("Player health slider reference is missing.");
    }
    }
}
