using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject head;
    public GameObject torso;
    public GameObject arm;
    public GameObject leg;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SpawnCreature()
    {
        MonsterSpawner monsterSpawner = new MonsterSpawner();
        monsterSpawner.SetArm(arm.GetComponent<Part>());
        monsterSpawner.SetLeg(leg.GetComponent<Part>());
        monsterSpawner.SetHead(head.GetComponent<Part>());
        monsterSpawner.SetCore(torso.GetComponent<Part>());
        monsterSpawner.SpawnLabMonster();
    }

}
