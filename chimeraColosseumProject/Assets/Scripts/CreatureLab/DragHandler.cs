using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 startPosition;
    private Transform originalParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;
        originalParent = transform.parent;
        transform.SetParent(transform.root);  // Move to the top of UI hierarchy to be rendered on top
        GetComponent<CanvasGroup>().blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition; // Follow the cursor
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = startPosition; // Reset position
        transform.SetParent(originalParent); // Return to original parent
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
