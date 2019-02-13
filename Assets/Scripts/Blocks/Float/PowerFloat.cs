using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerFloat : FloatValue
{
    public FloatValue value1;
    public FloatValue value2;

    public override float Value(Monster monster)
    {
        return Mathf.Pow(value1.Value(monster), value2.Value(monster));
    }
}
