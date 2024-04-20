using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    [SerializeField]
    float attackRange;
    [SerializeField]
    float cooldownBase;
    float currentCooldownTimer;

    // Start is called before the first frame update
    void Start()
    {
        currentCooldownTimer = cooldownBase;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Checks if the monster is able to attack. Returns true if it can
    /// </summary>
    /// <param name="target">The enemy monster transform</param>
    /// <returns>True if the monster is able to attack</returns>
    public bool CanAttack(Transform target)
    {
        currentCooldownTimer -= Time.deltaTime;
        float distance = Vector3.Distance(target.position, this.GetComponent<Transform>().position);
        if (distance < attackRange && currentCooldownTimer <= 0)
        {
            currentCooldownTimer = cooldownBase;
            return true;
        }
        return false;
    }
}
