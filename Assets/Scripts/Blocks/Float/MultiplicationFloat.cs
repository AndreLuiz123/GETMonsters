﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplicationFloat : FloatValue
{
    public FloatValue value1;
    public FloatValue value2;

    public override float Value(Monster monster)
    {
        return value1.Value(monster) * value2.Value(monster);
    }
}
