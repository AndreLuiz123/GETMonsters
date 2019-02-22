using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfBlock : ProgramBlock
{
    public BoolValue condition;
    public ProgramBlock falseBlock;

    public override ProgramBlock Execute(Monster monster)
    {
        if (condition.Value(monster))
        {
            // TODO(AndreM): o ultimo block deste true block volta pro next
            return nextBlock;
        }

        return falseBlock;
    }
}
