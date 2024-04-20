using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LabUIManager : MonoBehaviour
{
    [SerializeField]
    StatsUIManager statsUIManager;
    [SerializeField]
    public MonsterSpawner MonsterSpawner;

    public static LabUIManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) { 
            Instance = this;
        }
    }

    private void Start()
    {
        MonsterSpawner.SpawnLabMonster();
    }

    public void OnStartClicked() {
        SceneManager.LoadScene("BattleScene");
    }

    
}
