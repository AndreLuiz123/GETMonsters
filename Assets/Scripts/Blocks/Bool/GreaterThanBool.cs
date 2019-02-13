using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreaterThanBool : BoolValue
{
    public FloatValue value1;
    public FloatValue value2;

    public override bool Value(Monster monster)
    {
        return value1.Value(monster) > value2.Value(monster);
    }
}
