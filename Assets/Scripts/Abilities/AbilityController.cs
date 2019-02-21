using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour
{
    public Dictionary<string, Ability> abilityList;
    public List<Ability> passiveList;

    Monster monster;

    public Ability testAbility;

    void Start()
    {     
        monster = GetComponent<Monster>();
        abilityList = new Dictionary<string, Ability>();
        getAbilitiesFromParts(); 
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            testAbility.useAbility(monster);
        }
    }

    void getAbilitiesFromParts()
    {
        foreach (MonsterPart part in monster.parts)
        {
            foreach(Ability ability in part.abilityList)
                abilityList.Add(ability.name, ability);

            foreach(Ability passive in part.passiveList)
                passiveList.Add(passive);
        }
    }  
}
