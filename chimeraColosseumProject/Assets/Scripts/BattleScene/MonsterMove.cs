using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    float knockbackScaler = 20f;

    Vector2 direction;
    Vector2 knockbackVelocity;
    float friction = 0.975f;

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
        direction = target.position - this.GetComponent<Transform>().position;

        if (knockbackVelocity.magnitude <= 0.1f)
        {
            this.GetComponent<Transform>().Translate(direction.normalized * speed * Time.deltaTime);
        }
        else
        {
            this.GetComponent<Transform>().Translate(knockbackVelocity * Time.deltaTime);
        }
        knockbackVelocity *= friction;
    }

    /// <summary>
    /// Knocks this monster back based on damage
    /// </summary>
    /// <param name="damage">The damage it is taking</param>
    public void Knockback(float damage)
    {
       knockbackVelocity = (-1 * direction.normalized * damage * knockbackScaler);
    }
}
