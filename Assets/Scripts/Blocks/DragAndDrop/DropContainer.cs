using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropContainer : MonoBehaviour, IDropHandler
{
    public Transform newSibling;
    public bool dropNext;

    public ProgramBlock selfBlock;

    public void OnDrop(PointerEventData eventData)
    {
    }

    public void UpdateProgram(GameObject dropObject)
    {
        Debug.Log("OnDrop");
        // GameObject dropObject = eventData.pointerDrag;

        ProgramBlock dropBlock = dropObject.GetComponent<ProgramBlock>();
        if (dropBlock)
        {
            if (dropBlock.prevBlock)
                dropBlock.prevBlock.nextBlock = dropBlock.nextBlock;
            if (dropBlock.nextBlock)
                dropBlock.nextBlock.prevBlock = dropBlock.prevBlock;

            if (dropNext)
            {
                ProgramBlock nextBlock = selfBlock.nextBlock;

                dropBlock.nextBlock = nextBlock;
                if (nextBlock)
                    nextBlock.prevBlock = dropBlock;

                selfBlock.nextBlock = dropBlock;
                dropBlock.prevBlock = selfBlock;
            }
            else
            {
                ProgramBlock prevBlock = selfBlock.prevBlock;

                dropBlock.prevBlock = prevBlock;
                if (prevBlock)
                    prevBlock.nextBlock = dropBlock;

                selfBlock.prevBlock = dropBlock;
                dropBlock.nextBlock = selfBlock;
            }
        }
    }
}
