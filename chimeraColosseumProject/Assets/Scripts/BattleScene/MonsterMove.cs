using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    float knockbackScaler = 2.5f;

    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Moves the monster towards the enemy based on its speed
    /// </summary>
    /// <param name="target">The enemy Transform</param>
    /// <param name="speed">This monster's speed stat</param>
    public void Move(Transform target, float speed)
    {
        Vector3 direction = target.position - this.GetComponent<Transform>().position;

        this.GetComponent<Transform>().Translate(direction.normalized * speed * Time.deltaTime);
    }

    /// <summary>
    /// Knocks this monster back based on damage
    /// </summary>
    /// <param name="damage">The damage it is taking</param>
    public void Knockback(float damage)
    {
        this.GetComponent<Transform>().Translate(-1 * direction.normalized * damage * knockbackScaler);
        print("knocked back");
    }
}
