using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugBlock : ProgramBlock
{
	public string message;

	public override ProgramBlock Execute()
	{
		Debug.Log(message);

		return nextBlock;
	}
}
