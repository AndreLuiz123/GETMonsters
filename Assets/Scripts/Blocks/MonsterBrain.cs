using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBrain : MonoBehaviour
{
    public Monster monster;
    public ProgramBlock start;

    private ProgramBlock current;
    private int comboBreaker;

    public void Execute()
    {
        comboBreaker = 10;

        for(current = start; current != null;)
        {
            current = current.Execute(monster);

            comboBreaker--;
            if (comboBreaker < 0)
            {
                Debug.LogWarning("C-C-C-COMBO BREAKER!!!");
                return;
            }
        }
    }
}
