using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFloat : FloatValue
{
    public float min;
    public float max;

    public override float Value(Monster monster)
    {
        return Random.Range(min, max);
    }
}
