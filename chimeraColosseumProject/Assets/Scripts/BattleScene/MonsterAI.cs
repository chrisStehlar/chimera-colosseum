using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    // Grab the monster script off this object to be able to get the stats from it 
    [SerializeField]
    private Monster thisMonster;
    [SerializeField]
    private Monster targetMonster;
    [SerializeField]
    private Transform targetTransform;

    private MonsterMove moveScript;
    private MonsterAttack attackScript;


    // Start is called before the first frame update
    void Start()
    {
        // The below code assumes that the monster objects will exist in the scene 

        // Get the initial monster information 
        thisMonster = this.GetComponent<Monster>();
        moveScript = this.GetComponent<MonsterMove>();
        attackScript = this.GetComponent<MonsterAttack>();

        // Look for the other object in the scene with a monster script 
        var monsters = Resources.FindObjectsOfTypeAll<Monster>();

        var objects = Resources.FindObjectsOfTypeAll<GameObject>();

        foreach(GameObject o in objects)
        {
            if(o.GetComponent<Monster>() != null)
            {
                // Means that you've found a monster, check if it is the current one
                // If it isn't you have the object you need
                if(o.GetComponent<Monster>() != thisMonster)
                {
                    targetMonster = o.GetComponent<Monster>();
                    targetTransform = o.transform;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ONLY do movement and attack behavior if there is a target in the scene 
        if (targetMonster != null)
        {
            // Moves the monster towards the enemy monster by its speed
            moveScript.Move(targetTransform, thisMonster.getSpeed());
            // Checks if the monster is in range and off attack cooldown
            // Then, gives the enemy monster knockback and makes it lose health
            if (attackScript.CanAttack(targetTransform))
            {
                targetMonster.GetComponent<MonsterMove>().Knockback(thisMonster.getDamage());
                targetMonster.takeDamage(thisMonster.getDamage());
            }
        }
    }

    /**
     * What I need to do for this
     * 1. Determine the monster initial information about the current monster, gotten from Monster.cs
     * 2. Make the monsters check for other monsters in the scene.
     *      Best bet is basing it on checking for GameObjects in the scene that have a monster.cs script component 
     *      That script has a sum of the monster stats, just grab those components.
     * 3. Monsters need to move towards their target (the other monster) based on their speed stat
     * 4. Monster needs to check if it is reasonably close to the other monster, to see if it is in range for a melee attack
     * 5. If the monster is in range, check if it can attack (there will be a cooldown based on attack speed)
     * 6. If the monster can attack, damage the other monster and knock them back (a distance possibly scaled by attack)
     * 7. Make sure monsters can't move into one another.
     *      
     */
}
