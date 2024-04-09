using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // FIELDS

    private Core corePart;

    private float speed = 0;
    private float damage = 0;
    public float health = 100f;

    GameObject Head;
    GameObject leftHand;
    GameObject rightHand;
    GameObject leftLeg;
    GameObject rightLeg;
    GameObject core;
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
        this.transform.Translate(moveDir.normalized * speed * Time.deltaTime);
    }

    // METHODS

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
}
