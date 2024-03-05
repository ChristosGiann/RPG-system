using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

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

    private enum BattleState { START, PLAYER_TURN, ENEMY_TURN, END }
    private BattleState currentState;

    private void Start()
    {
        SpawnPlayer();
        SpawnActiveEnemy();
        EnablePlayerActionButtons();

        currentState = BattleState.START;
        StartCoroutine(BattleLoop());
    }

    private void SpawnPlayer()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            Debug.Log("Player found.");

            playerObject.transform.position = new Vector3(0f, 0f, 5f);

            player = playerObject.GetComponent<Player>();
            UpdateHealthSlider(playerHealthSlider, player.getPlayerHealthPoints());
            UpdateManaSlider(playerManaSlider, player.getPlayerManaPoints());
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
                UpdateEnemyHealthSlider(enemy);
                return; // Exit the method after finding the matching enemy
            }
        }

        Debug.LogError("No existing enemy found with ID: " + activeEnemyID);
    }


    private void UpdateHealthSlider(Slider slider, float healthPoints)
    {
        if (slider != null)
        {
            slider.value = healthPoints;
            Debug.Log("Health slider updated.");
        }
        else
        {
            Debug.LogError("Slider reference is missing.");
        }
    }

    private void UpdateManaSlider(Slider slider, float manaPoints)
    {
        if (slider != null)
        {
            slider.value = manaPoints;
            Debug.Log("Mana slider updated.");
        }
        else
        {
            Debug.LogError("Slider reference is missing.");
        }
    }

    private void UpdateEnemyHealthSlider(NonPlayer enemy)
    {
        if (enemy != null && enemyHealthSlider != null)
        {
            enemyHealthSlider.value = enemy.nonPlayerHealthPoints;
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

    private IEnumerator BattleLoop()
    {
        while (currentState != BattleState.END)
        {
            switch (currentState)
            {
                case BattleState.START:
                    Debug.Log("Combat begins!");
                    currentState = BattleState.PLAYER_TURN;
                    break;
                case BattleState.PLAYER_TURN:
                    Debug.Log("Player's turn.");
                    yield return StartCoroutine(PlayerTurn());
                    currentState = BattleState.ENEMY_TURN;
                    break;
                case BattleState.ENEMY_TURN:
                    Debug.Log("Enemy's turn.");
                    yield return StartCoroutine(EnemyTurn());
                    currentState = BattleState.PLAYER_TURN;
                    break;
                case BattleState.END:
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
        currentState = BattleState.ENEMY_TURN;
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

          // Check if the enemy's health points are zero
        if (enemy.nonPlayerHealthPoints <= 0)
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

        yield return new WaitForSeconds(1f); // Simulated delay before transitioning to player's turn

        // Check if the player's health points are zero
        if (player.getPlayerHealthPoints() <= 0)
        {
            EndBattle(false); // Player loses
            yield break; // Exit the coroutine
        }

        Debug.Log("End of enemy's turn.");
    }

    private void EndBattle(bool playerWins)
    {
        currentState = BattleState.END;
        Debug.Log(playerWins ? "Player wins!" : "Player loses!");

        // Add logic for ending the battle based on the result
        if (playerWins)
        {
            // Player wins - handle the victory scenario
            Debug.Log("Victory! Implement logic to reward the player, such as gaining experience points, looting items, etc.");
        }
        else
        {
            // Player loses - handle the defeat scenario
            Debug.Log("Defeat! Implement logic for what happens when the player loses, such as game over, returning to a checkpoint, etc.");
        }
    }

}
