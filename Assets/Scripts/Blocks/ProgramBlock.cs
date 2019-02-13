using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProgramBlock : MonoBehaviour
{
    public ProgramBlock nextBlock;

    public abstract ProgramBlock Execute(Monster monster);
}
