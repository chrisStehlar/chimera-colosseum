using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HpBar : MonoBehaviour
{
    public float maxHp;
    public float currentHp;

    [SerializeField]
    private Image hpBar;

    // Will hold the monster that is associated with this HP value 
    [SerializeField]
    private Monster trackedMonster;

    

    /// <summary>
    /// Modify the HP based on the amount of damage the monster took, updating current HP to match
    /// </summary>
    /// <param name="damageAmount">The damage to take</param>
    public void TakeDamage(float damageAmount) {

        currentHp -= damageAmount;
        
        if(currentHp < 0) { 
            currentHp = 0;
        }

        if (currentHp > maxHp) {
            currentHp = maxHp;
        }
    }


    /// <summary>
    /// Setter for the trackedMonster variable, meant to be called by the HpBarManager
    /// </summary>
    /// <param name="newMonster">Monster to be set for this HP bar.</param>
    public void SetMonster(Monster newMonster)
    {
        trackedMonster = newMonster;

        // Update the maxHP and CurrentHP to reflect the monster's health
        // Assuming this is being called at the start of the scene, so maxHp currentHp will start as the same value
        maxHp = trackedMonster.getHP();
        currentHp = trackedMonster.getHP();
    }


    private void Update()
    {
        // TakeDamage was only being called here for testing, removing that
        //TakeDamage(Random.RandomRange(0,10)*Time.deltaTime);

        // Check to make sure the below ONLY runs if the monster exists 
        if (trackedMonster != null)
        {
            // Check if the monster's HP has changed, and if it has, call take damage based on the amount
            if (trackedMonster.getHP() < currentHp)
            {
                TakeDamage(currentHp - trackedMonster.getHP());
            }
        }

        hpBar.rectTransform.localScale = new Vector3(currentHp/maxHp, hpBar.rectTransform.localScale.y, hpBar.rectTransform.localScale.z);
    }
}
