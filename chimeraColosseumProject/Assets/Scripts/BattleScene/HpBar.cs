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

    public void TakeDamage(float damageAmount) {

        currentHp -= damageAmount;
        if(currentHp < 0) { 
            currentHp = 0;
        }
    }


    private void Update()
    {
        hpBar.rectTransform.localScale = new Vector3(currentHp/maxHp, hpBar.rectTransform.localScale.y, hpBar.rectTransform.localScale.z);
    }
}
