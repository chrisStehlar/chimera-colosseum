using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndSceneUIManager : MonoBehaviour
{
    public void OnCreditClicked()
    {
        SceneManager.LoadScene("Credits");
    }

    public void OnMainClicked() 
    {
        SceneManager.LoadScene("MainMenu");
    }
}
