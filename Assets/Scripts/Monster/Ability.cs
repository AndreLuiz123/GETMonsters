using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability", menuName = "Ability/Ability", order = 1)]
public class Ability : ScriptableObject
{
    public string name;
    public int damage;
    public int cooldown;
    public float castTime;

    void useAbality()
    {
        
    }
}
