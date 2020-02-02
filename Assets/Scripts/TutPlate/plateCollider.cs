using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateCollider : PuzzleWithOutcome
{
	public enum whichCollider { good, bad1, bad2 }
	public whichCollider whichCol;
	public GameObject brokenPrefab;
	public float breakThreshold = 3;
	private bool broken = false;
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Wrench" && !broken)
		{
			broken = true;
			if (other.gameObject.GetComponent<WrenchHead1>().speed > breakThreshold)
			{
				MCP.mcp.queuedScore = 0f;
				Destroy(transform.parent.gameObject); //[WIP] replace with shatter model when made
			}
			else if (other.gameObject.GetComponent<WrenchHead1>().speed > 1)
			{
				GameObject lastSpawn;
				switch (whichCol)
				{
					case whichCollider.bad1:
						lastSpawn = Instantiate(brokenPrefab, transform.position, transform.rotation);
						Destroy(lastSpawn.transform.Find("TravSide").gameObject);
						MCP.mcp.queuedScore = 0.5f;
						break;
					case whichCollider.bad2:
						lastSpawn = Instantiate(brokenPrefab, transform.position, transform.rotation);
						Destroy(lastSpawn.transform.Find("CageSide").gameObject);
						MCP.mcp.queuedScore = 0.5f;
						break;
					case whichCollider.good:
						lastSpawn = Instantiate(brokenPrefab, transform.position, transform.rotation);
						MCP.mcp.queuedScore = 1f;
						break;
				}
				Destroy(transform.parent.gameObject);
			}
		}
	}
}
		
