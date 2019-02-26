using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour
{
    public Dictionary<string, Ability> abilityList;
    public List<Ability> passiveList;

    Monster monster;

    void Start()
    {
        monster = GetComponent<Monster>();
        abilityList = new Dictionary<string, Ability>();
        GetAbilitiesFromParts();
    }

    void Update()
    {
        if (Input.GetButtonDown("Ability1"))
        {
            abilityList["Fireball"].UseAbility(monster);
        }
        if (Input.GetButtonDown("Ability2"))
        {
             abilityList["Roar"].UseAbility(monster);
        }
    }

    void GetAbilitiesFromParts()
    {
        foreach (MonsterPart part in monster.parts)
        {
            foreach(AbilityDescriptor ability in part.abilityList)
                abilityList.Add(ability.name, new Ability(ability));

            foreach(AbilityDescriptor passive in part.passiveList)
                passiveList.Add(new Ability(passive));
        }
    }
}
