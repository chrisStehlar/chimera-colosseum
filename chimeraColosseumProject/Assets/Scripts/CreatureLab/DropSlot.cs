using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropSlot : MonoBehaviour, IDropHandler
{
    private Image slotImage;
    public string slotType;
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
            if (draggedImage != null && draggedImage.gameObject.tag == this.gameObject.tag)
            {
                // Set the slot's image to the dragged image
                slotImage.sprite = draggedImage.sprite;
                slotImage.color = draggedImage.color;
                slotImage.material = draggedImage.material;
                slotImage.type = draggedImage.type;

                //snap the dragged object to the slot's position
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

                //update the part on the monster
                switch (draggedImage.gameObject.tag) {
                    case "Arm":
                        LabUIManager.Instance.MonsterSpawner.SetArm(eventData.pointerDrag.GetComponent<Part>());
                        break;
                    case "Leg":
                        LabUIManager.Instance.MonsterSpawner.SetLeg(eventData.pointerDrag.GetComponent<Part>());
                        break;
                    case "Torso":
                        LabUIManager.Instance.MonsterSpawner.SetCore(eventData.pointerDrag.GetComponent<Core>());
                        break;
                    case "Head":
                        LabUIManager.Instance.MonsterSpawner.SetHead(eventData.pointerDrag.GetComponent<Part>());
                        break;
                }
                LabUIManager.Instance.MonsterSpawner.SpawnLabMonster();


            }
        }
    }
}
