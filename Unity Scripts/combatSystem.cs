using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Rpg;

public class TurnBasedCombat : MonoBehaviour
{
    public Warrior warrior;
    public Mage mage;
    public Rogue rogue;
    public NonPlayer enemyCharacter;
    public GameObject[] participants; // Participants in combat (e.g., player, enemies)
    int currentPlayerIndex = 0; // Index of the participant whose turn it is

    bool playerActionCompleted = false; // Flag to track if the player has completed their action
    public Transform playerTransform;
    public float combatDistance = 1f;
    public Button attackButton; // Reference to the attack button in the UI
    public Button skillButton1; // Reference to the skill button in the UI
    public Button skillButton2;
    public Button skillButton3;
    public Button skillButton4;
    public Button skipMovementButton;

    public float maxMoveDistance = 3f;
    public float moveDistance = 1.0f;

    bool skipMovementButtonClicked = false; // Flag to track if the skip movement button is clicked
    bool attackButtonClicked = false;
    private bool skillButtonClicked = false;
    bool skillButton1Clicked = false;
    bool skillButton2Clicked = false;
    bool skillButton3Clicked = false;
    bool skillButton4Clicked = false;

    private bool isCombatActive = false; // Flag to indicate if combat is active

    public bool IsCombatActive => isCombatActive;

    void Start()
    {
        // Assuming playerTransform is set to the reference of the player's transform
        if (playerTransform != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

            // Check if the player is within the combat distance
            if (distanceToPlayer <= combatDistance)
            {
                StartCombat();
            }
        }
        else
        {
            Debug.LogWarning("Player transform not set in the inspector.");
        }
    }

    IEnumerator StartCombat()
    {
        // Set combat active flag
        isCombatActive = true;
        // Instantiate the enemy character if it's not already assigned
        if (enemyCharacter == null)
        {
            // Instantiate and configure the enemy character
            enemyCharacter = new NonPlayer();
            enemyCharacter.nonPlayerHealthPoints = 20; // Set initial health points
            enemyCharacter.nonPlayerDamage = 2; // Set damage
        }

        while (!IsCombatOver())
        {
            GameObject currentPlayer = participants[currentPlayerIndex];
            if (currentPlayer.CompareTag("Player"))
            {
                // Player's turn
                yield return StartCoroutine(PlayerTurn(currentPlayer));
            }
            else
            {
                // Enemy's turn
                yield return StartCoroutine(EnemyTurn(currentPlayer));
            }
            // Move to the next participant
            currentPlayerIndex = (currentPlayerIndex + 1) % participants.Length;
            playerActionCompleted = false; // Reset player action flag

            // Set combat inactive flag after combat is over
            isCombatActive = false;
        }
    }

    bool IsCombatOver()
    {
        bool playerLoses = false;
        bool enemyLoses = false;

        // Check player's health based on the selected class
        switch (PlayerPrefs.GetString("SelectedClass"))
        {
            case "Warrior":
                if (warrior != null && warrior.getPlayerHealthPoints() <= 0)
                {
                    Debug.Log("Combat ended. Player loses as Warrior.");
                    playerLoses = true;
                }
                break;
            case "Mage":
                if (mage != null && mage.getPlayerHealthPoints() <= 0)
                {
                    Debug.Log("Combat ended. Player loses as Mage.");
                    playerLoses = true;
                }
                break;
            case "Rogue":
                if (rogue != null && rogue.getPlayerHealthPoints() <= 0)
                {
                    Debug.Log("Combat ended. Player loses as Rogue.");
                    playerLoses = true;
                }
                break;
            default:
                Debug.LogError("Invalid player class selected");
                break;
        }

        // Check if the enemy loses
        if (enemyCharacter != null && enemyCharacter.nonPlayerHealthPoints <= 0)
        {
            Debug.Log("Combat ended. Enemy loses.");
            enemyLoses = true;
        }

        // Return true if either player or enemy loses
        return playerLoses || enemyLoses;
    }

    IEnumerator PlayerTurn(GameObject player)
    {
        switch (PlayerPrefs.GetString("SelectedClass"))
        {
            case "Warrior":
                if (warrior != null)
                {
                    yield return StartCoroutine(WaitForAttackAndMove(player.GetComponent<Player>()));
                }
                break;
            case "Mage":
                if (mage != null)
                {
                    yield return StartCoroutine(WaitForAttackAndMove(player.GetComponent<Player>()));
                }
                break;
            case "Rogue":
                if (rogue != null)
                {
                    yield return StartCoroutine(WaitForAttackAndMove(player.GetComponent<Player>()));
                }
                break;
            default:
                Debug.LogError("Invalid player class selected");
                break;
        }

        playerActionCompleted = true;
    }

    IEnumerator WaitForAttackAndMove(Player player)
    {
        // This coroutine waits until the attack button, any skill button, or skip movement button is pressed
        while (!attackButtonClicked && !skillButton1Clicked && !skillButton2Clicked
            && !skillButton3Clicked && !skillButton4Clicked && !skipMovementButtonClicked)
        {
            yield return null;
        }

        // If the skip movement button is clicked, mark the movement as completed
        if (skipMovementButtonClicked)
        {
            Debug.Log("Player chose to skip movement.");
            skipMovementButtonClicked = false; // Reset the flag
            yield break; // Exit the coroutine early
        }

        // Wait for the player to move
        while (!PlayerMoved(player))
        {
            yield return null;
        }
    }

