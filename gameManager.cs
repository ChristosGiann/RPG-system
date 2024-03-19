using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject warriorPrefab;
    public GameObject magePrefab;
    public GameObject roguePrefab;
    public GameObject enemyPrefab;

    private void Start()
    {
        SpawnSelectedClass();
        SpawnEnemy();
    }

    private void SpawnSelectedClass()
    {
        // Check if a player prefab is already present in the scene
        GameObject existingPlayer = GameObject.FindGameObjectWithTag("Player");
        if (existingPlayer != null)
        {
            Debug.Log("Player prefab already exists in the scene.");
            return; // Exit the method if player prefab already exists
        }

        string selectedClass = PlayerPrefs.GetString("SelectedClass");

        switch (selectedClass)
        {
            case "Warrior":
                if (warriorPrefab != null)
                    CreateWarrior();
                else
                    Debug.LogError("Warrior prefab reference is null.");
                break;
            case "Mage":
                if (magePrefab != null)
                    CreateMage();
                else
                    Debug.LogError("Mage prefab reference is null.");
                break;
            case "Rogue":
                if (roguePrefab != null)
                    CreateRogue();
                else
                    Debug.LogError("Rogue prefab reference is null.");
                break;
            default:
                Debug.LogError("Invalid class selected: " + selectedClass);
                break;
        }
    }

    private void CreateWarrior()
    {
        Debug.Log("Creating Warrior");
        GameObject warriorGO = Instantiate(warriorPrefab, Vector3.zero, Quaternion.identity);
        DontDestroyOnLoad(warriorGO);
        Warrior warriorComponent = warriorGO.GetComponent<Warrior>();
        if (warriorComponent != null)
        {
            warriorComponent.setName("Warrior");
            warriorComponent.setLevel(1);
            warriorComponent.setPlayerHealthPoints(100);
            warriorComponent.setPlayerCurrentHealthPoints(100);
            warriorComponent.setPlayerManaPoints(50);
            warriorComponent.setPlayerCurrentManaPoints(50);
            warriorComponent.setPlayerGold(10);
            warriorComponent.setPlayerWeaponDamage(25);

            Debug.Log("Warrior Created");
        }
        else
        {
            Debug.LogError("Warrior component not found in the Warrior prefab.");
        }
    }


 private void CreateMage()
{
    Debug.Log("Creating Mage");
    if (magePrefab != null)
    {
        GameObject mageGO = Instantiate(magePrefab, Vector3.zero, Quaternion.identity);
        DontDestroyOnLoad(mageGO);
        Mage mageComponent = mageGO.GetComponent<Mage>();
        if (mageComponent != null)
        {
            mageComponent.setName("Mage");
            mageComponent.setLevel(1);
            mageComponent.setPlayerHealthPoints(50);
            mageComponent.setPlayerCurrentHealthPoints(50);
            mageComponent.setPlayerManaPoints(100);
            mageComponent.setPlayerCurrentManaPoints(100);
            mageComponent.setPlayerGold(10);
            mageComponent.setPlayerWeaponDamage(10);

            Debug.Log("Mage Created");
        }
        else
        {
            Debug.LogError("Mage component not found in the Mage prefab.");
        }
    }
    else
    {
        Debug.LogError("Mage prefab reference is null.");
    }
}

private void CreateRogue()
{
    Debug.Log("Creating Rogue");
    if (roguePrefab != null)
    {
        GameObject rogueGO = Instantiate(roguePrefab, Vector3.zero, Quaternion.identity);
        DontDestroyOnLoad(rogueGO);
        Rogue rogueComponent = rogueGO.GetComponent<Rogue>();
        if (rogueComponent != null)
        {
            rogueComponent.setName("Rogue");
            rogueComponent.setLevel(1);
            rogueComponent.setPlayerHealthPoints(75);
            rogueComponent.setPlayerCurrentHealthPoints(75);
            rogueComponent.setPlayerManaPoints(75);
            rogueComponent.setPlayerCurrentManaPoints(75);
            rogueComponent.setPlayerGold(10);
            rogueComponent.setPlayerWeaponDamage(40);

            Debug.Log("Rogue Created"); 
        }
        else
        {
            Debug.LogError("Rogue component not found in the Rogue prefab.");
        }
    }
    else
    {
        Debug.LogError("Rogue prefab reference is null.");
    }
    }

private void SpawnEnemy()
{
     // Check if there are already enemies in the scene
    GameObject[] existingEnemies = GameObject.FindGameObjectsWithTag("Enemy");
    if (existingEnemies.Length > 0)
    {
        Debug.Log("Enemies already exist in the scene. Not spawning more.");
        return; // Exit the method if enemies already exist
    }
    
    if (enemyPrefab != null)
    {
        Debug.Log("Spawning Enemies");

        List<Vector3> spawnPositions = new List<Vector3>(); // List to store spawn positions

        // Spawn three enemies
        for (int i = 0; i < 3; i++)
        {
            // Generate random positions within the specified range
            Vector3 spawnPosition = GetRandomSpawnPosition(spawnPositions);

            // Spawn the enemy at the random position
            GameObject enemyGO = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            DontDestroyOnLoad(enemyGO);
            NonPlayer enemyComponent = enemyGO.GetComponent<NonPlayer>();
            if (enemyComponent != null)
            {
                enemyComponent.nonPlayerLevel = 1;
                enemyComponent.nonPlayerHealthPoints = 100;
                enemyComponent.nonPlayerCurrentHealthPoints = 100;
                enemyComponent.nonPlayerDamage = 10;
                enemyComponent.loot = "Gold";
                enemyComponent.enemyID = i; // Assign an identifier to the enemy
                Debug.Log($"Enemy {i + 1} Spawned at {spawnPosition}"); 
                spawnPositions.Add(spawnPosition); // Add the spawn position to the list
            }
            else
            {
                Debug.LogError("NonPlayer component not found in the Enemy prefab.");
            }
        }
    }
    else
    {
        Debug.LogError("Enemy prefab reference is null.");
    }

    
}

// Method to generate random spawn positions with a minimum distance of 3ft from each other
private Vector3 GetRandomSpawnPosition(List<Vector3> existingPositions)
{
    Vector3 spawnPosition;
    bool validPosition = false;

    // Loop until a valid position is found
    do
    {
        // Generate random positions within the specified range
        float randomX = Random.Range(-20f, 20f);
        float randomZ = Random.Range(10f, 80f);
        spawnPosition = new Vector3(randomX, 0f, randomZ);

        // Check if the position is at least 3ft away from existing positions
        validPosition = true;
        foreach (Vector3 existingPos in existingPositions)
        {
            if (Vector3.Distance(spawnPosition, existingPos) < 5f)
            {
                validPosition = false;
                break;
            }
        }
    } while (!validPosition);

    return spawnPosition;
}



}