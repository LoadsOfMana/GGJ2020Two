using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDestroy : MonoBehaviour
{
	public GameObject theThing;
	public bool disarm = false;
	private void OnDestroy()
	{
		if(!disarm)
		Instantiate(theThing, transform.position, transform.rotation);
	}
}
