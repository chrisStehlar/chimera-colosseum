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
        monsterSpawner.spawnWithAI = true;
        // This isn't clean code in the slightest, but to prevent having to change what parts 
        // the GameManager is being given by the creature lab, grabbing the object's PartHandler script 
        // can get you a reference to the proper part object
        monsterSpawner.SetArm(arm.GetComponent<PartHandler>().part.GetComponent<Part>());
        monsterSpawner.SetLeg(leg.GetComponent<PartHandler>().part.GetComponent<Part>());
        monsterSpawner.SetHead(head.GetComponent<PartHandler>().part.GetComponent<Part>());
        monsterSpawner.SetCore(torso.GetComponent<PartHandler>().part.GetComponent<Part>());
        monsterSpawner.SpawnRandomMonster(new Vector2(-3, 0));
 
    }

}
