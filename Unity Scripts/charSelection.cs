using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public void ChooseWarrior()
    {
        Debug.Log("Warrior selected");
        PlayerPrefs.SetString("SelectedClass", "Warrior");
        SceneManager.LoadScene("Gameplay");
    }


    public void ChooseMage()
    {
        Debug.Log("Mage selected");
        PlayerPrefs.SetString("SelectedClass", "Mage");
        SceneManager.LoadScene("Gameplay");
    }

    public void ChooseRogue()
    {
        Debug.Log("Rogue selected");
        PlayerPrefs.SetString("SelectedClass", "Rogue");
        SceneManager.LoadScene("Gameplay");
    }
}
