using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragMove : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static DropContainer dropContainer;
    public static Vector3 relativePosition;
    public static Canvas canvas;

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvas = GetComponentInParent<Canvas>();
        if (canvas == null)
            return;

        DragCopy.relativePosition = transform.position - Input.mousePosition;
        eventData.pointerDrag = gameObject;
        CanvasGroup canvasGroup = eventData.pointerDrag.GetComponent<CanvasGroup>();
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject)
        {
            Transform selfTransform = eventData.pointerDrag.transform;
            dropContainer = eventData.pointerCurrentRaycast.gameObject.GetComponent<DropContainer>();

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

        dropContainer.UpdateProgram(eventData.pointerDrag);

        LayoutRebuilder.MarkLayoutForRebuild(eventData.pointerDrag.GetComponent<RectTransform>());
    }

    public void SetAsNextSibling(Transform selfTransform, Transform siblingTransform, bool next = true)
    {
        selfTransform.SetParent(siblingTransform.parent);
        selfTransform.SetSiblingIndex(siblingTransform.GetSiblingIndex() + (next ? 1 : 0));
    }
}
