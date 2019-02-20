using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragCopy : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Vector3 relativePosition;
    public static Canvas canvas;

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvas = GetComponentInParent<Canvas>();
        if (canvas == null)
            return;

        DragCopy.relativePosition = transform.position - Input.mousePosition;
        eventData.pointerDrag = Instantiate(gameObject, canvas.transform);
        CanvasGroup canvasGroup = eventData.pointerDrag.GetComponent<CanvasGroup>();
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject)
        {
            Transform selfTransform = eventData.pointerDrag.transform;
            DropContainer dropContainer = eventData.pointerCurrentRaycast.gameObject.GetComponent<DropContainer>();

            if (dropContainer)
            {
                SetAsNextSibling(selfTransform, dropContainer.newSibling, dropContainer.dropNext);
            }
            else
            {
                selfTransform.SetParent(canvas.transform);
            }
        }
        transform.position = Input.mousePosition + relativePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        CanvasGroup canvasGroup = eventData.pointerDrag.GetComponent<CanvasGroup>();
        canvasGroup.blocksRaycasts = true;
        relativePosition = Vector3.zero;

        LayoutRebuilder.MarkLayoutForRebuild(eventData.pointerDrag.GetComponent<RectTransform>());
    }

    public void SetAsNextSibling(Transform selfTransform, Transform siblingTransform, bool next = true)
    {
        selfTransform.SetParent(siblingTransform.parent);
        selfTransform.SetSiblingIndex(siblingTransform.GetSiblingIndex() + (next ? 1 : 0));
    }
}
