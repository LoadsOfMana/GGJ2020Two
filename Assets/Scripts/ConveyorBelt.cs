using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
	public float speed = 1;
	public List<Rigidbody> touchingBodies;
	private AudioSource mySound;
	private float dumpTimer = 1;
	private void Start()
	{
		mySound = GetComponent<AudioSource>();
	}
	private void OnCollisionStay(Collision collision)
	{
		Rigidbody otherBody = collision.collider.gameObject.transform.root.GetComponentInChildren<Rigidbody>();
		if (otherBody != null && !touchingBodies.Contains(otherBody))
			touchingBodies.Add(otherBody);
	}
	private void OnCollisionExit(Collision collision)
	{
		Rigidbody otherBody = collision.collider.gameObject.transform.root.GetComponent<Rigidbody>();
		if (otherBody)
			touchingBodies.Remove(otherBody);
	}
	private void Update()
	{
		dumpTimer -= Time.deltaTime;
		if(dumpTimer <= 0)
		{
			dumpTimer = 1;
			touchingBodies.Clear();
		}
		if(touchingBodies.Count > 0)
		{
			if (!mySound.isPlaying)
				mySound.Play();
			foreach(Rigidbody rb in touchingBodies)
			{
				if (rb)
				{
					if(rb.gameObject.name.StartsWith("Lock"))
						rb.velocity = transform.right * -speed * 2;
					if (rb.gameObject.name.StartsWith("MoBo"))
						rb.velocity = transform.right * -speed * 5;
					else
					rb.velocity = transform.right * -speed;
				}
			}
		}
		else
			if (mySound.isPlaying)
			mySound.Stop();
	}
}
