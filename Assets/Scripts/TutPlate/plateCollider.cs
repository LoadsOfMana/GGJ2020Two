using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateCollider : MonoBehaviour
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
				Destroy(transform.parent.gameObject); //[WIP] replace with shatter model when made
				//give no points after turn in
			}
			else
			{
				GameObject lastSpawn;
				switch (whichCol)
				{
					case whichCollider.bad1:
						lastSpawn = Instantiate(brokenPrefab, transform.position, transform.rotation);
						Destroy(lastSpawn.transform.Find("TravSide").gameObject); 
						//spawn trav side shatter model						  
						//give half points after turn in 
						break;
					case whichCollider.bad2:
						lastSpawn = Instantiate(brokenPrefab, transform.position, transform.rotation);
						Destroy(lastSpawn.transform.Find("CageSide").gameObject);
						//spawn cage side shatter model									 
						//give half points after turn in 
						break;
					case whichCollider.good:
							lastSpawn = Instantiate(brokenPrefab, transform.position, transform.rotation);
						//give full points after turn in 
						break;
				}
				Destroy(transform.parent.gameObject);
			}
		}
	}
}
		
