using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if (GetComponent<Core>() != null)
        {
            StatsUIManager.instance.UpdateDisplayInfo(gameObject.name, gameObject.tag, GetComponent<Core>().damage, GetComponent<Core>().speed, 0);
        }
        else
        {
            StatsUIManager.instance.UpdateDisplayInfo(gameObject.name, gameObject.tag, GetComponent<Part>().damage, GetComponent<Part>().speed, 0);
        }
    }
}
