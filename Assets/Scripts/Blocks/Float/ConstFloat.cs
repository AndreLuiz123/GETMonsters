using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstFloat : FloatValue
{
    public float value;

    public override float Value(Monster monster)
    {
        return value;
    }
}
