using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CombatManager : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    public GameObject[] enemyPrefabs;
    public Slider playerHealthSlider;
    public Slider playerManaSlider;
    public Slider enemyHealthSlider;
    public List<Button> playerActionButtons;

    private Player player;
    private NonPlayer enemy;
    private bool playerActionTaken = false;

    private enum TurnOrder { START, PLAYER_TURN, ENEMY_TURN, END }
    private TurnOrder currentState;

    private void Start()
    {
        SpawnPlayer();
        SpawnActiveEnemy();
        EnablePlayerActionButtons();

        currentState = TurnOrder.START;
        StartCoroutine(StartBattle());
    }

    private void SpawnPlayer()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            Debug.Log("Player found.");

            playerObject.transform.position = new Vector3(0f, 0f, 5f);

            player = playerObject.GetComponent<Player>();
            UpdateHealthSlider(playerHealthSlider, player.getPlayerCurrentHealthPoints(), player.getPlayerHealthPoints());
            UpdateManaSlider(playerManaSlider, player.getPlayerCurrentManaPoints(), player.getPlayerManaPoints());
        }
        else
        {
            Debug.LogError("Player not found. Make sure the player object is tagged with 'Player'.");
        }
    }

    private void SpawnActiveEnemy()
    {
        int activeEnemyID = PlayerPrefs.GetInt("ActiveEnemyID");

        // Find all game objects with the "Enemy" tag
        GameObject[] existingEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemyObject in existingEnemies)
        {
            NonPlayer enemyComponent = enemyObject.GetComponent<NonPlayer>();
            
            // Check if the enemy's ID matches the activeEnemyID
            if (enemyComponent != null && enemyComponent.enemyID == activeEnemyID)
            {
                // Set the enemy prefab position and update health slider
                enemyObject.transform.position = new Vector3(5f, 0f, 5f);
                Debug.Log("Existing enemy found with ID: " + activeEnemyID);
                enemy = enemyComponent; // Assign the enemy component
                UpdateEnemyHealthSlider(enemy, enemyHealthSlider, enemy.nonPlayerCurrentHealthPoints, enemy.nonPlayerHealthPoints);
                return; // Exit the method after finding the matching enemy
            }
        }

        Debug.LogError("No existing enemy found with ID: " + activeEnemyID);
    }


    private void UpdateHealthSlider(Slider slider, float currentHealthPoints, float maxHealthPoints)
    {
        if (slider != null)
        {
            slider.maxValue = maxHealthPoints; // Set the maximum value of the slider
            slider.value = currentHealthPoints; // Set the current value of the slider
            Debug.Log("Health slider updated.");
        }
        else
        {
            Debug.LogError("Slider reference is missing.");
        }
    }

    private void UpdateManaSlider(Slider slider, float currentManaPoints, float maxManaPoints)
    {
        if (slider != null)
        {
            slider.maxValue = maxManaPoints;
            slider.value = currentManaPoints;
            Debug.Log("Mana slider updated.");
        }
        else
        {
            Debug.LogError("Slider reference is missing.");
        }
    }

    private void UpdateEnemyHealthSlider(NonPlayer enemy, Slider enemyHealthSlider, float nonPlayerHealthPoints, float nonPlayerCurrentHealthPoints)
    {
        if (enemy != null && enemyHealthSlider != null)
        {
            enemyHealthSlider.maxValue = enemy.nonPlayerHealthPoints; // Set the maximum value of the slider
            enemyHealthSlider.value = enemy.nonPlayerCurrentHealthPoints; // Set the current value of the slider
            Debug.Log("Enemy health slider updated.");
        }
        else
        {
            Debug.LogError("Enemy reference or enemy health slider reference is missing.");
        }
    }

    private void EnablePlayerActionButtons()
    {
        foreach (Button button in playerActionButtons)
        {
            button.onClick.AddListener(() => OnPlayerActionButtonClicked(button));
            button.interactable = true;
        }
    }

    private void DisablePlayerActionButtons()
    {
        foreach (Button button in playerActionButtons)
        {
            button.interactable = false;
        }
    }

    private IEnumerator StartBattle()
    {
        while (currentState != TurnOrder.END)
        {
            switch (currentState)
            {
                case TurnOrder.START:
                    Debug.Log("Combat begins!");
                    currentState = TurnOrder.PLAYER_TURN;
                    break;
                case TurnOrder.PLAYER_TURN:
                    Debug.Log("Player's turn.");
                    yield return StartCoroutine(PlayerTurn());
                    currentState = TurnOrder.ENEMY_TURN;
                    break;
                case TurnOrder.ENEMY_TURN:
                    Debug.Log("Enemy's turn.");
                    yield return StartCoroutine(EnemyTurn());
                    currentState = TurnOrder.PLAYER_TURN;
                    break;
                case TurnOrder.END:
                    Debug.Log("Combat ends!");
                    // Add logic for ending the combat
                    break;
            }
        }
    }

    private void OnPlayerActionButtonClicked(Button clickedButton)
    {
        if (!playerActionTaken)
        {
            playerActionTaken = true;

            DisablePlayerActionButtons(); // Disable all action buttons

            // Determine which button was clicked and execute corresponding logic
            if (clickedButton == playerActionButtons[0])
            {
                int damage = player.useAttack();
                Debug.Log("Player selected action 1.");
                enemy.TakeDamage(damage);
            }
            else if (clickedButton == playerActionButtons[1])
            {
                int damage = player.useSkill1();
                Debug.Log("Player selected action 2.");
                enemy.TakeDamage(damage);
            }
            else if (clickedButton == playerActionButtons[2])
            {
                int damage = player.useSkill2();
                Debug.Log("Player selected action 3.");
                enemy.TakeDamage(damage);
            }
            else if (clickedButton == playerActionButtons[3])
            {
                int damage = player.useSkill3();
                Debug.Log("Player selected action 4.");
                enemy.TakeDamage(damage);
            }
            else if (clickedButton == playerActionButtons[4])
            {
                int damage = player.useSkill4();
                Debug.Log("Player selected action 5.");
                enemy.TakeDamage(damage);
            }

            // Proceed to the enemy's turn after player action
            StartCoroutine(EndPlayerTurn());
        }
    }

    private IEnumerator EndPlayerTurn()
    {
        yield return new WaitForSeconds(1f); // Simulated delay before transitioning to enemy's turn
        currentState = TurnOrder.ENEMY_TURN;
    }

    private IEnumerator PlayerTurn()
    {
        EnablePlayerActionButtons(); // Enable player action buttons
        Debug.Log("Player's turn.");

        // Reset the flag for the next player turn
        playerActionTaken = false;

        // Wait for player action
        while (!playerActionTaken)
        {
            // Wait for the next frame
            yield return null;
        }

        // Update the enemy's health slider
        UpdateEnemyHealthSlider(enemy, enemyHealthSlider, enemy.nonPlayerCurrentHealthPoints, enemy.nonPlayerHealthPoints);
        
          // Check if the enemy's health points are zero
        if (enemy.nonPlayerCurrentHealthPoints <= 0)
        {
            EndBattle(true); // Player wins
            yield break; // Exit the coroutine
        }
    }

    private IEnumerator EnemyTurn()
    {
        Debug.Log("Enemy's turn.");
        player.TakeDamage(enemy.nonPlayerDamage);
        Debug.Log("Enemy attacks!");
        UpdateHealthSlider(playerHealthSlider, player.getPlayerCurrentHealthPoints(), player.getPlayerHealthPoints());
        UpdateManaSlider(playerManaSlider, player.getPlayerCurrentManaPoints(), player.getPlayerManaPoints());

        yield return new WaitForSeconds(1f); // Simulated delay before transitioning to player's turn

        // Check if the player's health points are zero
        if (player.getPlayerCurrentHealthPoints() <= 0)
        {
            EndBattle(false); // Player loses
            yield break; // Exit the coroutine
        }

        Debug.Log("End of enemy's turn.");
    }

    private void EndBattle(bool playerWins)
    {
        currentState = TurnOrder.END;
        Debug.Log(playerWins ? "Player wins!" : "Player loses!");

        // Add logic for ending the battle based on the result
        if (playerWins)
        {
            // Player wins - handle the victory scenario
            Debug.Log("Victory!");
            DestroyEnemyIfDead();
            ChangeToVictoryScene();
        }
        else
        {
            // Player loses - handle the defeat scenario
            Debug.Log("Defeat!");
            ReturnToPreviousMenu();
        }
    }

    private void ChangeToVictoryScene()
    {
        SceneManager.LoadScene("Gameplay"); // Load the victory scene
    }

  private void ReturnToPreviousMenu()
    {
        // Find all objects with the "Enemy" tag and destroy them
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        // Find all objects with the "Player" tag and destroy them
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            Destroy(player);
        }

        // Load the previous menu scene
        SceneManager.LoadScene("classChoice");
    }

    private void DestroyEnemyIfDead()
    {
        if (enemy != null && enemy.nonPlayerCurrentHealthPoints <= 0)
        {
            Debug.Log("Destroying enemy with zero health points.");
            Destroy(enemy.gameObject); // Destroy the enemy game object
        }
    }
}
