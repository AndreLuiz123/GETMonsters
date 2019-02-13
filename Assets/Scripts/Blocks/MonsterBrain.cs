using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBrain : MonoBehaviour
{
    public Monster monster;
    public ProgramBlock start;

    private ProgramBlock current;

    void Start()
    {
        current = start;
    }

    void Update()
    {
        Execute();
    }

    public void Execute()
    {
        for(; current != null;)
        {
            current = current.Execute(monster);
        }
    }
}
