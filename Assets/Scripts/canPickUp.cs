using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canPickUp : MonoBehaviour
{
	private Pickup grabbingHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (!grabbingHand)
			return;
		if (grabbingHand.myHand.pinch.stateUp)
		{
			transform.parent = null;
			GetComponent<Rigidbody>().isKinematic = false;
			GetComponent<Rigidbody>().velocity = grabbingHand.velocity;
			grabbingHand = null;
		}
    }
	private void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "Grabber")
		{
			if (other.gameObject.GetComponent<Pickup>().myHand.pinch.stateDown)
			{
				transform.parent = other.gameObject.transform;
				grabbingHand = other.gameObject.GetComponent<Pickup>();
				GetComponent<Rigidbody>().isKinematic = true;
			}
		}
	}
}
