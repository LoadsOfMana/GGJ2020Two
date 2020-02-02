using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateCollider : MonoBehaviour
{
	public enum WhichCollider { good, bad1, bad2 }
	public WhichCollider whichCol;
	public GameObject brokenPrefab;
	public float breakThreshold = 3;
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Wrench")
		{
			if (MCP.mcp.fixTheDamnPlate)
				return;
			if (other.gameObject.GetComponent<WrenchHead1>().speed > breakThreshold)
			{
				MCP.mcp.queuedScore = -1f;
				Destroy(transform.parent.gameObject); //[WIP] replace with shatter model when made
			}
			else if (other.gameObject.GetComponent<WrenchHead1>().speed > 0.5f)
			{
				GameObject lastSpawn;
				switch (whichCol)
				{
					case WhichCollider.bad1:
						lastSpawn = Instantiate(brokenPrefab, transform.position, transform.rotation);
						Destroy(lastSpawn.transform.Find("TravSide").gameObject);
						MCP.mcp.fixTheDamnPlate = true;
						break;
					case WhichCollider.bad2:
						lastSpawn = Instantiate(brokenPrefab, transform.position, transform.rotation);
						Destroy(lastSpawn.transform.Find("CageSide").gameObject);
						MCP.mcp.fixTheDamnPlate = true;
						break;
					case WhichCollider.good:
						lastSpawn = Instantiate(brokenPrefab, transform.position, transform.rotation);
						MCP.mcp.fixTheDamnPlate = true;
						break;
				}
				Destroy(transform.parent.gameObject);
			}
		}
	}
}
		
