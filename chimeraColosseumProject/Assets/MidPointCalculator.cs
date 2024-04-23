using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidPointCalculator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Monster[] monsters = Resources.FindObjectsOfTypeAll<Monster>();
        transform.position = (monsters[0].transform.position + monsters[1].transform.position)/2;
    }
}
