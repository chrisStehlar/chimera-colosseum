using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropSlot : MonoBehaviour, IDropHandler
{
    private Image slotImage; 

    void Start()
    {
        // Get the Image component of the slot
        slotImage = GetComponent<Image>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null) // Check if there is an object being dragged
        {
            Image draggedImage = eventData.pointerDrag.GetComponent<Image>();
            if (draggedImage != null)
            {
                // Set the slot's image to the dragged image
                slotImage.sprite = draggedImage.sprite;
                slotImage.color = draggedImage.color;
                slotImage.material = draggedImage.material;
                slotImage.type = draggedImage.type;

                // Optionally, snap the dragged object to the slot's position
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            }
        }
    }
}
