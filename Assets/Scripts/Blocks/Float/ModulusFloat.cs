using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModulusFloat : FloatValue
{
    public FloatValue value1;
    public FloatValue value2;

    public override float Value(Monster monster)
    {
        return (int)value1.Value(monster) % (int)value2.Value(monster);
    }
}
