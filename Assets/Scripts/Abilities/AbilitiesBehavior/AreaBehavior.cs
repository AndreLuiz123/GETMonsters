using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaBehavior : MonoBehaviour
{
    public int damage;

    void DestroyObject()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag=="Player")
        {
            Monster monster = collider.gameObject.GetComponent<Monster>();
            monster.ReceiveDamage(damage);
            Physics2D.IgnoreCollision(collider, GetComponent<Collider2D>(), true);
        }
    }
}
