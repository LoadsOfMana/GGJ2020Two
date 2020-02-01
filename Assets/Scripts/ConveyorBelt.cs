using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
	public float speed = 1;
	public List<Rigidbody> touchingBodies;
	private void OnCollisionEnter(Collision collision)
	{
		Rigidbody otherBody = collision.collider.gameObject.GetComponent<Rigidbody>();
		if (otherBody != null && !touchingBodies.Contains(otherBody))
			touchingBodies.Add(otherBody);
	}
	private void OnCollisionExit(Collision collision)
	{
		if (collision.collider.gameObject.GetComponent<Rigidbody>())
			touchingBodies.Remove(collision.collider.gameObject.GetComponent<Rigidbody>());
	}
	private void Update()
	{
		if(touchingBodies.Count > 0)
		{
			foreach(Rigidbody rb in touchingBodies)
			{
				rb.velocity = transform.right * -speed;
			}
		}
	}
}
