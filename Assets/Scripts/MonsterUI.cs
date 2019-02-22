using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterUI : MonoBehaviour
{
    public Monster monster;

    public RectTransform healthUI;
    public RectTransform shieldUI;
    public RectTransform energyUI;

    void Update()
    {
        healthUI.anchorMax = new Vector2(monster.health / (float)monster.maxHealth, healthUI.anchorMax.y);
        shieldUI.anchorMax = new Vector2(monster.shield / (float)monster.maxShield, shieldUI.anchorMax.y);
        energyUI.anchorMax = new Vector2(monster.energy / (float)monster.maxEnergy, energyUI.anchorMax.y);
    }
}
