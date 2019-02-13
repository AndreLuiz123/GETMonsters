using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugBlock : ProgramBlock
{
    public string message;
    public FloatValue value;

    public override ProgramBlock Execute(Monster monster)
    {
        Debug.Log(message + ": " + value.Value(monster));

        return nextBlock;
    }
}
