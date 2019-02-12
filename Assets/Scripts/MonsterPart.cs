using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster Part", menuName = "Monster/Monster Part", order = 1)]
public class MonsterPart : ScriptableObject
{
    int life;
    int shield;
    int movementSpeed;
    int damage;
    int partID;
    public List <Ability> abilityList;
    Image sprite;
}
