﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability", menuName = "Ability/Projectile", order = 1)]
public class ProjectileDescriptor : AbilityDescriptor
{
    public GameObject projectile;

    public void InstantiateProjectile(Monster monster)
    {
        GameObject clone = Instantiate(projectile, monster.mouth.position, Quaternion.identity);
        
        Physics2D.IgnoreCollision(monster.GetComponent<Collider2D>(), clone.GetComponent<Collider2D>(), true);

        ShootBehavior sb = clone.GetComponent<ShootBehavior>();
        sb.SetDirection(monster.isTurnedRight ? 1f : -1f);
        sb.damage = damage;
    }

    public override void Cast(Monster monster)
    {
        InstantiateProjectile(monster);
    }
}
