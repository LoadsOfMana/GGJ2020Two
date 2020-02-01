using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCP : MonoBehaviour
{
	public static MCP mcp;
	public List<GameObject> mustClearList;
    // Start is called before the first frame update
    void Awake()
    {
		mcp = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
