using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability", menuName = "Ability/Shoot Projectile", order = 1)]
public class ShootProjectile : AbilityDescriptor
{
    public GameObject projectile;

    public void InstantiateProjectile(Monster monster)
    {
        GameObject clone = Instantiate(projectile, monster.mouth.position, Quaternion.identity);
        
        Physics2D.IgnoreCollision(monster.GetComponent<BoxCollider2D>(), clone.GetComponent<BoxCollider2D>(), true);

        ShootBehavior sb = clone.GetComponent<ShootBehavior>();
        sb.SetDirection(monster.isTurnedRight ? 1f : -1f);
        sb.damage = damage;
    }

    public override void Cast(Monster monster)
    {
        InstantiateProjectile(monster);
    }
}
