using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StatsUIManager : MonoBehaviour
{
    public static StatsUIManager instance;

    private void Awake()
    {
        if (instance == null) { 
            instance = this;
        }
    }

    string name;
    [SerializeField] TMP_Text nameText;
    string type;
    [SerializeField] TMP_Text typeText;
    float health;
    [SerializeField] TMP_Text healthText;
    float attack;
    [SerializeField] TMP_Text attackText;
    float attackSpeed;
    [SerializeField] TMP_Text attackSpeedText;

    public void UpdateUI()
    {
        string nameString = ("Name: " + name);
        nameText.text = nameString.Substring(0, nameString.Length-7).Replace("_", " ");
        typeText.text = "Type: " + type;
        healthText.text = "Health: " + health;
        attackText.text = "Attack: " + attack;
        attackSpeedText.text = "Attack Speed: " + attackSpeed;
    }

    public void UpdateDisplayInfo(string name, string type, float atk, float atkSpd, float health)
    {
        this.name = name;
        this.type = type;
        this.attack = atk;
        this.attackSpeed = atkSpd;
        this.health = health;
        UpdateUI();
    }
}
