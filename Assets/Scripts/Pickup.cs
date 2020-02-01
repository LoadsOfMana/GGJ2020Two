using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
	public ControllerInput myHand;
	public List<Rigidbody> touchingBodies;
	private void OnTriggerEnter(Collider collision)
	{
		Rigidbody otherBody = collision.gameObject.transform.root.GetComponent<Rigidbody>();
		if (otherBody != null && !touchingBodies.Contains(otherBody))
			touchingBodies.Add(otherBody);
	}
	private void OnTriggerExit(Collider collision)
	{
		Rigidbody otherBody = collision.gameObject.transform.root.GetComponent<Rigidbody>();
		if (otherBody)
			touchingBodies.Remove(otherBody);
	}
	private void Update()
	{
		if (myHand.pinch.stateDown)
		{
			foreach(Rigidbody rb in touchingBodies)
			{
				rb.isKinematic = true;
				rb.transform.parent = transform;
			}
		}
		if (myHand.pinch.stateUp)
		{
			foreach (Rigidbody rb in touchingBodies)
			{
				rb.isKinematic = false;
				rb.transform.parent = null;
			}
		}
	}
}
