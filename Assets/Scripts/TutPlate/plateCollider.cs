using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateCollider : MonoBehaviour
{
	public enum whichCollider { good, bad1, bad2 }
	public whichCollider whichCol;
	public GameObject brokenPrefab;
	public float breakThreshold = 3;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Wrench")
		{
			if (other.gameObject.GetComponent<WrenchHead1>().speed > breakThreshold)
			{
				Destroy(transform.parent.gameObject); //[WIP] replace with shatter model when made
				//give no points after turn in
			}
			else
			{
				GameObject lastSpawn = new GameObject();
				switch (whichCol)
				{
					case whichCollider.bad1:
						lastSpawn = Instantiate(brokenPrefab, transform.position, transform.rotation);
						Destroy(lastSpawn.transform.Find("TravSide").gameObject); //[WIP] replace with shatter model when made
																				  //give half points after turn in 
						Destroy(transform.parent.gameObject);
						break;
					case whichCollider.bad2:
						lastSpawn = Instantiate(brokenPrefab, transform.position, transform.rotation);
						Destroy(lastSpawn.transform.Find("CageSide").gameObject);//[WIP] replace with shatter model when made
																				 //give half points after turn in 
						Destroy(transform.parent.gameObject);
						break;
					case whichCollider.good:
						lastSpawn = Instantiate(brokenPrefab, transform.position, transform.rotation);
						//give full points after turn in 
						Destroy(transform.parent.gameObject);
						break;
				}
			}
		}
	}
}
		
