using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRange = 3f;

    private void Update()
    {
        // Check for player input to initiate combat when near an enemy
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Find all GameObjects with the "Enemy" tag
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            
            // Loop through each enemy to check for interaction
            foreach (GameObject enemy in enemies)
            {
                // Calculate distance between player and enemy
                float distance = Vector3.Distance(transform.position, enemy.transform.position);

                // Check if the enemy is within interaction range
                if (distance <= interactionRange)
                {
                    // Store the active enemy's enemyID in PlayerPrefs
                    PlayerPrefs.SetInt("ActiveEnemyID", enemy.GetComponent<NonPlayer>().enemyID);
                    
                    // Store the player's selected class in PlayerPrefs
                    string selectedClass = PlayerPrefs.GetString("SelectedClass");
                    PlayerPrefs.SetString("SelectedClass", selectedClass);

                    // Load combat scene
                    SceneManager.LoadScene("Combat");
                }
            }
        }
    }
}
