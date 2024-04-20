using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
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

    public void OnStartClicked()
    {
        GameManager.instance.leg = Instantiate(MonsterSpawner.allLegs[0].gameObject);
        GameManager.instance.arm = Instantiate(MonsterSpawner.allArms[0].gameObject);
        GameManager.instance.head = Instantiate(MonsterSpawner.allHeads[0].gameObject);
        GameManager.instance.torso = Instantiate(MonsterSpawner.allCores[0].gameObject);
        DontDestroyOnLoad(GameManager.instance.leg);
        DontDestroyOnLoad(GameManager.instance.arm);
        DontDestroyOnLoad(GameManager.instance.head);
        DontDestroyOnLoad(GameManager.instance.torso);
        SceneManager.LoadScene("BattleScene");
    }

    
}
