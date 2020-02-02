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
	public GameObject otherCol1;
	public GameObject otherCol2;
	private void OnTriggerEnter(Collider other)
	{
		if (MCP.mcp.fixTheDamnPlate)
			return;
		if (other.gameObject.tag == "Wrench" && !broken)
		{
			if (other.gameObject.GetComponent<WrenchHead1>().speed > breakThreshold)
			{
				MCP.mcp.queuedScore = -1f;
				broken = true;
				MCP.mcp.fixTheDamnPlate = true;
				Destroy(transform.parent.gameObject); //[WIP] replace with shatter model when made
			}
			else if (other.gameObject.GetComponent<WrenchHead1>().speed > 0.5f)
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
				broken = true;
				MCP.mcp.fixTheDamnPlate = true;
				Destroy(otherCol1);
				Destroy(otherCol2);
				Destroy(transform.parent.gameObject);
			}
		}
	}
}
		
