using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int maxHealth;
    public int maxShield;
    public int maxEnergy;

    public int health;
    public int shield;
    public int energy;

    public int movementSpeed;
    public int damage;
    public int resistence;

    public List<MonsterPart> parts;

    //variaveis que precisam de outro lugar
    public Transform mouth;
    public bool isTurnedRight;

    void Start ()
    {
        GetStatusFromParts();
        isTurnedRight = true;
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isTurnedRight = false;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            isTurnedRight = true;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    void GetStatusFromParts()
    {
        foreach (MonsterPart part in parts)
        {
            maxHealth += part.health;
            maxShield += part.shield;
            movementSpeed += part.movementSpeed;
            damage += part.damage;
        }
    }
}
