using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public void LoadCreatureLab() {
        SceneManager.LoadScene("CreatureLab");
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadSettings() {
        //SceneManager.LoadScene("Settings");
        Debug.Log("No settings implemented");
    }

    public void LoadCredits() {
        SceneManager.LoadScene("Credits");
    }

    public void ExitGame() {
        Application.Quit();
    }
}
