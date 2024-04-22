using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour
{
    // FIELDS

    private Core corePart;

    private float speed = 0;
    private float damage = 0;
    public float health = 100f;

    public GameObject Head;
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject leftLeg;
    public GameObject rightLeg;
    public GameObject core;
    // MONO

    // Start is called before the first frame update
    void Start()
    {
        corePart = GetComponentInChildren<Core>();
        if(corePart.transform.childCount > 0)
            SetStats();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 moveDir = worldPosition - this.transform.position ;
        //this.transform.Translate(moveDir.normalized * speed * Time.deltaTime);
        CheckHp();
    }

    // METHODS

    public void CheckHp() {

        //if any monster run out of hp, set the scene to end scene
        if (health <= 0)
        {
            SceneManager.LoadScene("EndScene");
        }

    }

    public void SetStats()
    {
        SetSpeed();
        SetDamage();
    }

    // loop through all parts and collate their total speed
    private void SetSpeed()
    {
        speed = 0;

        Part[] parts = corePart.GetComponentsInChildren<Part>();
        foreach( Part part in parts)
        {
            speed += part.speed;
        }
    }

    // loop through all parts and collate their total damage
    private void SetDamage()
    {
        damage = 0;

        Part[] parts = corePart.GetComponentsInChildren<Part>();
        foreach ( Part part in parts )
        {
            damage += part.damage;
        }
    }


    public float getDamage()
    {
        return damage;
    }

    public float getSpeed()
    {
        return speed;
    }

    public float getHP()
    {
        return health;
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            // End the fight
        }
    }
}