    bool PlayerMoved(Player player)
    {
        if (skipMovementButtonClicked)
        {
            // Player chose to skip movement
            return true;
        }

        // Set the target position to the point where the ray hits
        Vector3 targetPosition = Vector3.zero;
        if (Input.GetMouseButtonDown(1))
        {
            // Cast a ray from the mouse position into the scene
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits something
            if (Physics.Raycast(ray, out hit))
            {
                // Set the target position to the point where the ray hits
                targetPosition = hit.point;
            }
        }

        // Calculate the new position after movement
        Vector3 newPosition = player.transform.position + (targetPosition - player.transform.position).normalized * moveDistance;

        // Check if the new position is within the allowed movement range
        if (Vector3.Distance(player.transform.position, newPosition) <= maxMoveDistance)
        {
            // Move the player
            player.transform.position = newPosition;
            return true; // Player moved successfully
        }

        // Player cannot move beyond the allowed distance
        return false;
    }

    void SkipMovement()
    {
        // Call this method when the skip movement button is clicked
        skipMovementButtonClicked = true;
    }

    void PerformAttack()
    {
        attackButtonClicked = true; // Set flag to indicate attack button is clicked
        switch (PlayerPrefs.GetString("SelectedClass"))
        {
            case "Warrior":
                warrior.useAttack();
                break;
            case "Mage":
                mage.useAttack();
                break;
            case "Rogue":
                rogue.useAttack();
                break;
            default:
                Debug.LogError("Invalid player class selected");
                break;
        }
    }

    void PerformSkill(int skillButtonIndex)
    {
        // Check the selected class and call the corresponding skill method
        switch (PlayerPrefs.GetString("SelectedClass"))
        {
            case "Warrior":
                // Warrior class selected
                PerformWarriorSkill(skillButtonIndex);
                break;
            case "Mage":
                // Mage class selected
                PerformMageSkill(skillButtonIndex);
                break;
            case "Rogue":
                // Rogue class selected
                PerformRogueSkill(skillButtonIndex);
                break;
            default:
                Debug.LogError("Invalid player class selected");
                break;
        }
    }

    void PerformWarriorSkill(int skillButtonIndex)
    {
        // Set the corresponding skill button flag to true based on the index
        switch (skillButtonIndex)
        {
            case 1:
                skillButtonClicked = true;
                warrior.useSkill1();
                break;
            case 2:
                skillButtonClicked = true;
                warrior.useSkill2();
                break;
            case 3:
                skillButtonClicked = true;
                warrior.useSkill3();
                break;
            case 4:
                skillButtonClicked = true;
                warrior.useSkill4();
                break;
            default:
                Debug.LogError("Invalid skill button index");
                break;
        }
    }

    void PerformMageSkill(int skillButtonIndex)
    {
        // Set the corresponding skill button flag to true based on the index
        switch (skillButtonIndex)
        {
            case 1:
                skillButtonClicked = true;
                mage.useSkill1();
                break;
            case 2:
                skillButtonClicked = true;
                mage.useSkill2();
                break;
            case 3:
                skillButtonClicked = true;
                mage.useSkill3();
                break;
            case 4:
                skillButtonClicked = true;
                mage.useSkill4();
                break;
            default:
                Debug.LogError("Invalid skill button index");
                break;
        }
    }

    void PerformRogueSkill(int skillButtonIndex)
    {
        // Set the corresponding skill button flag to true based on the index
        switch (skillButtonIndex)
        {
            case 1:
                skillButtonClicked = true;
                rogue.useSkill1();
                break;
            case 2:
                skillButtonClicked = true;
                rogue.useSkill2();
                break;
            case 3:
                skillButtonClicked = true;
                rogue.useSkill3();
                break;
            case 4:
                skillButtonClicked = true;
                rogue.useSkill4();
                break;
            default:
                Debug.LogError("Invalid skill button index");
                break;
        }
    }

    IEnumerator EnemyTurn(GameObject enemy)
    {
        Debug.Log("Enemy's turn.");
        if (Vector3.Distance(enemy.transform.position, GetNearestPlayerPosition()) > 1.5f)
        {
            // Move towards the nearest player within a certain distance
            // Implement logic for enemy movement here
            Debug.Log("Enemy moves towards the player.");
        }
        else
        {
            // Attack if the player is within melee range
            // Implement logic for enemy attack here
            Debug.Log("Enemy attacks.");
        }

        // Simulate action resolution time
        yield return new WaitForSeconds(1f);
    }

    Vector3 GetNearestPlayerPosition()
    {
        GameObject nearestPlayer = null;
        float minDistance = float.MaxValue;
        foreach (GameObject participant in participants)
        {
            if (participant.CompareTag("Player"))
            {
                float distance = Vector3.Distance(participant.transform.position, transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestPlayer = participant;
                }
            }
        }
        return nearestPlayer.transform.position;
    }
}
