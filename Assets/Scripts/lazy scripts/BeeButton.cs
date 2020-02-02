using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeButton : MonoBehaviour
{
	public GameObject bees;
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Wrench")
		{
			Instantiate(bees, MCP.mcp.transform.position, transform.rotation);
		}
	}
}
