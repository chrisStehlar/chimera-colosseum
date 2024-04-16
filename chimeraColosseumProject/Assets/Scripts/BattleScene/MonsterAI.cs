using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * What I need to do for this
     * 1. Determine the monster initial information about the current monster 
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
