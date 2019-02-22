using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int maxLife;
    public int maxEnergy;
    public int maxShield;

    public int movementSpeed;
    public int damage;
    public int resistence;

    int life;
    int energy;
    public int shield;

    public List<MonsterPart> parts;
    public Dictionary<string, Ability> abilityList;
    public List<Ability> passiveList;

    //variaveis da bola de fogo
    public GameObject Fireball;
    public float fireBallCD = 3f;
    public float fbCD = 0.0f;

    //variaveis que precisam de outro lugar
    public Transform mouth;
    public bool isTurnedRight;

    void Start ()
    {
        abilityList = new Dictionary<string, Ability>();
        getPartsInfo();
        isTurnedRight = true;

        foreach(KeyValuePair<string, Ability> ability in abilityList)
        {
            Debug.Log(ability.Key);
        }
    }


    void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
            fire();

        if (isTurnedRight && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isTurnedRight = false;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (!isTurnedRight && Input.GetKeyDown(KeyCode.RightArrow))
        {
            isTurnedRight = true;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    void fire()
    {
        if (Time.time >= fbCD)
        {
            fbCD = Time.time + fireBallCD;
            GameObject teste = Instantiate (Fireball, mouth.position, Quaternion.identity);
            FireballScript fbs = teste.GetComponent<FireballScript> ();
            fbs.velX = fbs.velX * (isTurnedRight ? 1f : -1f);
            fbs.transform.localScale =  new Vector3((isTurnedRight ? 1f : -1f), 1f, 1f);
            fbs.setPlayerCollider( GetComponent<BoxCollider2D>() );
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
