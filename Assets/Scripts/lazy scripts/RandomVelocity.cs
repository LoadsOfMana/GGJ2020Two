using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomVelocity : MonoBehaviour
{
	public float variance = 1;
	private void Start()
	{
		GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-variance, variance), Random.Range(-variance, variance), Random.Range(-variance, variance));
	}
}
