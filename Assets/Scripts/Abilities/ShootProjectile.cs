﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability", menuName = "Ability/Shoot Projectile", order = 1)]
public class ShootProjectile : Ability
{
    public GameObject projectile;

    public override void Cast(Monster monster)
    {
        GameObject clone = Instantiate(projectile, monster.mouth.position, Quaternion.identity);

        Physics2D.IgnoreCollision(monster.GetComponent<BoxCollider2D>(), clone.GetComponent<BoxCollider2D>(), true);

        float direction = (monster.isTurnedRight ? 1f : -1f);
        ShootBehavior sb = clone.GetComponent<ShootBehavior>();
        sb.SetDirection(direction);
    }
}
