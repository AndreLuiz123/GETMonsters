using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstBool : BoolValue
{
    public bool value;

    public override bool Value(Monster monster)
    {
        return value;
    }
}
