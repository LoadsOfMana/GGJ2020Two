using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MustClear : MonoBehaviour
{
	public float addScore;
    // Start is called before the first frame update
    void Start()
    {
		MCP.mcp.mustClearList.Add(gameObject);
    }

	private void OnDestroy()
	{
		MCP.mcp.mustClearList.Remove(gameObject);
	}
}
