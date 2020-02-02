using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTrigger : MonoBehaviour
{
	public Transform respawnTar;
	private void OnTriggerEnter(Collider other)
	{
		other.transform.position = respawnTar.position;
		if (other.gameObject.GetComponent<Rigidbody>())
			other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
	}

}
