using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPot : MonoBehaviour
{
	public bool itemPot;
	public float speed;
	private Vector3 speedVector;
	private Vector3 lastFramePos;
	public GameObject myBreakPot;
	// Start is called before the first frame update
	void Start()
    {
		transform.parent = null;
    }

    // Update is called once per frame
    void Update()
	{
		speed = Vector3.Distance(transform.position, lastFramePos) / Time.deltaTime;
		lastFramePos = transform.position;
	}
	void BreakDaPot()
	{
		GameObject pot = Instantiate(myBreakPot, transform.position, transform.rotation);
		pot.transform.localScale = transform.localScale;
		if (itemPot)
			pot.transform.Find("Loot").gameObject.SetActive(true);
	}
	private void OnCollisionEnter(Collision collision)
	{
		if(speed > 2)
		{
			BreakDaPot();
		}

	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Wrench")
		{
			if (other.gameObject.GetComponent<WrenchHead1>().speed > 2)
				BreakDaPot();
		}
	}
}
