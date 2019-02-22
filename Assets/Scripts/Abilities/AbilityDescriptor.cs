using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability", menuName = "Ability/Ability", order = 1)]
public class AbilityDescriptor : ScriptableObject
{
    public string name;
    public int damage;
    public float cooldown;
    public int energyCost;
    public float castTime;

    public virtual void Cast(Monster monster)
    {

    }
}
