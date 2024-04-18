using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LabUIManager : MonoBehaviour
{
    [SerializeField]
    StatsUIManager statsUIManager;

    public void OnStartClicked() {
        SceneManager.LoadScene("BattleScene");
    }

    
}
