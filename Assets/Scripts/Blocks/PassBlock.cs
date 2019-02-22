using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassBlock : ProgramBlock
{
    public override ProgramBlock Execute(Monster monster)
    {
        return nextBlock;
    }
}
