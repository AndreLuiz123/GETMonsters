using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBrain : MonoBehaviour
{
    public ProgramBlock start;

    private ProgramBlock current;
    private Dictionary<string, int> variables;

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
            current = current.Execute();
        }
    }
}
