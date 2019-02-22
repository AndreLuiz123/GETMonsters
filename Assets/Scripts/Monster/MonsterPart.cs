using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster Part", menuName = "Monster/Monster Part", order = 1)]
public class MonsterPart : ScriptableObject
{
    public int life;
    public int shield;
    public int movementSpeed;
    public int damage;
    public int partID;
    public List <AbilityDescriptor> abilityList;
    public List <AbilityDescriptor> passiveList;
    Sprite sprite;
}
