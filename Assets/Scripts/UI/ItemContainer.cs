using UnityEngine;
using UnityEngine.EventSystems;

public class ItemContainer : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            var obj = eventData.pointerDrag.GetComponent<Transform>();
            obj.transform.position = transform.position;
            obj.SetParent(transform);
        }
    }
}