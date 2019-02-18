using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability", menuName = "Ability/Ability", order = 1)]
public class Ability : ScriptableObject
{
    public string name;
    int damage;
    int cooldown;
    float castTime;

    void useAbality()
    {

    }
}
