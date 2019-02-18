using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int maxLife;
    int life;
    public int maxEnergy;
    int energy;
    public int maxShield;
    int shield;
    public int movementSpeed;
    public int damage;
    public int resistence;
    
    public List<MonsterPart> parts;
    public Dictionary<string, Ability> abilityList;
    public List<Ability> passiveList;

    void Start ()
    {
        abilityList = new Dictionary<string, Ability>();
        getPartsInfo();
        
        foreach(KeyValuePair<string, Ability> ability in abilityList)
        {
            Debug.Log(ability.Key);
        }
    }

    void getPartsInfo()
    {
        foreach (MonsterPart part in parts)
        {
            maxLife += part.life;
            maxShield += part.shield;
            movementSpeed += part.movementSpeed;
            damage += part.damage;

            foreach(Ability ability in part.abilityList)
            {
                abilityList.Add(ability.name, ability);
            }

            foreach(Ability passive in part.passiveList)
            {
                passiveList.Add(passive);
            }
        }
    }
}
