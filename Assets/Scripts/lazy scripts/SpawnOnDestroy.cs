using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDestroy : MonoBehaviour
{
	public GameObject theThing;
	private void OnDestroy()
	{
		Instantiate(theThing, transform.position, transform.rotation);
	}
}
