using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wow : MonoBehaviour
{
	private void OnDestroy()
	{
		MCP.mcp.wowBox.Play();
	}
}
