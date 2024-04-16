using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LabUIManager : MonoBehaviour
{
    public void OnStartClicked() {
        SceneManager.LoadScene("BattleScene");
    }
}
