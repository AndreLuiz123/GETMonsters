using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public AbilityDescriptor abilityDescriptor;

    public abstract void useAbility(Monster monster);
}
