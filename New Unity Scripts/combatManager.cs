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
        int activeEnemyID = PlayerPrefs.GetInt("ActiveEnemyID", -1);

        if (activeEnemyID >= 0 && activeEnemyID < enemyPrefabs.Length)
        {
            GameObject enemyPrefab = enemyPrefabs[activeEnemyID];

            if (enemyPrefab != null)
            {
                GameObject enemyObject = Instantiate(enemyPrefab, new Vector3(5f, 0f, 5f), Quaternion.identity);
                Debug.Log("New enemy spawned.");

                enemy = enemyObject.GetComponent<NonPlayer>();

                UpdateEnemyHealthSlider(enemy);
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
                Debug.Log("Player selected action 1.");
            }
            else if (clickedButton == playerActionButtons[1])
            {
                Debug.Log("Player selected action 2.");
            }
            else if (clickedButton == playerActionButtons[2])
            {
                Debug.Log("Player selected action 3.");
            }
            else if (clickedButton == playerActionButtons[3])
            {
                Debug.Log("Player selected action 4.");
            }
            else if (clickedButton == playerActionButtons[4])
            {
                Debug.Log("Player selected action 5.");
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
    }

    private IEnumerator EnemyTurn()
    {
        Debug.Log("Enemy's turn.");
        //enemy.useAttack();
        Debug.Log("Enemy attacks!");

        yield return new WaitForSeconds(1f); // Simulated delay before transitioning to player's turn
        Debug.Log("End of enemy's turn.");
    }

    private void EndBattle(bool playerWins)
    {
        currentState = BattleState.END;
        Debug.Log(playerWins ? "Player wins!" : "Player loses!");
        // Add logic for ending the battle based on the result
    }
}
