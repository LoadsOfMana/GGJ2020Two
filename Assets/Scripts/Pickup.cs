using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
	public ControllerInput myHand;
	public Vector3 velocity;
	private Vector3 lastFramePos;

	private void Start()
	{
		lastFramePos = transform.position;
	}
	private void Update()
	{
		velocity = (transform.position - lastFramePos) / Time.deltaTime;
		lastFramePos = transform.position;
	}
}
