using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    // FIELDS

    public float spawnCooldown;
    private float lastSpawnTime;

    // added in the inspector for which parts can come from this spawner
    public Part[] allCores;
    public Part[] allHeads;
    public Part[] allArms;
    public Part[] allLegs;

    // MONO

    // Update is called once per frame
    void Update()
    {
        // DEV - moving the spawner to the right to spread them out
        this.transform.Translate(Vector2.right * .25f * Time.deltaTime);

        // every "spawnCooldown" interval triggers this
        if(Time.time > lastSpawnTime + spawnCooldown)
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

        // instantiate the core
        Core randomCore = (Core)allCores[Random.Range(0, allCores.Length)];
        GameObject coreObj = Instantiate(randomCore.gameObject, monster.transform);

        // instantiate body parts and put them in the right spot

        // head
        for(int i = 0; i < randomCore.headJoints.Length; i++)
        {
            // make a head
            Part head = allHeads[Random.Range(0, allHeads.Length)];
            // position it
            Instantiate(head.gameObject, coreObj.transform.position + randomCore.headJoints[i], Quaternion.identity, coreObj.transform);
        }

        // legs
        for(int i = 0; i < randomCore.legJoints.Length; i++)
        {
            // make a leg
            Part leg = allLegs[Random.Range(0, allLegs.Length)];
            // position it
            Instantiate(leg.gameObject, coreObj.transform.position + randomCore.legJoints[i], Quaternion.identity, coreObj.transform);
        }

        // arms
        for(int i = 0; i < randomCore.armJoints.Length; i++)
        {
            // make an arm
            Part arm = allArms[Random.Range(0, allArms.Length)];
            // position it
            Instantiate(arm.gameObject, coreObj.transform.position + randomCore.armJoints[i], Quaternion.identity, coreObj.transform);
        }
    }

}
