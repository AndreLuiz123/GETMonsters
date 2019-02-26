using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability", menuName = "Ability/Area Effect", order = 1)]
public class AreaEffectDescriptor : AbilityDescriptor
{
    public GameObject prefab;

    public void InstantiateArea(Monster monster)
    {
        GameObject clone = Instantiate(prefab, monster.transform);
        Physics2D.IgnoreCollision(monster.GetComponent<Collider2D>(), clone.GetComponent<Collider2D>(), true);
        
        clone.GetComponent<AreaBehavior>().damage = damage;
    }

    public override void Cast(Monster monster)
    {
        InstantiateArea(monster);
    }
}
