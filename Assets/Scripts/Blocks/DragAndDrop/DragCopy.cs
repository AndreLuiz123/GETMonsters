using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragCopy : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemDragged;
    public static Vector3 relativePosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        var canvas = GetComponentInParent<Canvas>();
        if (canvas == null)
            return;

        DragObject.itemDragged = Instantiate(gameObject, transform.parent);
        // DragObject.itemDragged = Instantiate(gameObject, canvas.transform);
        DragObject.relativePosition = transform.position - Input.mousePosition;

        eventData.pointerDrag = DragObject.itemDragged;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition + relativePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemDragged = null;
        relativePosition = Vector3.zero;

        LayoutRebuilder.MarkLayoutForRebuild(DragObject.itemDragged.GetComponent<RectTransform>());
    }
}
