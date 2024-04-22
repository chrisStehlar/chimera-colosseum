using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMenuManager : MonoBehaviour
{
    [SerializeField]
    private float Hp;

    public Monster leftMonster;
    public Monster rightMonster;

    private void Start()
    {
        FindObjectOfType<GameManager>().SpawnCreature();
    }
}
