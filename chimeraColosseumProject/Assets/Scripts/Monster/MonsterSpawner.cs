using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MonsterSpawner : MonoBehaviour
{
    // FIELDS

    public float spawnCooldown;
    private float lastSpawnTime;

    // Spawn the monsters in the scene whenever the spawn cooldown is done
    public Boolean spawnContinuously;

    // added in the inspector for which parts can come from this spawner
    public Part[] allCores;
    public Part[] allHeads;
    public Part[] allArms;
    public Part[] allLegs;

    // MONO

    private void Start()
    {
        SpawnRandomMonster(new Vector2(-3, 2));
        SpawnRandomMonster(new Vector2(3, 1));
    }

    // Update is called once per frame
    void Update()
    {
        // DEV - moving the spawner to the right to spread them out
        this.transform.Translate(Vector2.right * .25f * Time.deltaTime);

        // every "spawnCooldown" interval triggers this
        if(Time.time > lastSpawnTime + spawnCooldown && spawnContinuously)
        {
            lastSpawnTime = Time.time;
            SpawnRandomMonster(this.transform.position);
        }
    }

    // METHODS

    public void SpawnRandomMonster(Vector2 where)
    {
        // make the empty monster game object
        GameObject monster = new GameObject("Monster");
        monster.transform.position = where;
        monster.AddComponent<Monster>();
        monster.AddComponent<MonsterAI>();
        monster.AddComponent<MonsterMove>();
        monster.AddComponent<MonsterAttack>();

        // instantiate the core
        Core randomCore = (Core)allCores[UnityEngine.Random.Range(0, allCores.Length)];
        GameObject coreObj = Instantiate(randomCore.gameObject, monster.transform);

        // instantiate body parts and put them in the right spot

        // head
        for(int i = 0; i < randomCore.headJoints.Length; i++)
        {
            // make a head
            Part head = allHeads[UnityEngine.Random.Range(0, allHeads.Length)];
            // position it
            Instantiate(head.gameObject, coreObj.transform.position + randomCore.headJoints[i], Quaternion.identity, coreObj.transform);
        }

        // legs
        for(int i = 0; i < randomCore.legJoints.Length; i++)
        {
            // make a leg
            Part leg = allLegs[UnityEngine.Random.Range(0, allLegs.Length)];
            // position it
            Instantiate(leg.gameObject, coreObj.transform.position + randomCore.legJoints[i], Quaternion.identity, coreObj.transform);
        }

        // arms
        for(int i = 0; i < randomCore.armJoints.Length; i++)
        {
            // make an arm
            Part arm = allArms[UnityEngine.Random.Range(0, allArms.Length)];
            // position it
            Instantiate(arm.gameObject, coreObj.transform.position + randomCore.armJoints[i], Quaternion.identity, coreObj.transform);
        }

        // Adding this for testing for monster AI
        monster.AddComponent<MonsterAI>();
    }

    public void SpawnLabMonster() {
        if (GameObject.FindWithTag("Monster") != null) { 
            Destroy(GameObject.FindWithTag("Monster"));
        }
        // make the empty monster game object
        GameObject monster = new GameObject("Monster");
        monster.tag = "Monster";
        monster.transform.position = new Vector3(0,0,0);
        monster.AddComponent<Monster>();

        // instantiate the core
        Core randomCore = (Core)allCores[UnityEngine.Random.Range(0, allCores.Length)];
        GameObject coreObj = Instantiate(randomCore.GetComponent<PartHandler>().part, monster.transform);

        // instantiate body parts and put them in the right spot
        Core core = randomCore.GetComponent<PartHandler>().part.GetComponent<Core>();
        // head
        for (int i = 0; i < core.headJoints.Length; i++)
        {
            // make a head
            Part head = allHeads[UnityEngine.Random.Range(0, allHeads.Length)];
            // position it
            Instantiate(head.GetComponent<PartHandler>().part, coreObj.transform.position + core.headJoints[i], Quaternion.identity, coreObj.transform);
        }

        // legs
        for (int i = 0; i < core.legJoints.Length; i++)
        {
            // make a leg
            Part leg = allLegs[UnityEngine.Random.Range(0, allLegs.Length)];
            // position it
            Instantiate(leg.GetComponent<PartHandler>().part, coreObj.transform.position + core.legJoints[i], Quaternion.identity, coreObj.transform);
        }

        // arms
        for (int i = 0; i < core.armJoints.Length; i++)
        {
            // make an arm
            Part arm = allArms[UnityEngine.Random.Range(0, allArms.Length)];
            // position it
            Instantiate(arm.GetComponent<PartHandler>().part, coreObj.transform.position + core.armJoints[i], Quaternion.identity, coreObj.transform);
        }

        monster.transform.localScale = new Vector3(10, 10, 1);
    }

    public void SetCore(Part core) 
    {
        allCores = new Part[] { core };
    }

    public void SetHead(Part head)
    {
        allHeads = new Part[] { head };
    }

    public void SetArm(Part arm)
    {
        allArms = new Part[] { arm };
    }

    public void SetLeg(Part leg)
    {
        allLegs = new Part[] { leg };
    }
}
