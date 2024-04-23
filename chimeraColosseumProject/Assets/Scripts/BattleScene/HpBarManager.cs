using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarManager : MonoBehaviour
{
    // Two HP bars used to 
    [SerializeField]
    private HpBar firstHpBar;
    [SerializeField]
    private HpBar secondHpBar;

    // Array to hold monsters that have been given to the HP bars.
    // Intent is to only have there be two of them in a scene, for simplicity
    public Monster[] monsters;


    /// <summary>
    /// Will populate the HpBar objects that this manager has with the two Monster objects in the scene
    /// </summary>
    void populateHpBars()
    {
        monsters = Resources.FindObjectsOfTypeAll<Monster>();

        if (monsters.Length > 1)
        {
            // Assumed to have two entries, populate the HPBars 
            firstHpBar.SetMonster(monsters[0]);
            secondHpBar.SetMonster(monsters[1]);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Attempt to find the monsters in the scene first.  
        // IF THIS DOESN'T GRAB THEM then populate this inside of update
        // As I'm not sure if the order of operations of when the monsters get spawned will work out here
        //populateHpBars();

        monsters = new Monster[0];
    }

    // Update is called once per frame
    void Update()
    {
        // Only want to check for populating the HP bars if they've not already been populated
        if(monsters.Length < 2)
        {
            populateHpBars();
        }
    }
}
