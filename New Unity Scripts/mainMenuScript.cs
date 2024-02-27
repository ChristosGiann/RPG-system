using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("classChoice");
    }

    // Method to quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
