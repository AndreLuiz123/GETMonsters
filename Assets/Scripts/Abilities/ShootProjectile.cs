using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : Ability
{
    public GameObject projectile;
    private GameObject clone;
    Rigidbody2D rb;

    void Start()
    {
        abilityDescriptor.cooldownTime = 0.0f;
    }

    override public void useAbility(Monster monster)
    {
        
        if (abilityDescriptor.PreCondition(monster))
        {
            abilityDescriptor.Start(monster);

            clone = Instantiate (projectile, monster.mouth.position, Quaternion.identity);

            Physics2D.IgnoreCollision(monster.GetComponent<BoxCollider2D>(), clone.GetComponent<BoxCollider2D>(), true);

            float direction = (monster.isTurnedRight ? 1f : -1f);
            ShootBehavior sb = clone.GetComponent<ShootBehavior>();
            sb.setDirection(direction);
        }
        
        else
        {
            Debug.Log("cooldown: " + abilityDescriptor.cooldownTime + " tempo: " + Time.time);
        }
    }
}
