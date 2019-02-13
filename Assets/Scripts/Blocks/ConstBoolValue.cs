using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstBoolValue : BoolValue
{
    public bool value;

    public override bool Value(Monster monster)
    {
        return value;
    }
}
