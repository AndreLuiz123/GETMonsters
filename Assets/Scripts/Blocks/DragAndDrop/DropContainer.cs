using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropContainer : MonoBehaviour, IDropHandler
{
    public Transform newSibling;
    public bool dropNext;

    public void OnDrop(PointerEventData eventData)
    {
        /*
        ProgramBlock block;
        ProgramBlock newBlock;
        if (dropNext)
        {
            block.next = newBlock;
        }
        else
        {
            newBlock.next = block;
        }
        */
        // DragHandler.itemDragged.transform.SetParent(newParent);
    }
}
