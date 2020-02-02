using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeTheChildren : MonoBehaviour
{
	public bool destroyAfter = true;
	public float delay = 1;
	public float destroyDelay = 0;
    // Start is called before the first frame update
    void Start()
	{
		StartCoroutine(delayedDo());
	}

	IEnumerator delayedDo()
	{
		yield return new WaitForSeconds (delay);
		foreach(Transform child in transform)
		{
			child.parent = null;
		}
		if(transform.Find("TravSide"))
		transform.Find("TravSide").parent = null;
		if (transform.Find("CageSide"))
			transform.Find("CageSide").parent = null;
		yield return new WaitForSeconds(destroyDelay);
		if (destroyAfter)
			Destroy(gameObject);
	}

}
