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

    public float cooldownTime;

    void Start()
    {
        cooldownTime = 0.0f;
    }

    public bool PreCondition(Monster monster)
    {
        
        if (Time.time < cooldownTime)
            return false;
            
        if (monster.energy < energyCost)
            return false;

        return true;
    }

    public void Start(Monster monster)
    {
        if (!PreCondition(monster))
            return;

        cooldownTime = Time.time + cooldown;
        monster.energy -= energyCost;
    }
}
