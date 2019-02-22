using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability
{
    AbilityDescriptor descriptor;

    public float cooldownTime;

    public Ability(AbilityDescriptor descriptor)
    {
        this.descriptor = descriptor;
    }

    public void Initialize()
    {
        cooldownTime = 0.0f;
    }

    public bool PreCondition(Monster monster)
    {
        if (Time.time < cooldownTime)
            return false;

        if (monster.energy < descriptor.energyCost)
            return false;

        return true;
    }

    public void UseAbility(Monster monster)
    {
        if (!PreCondition(monster))
            return;

        cooldownTime = Time.time + descriptor.cooldown;
        monster.energy -= descriptor.energyCost;

        // CastTime

        descriptor.Cast(monster);
    }
}
