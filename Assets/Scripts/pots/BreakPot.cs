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
	private bool broken = false;
	public bool canBreakOnGround = false;
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
	[ContextMenu("break it")]
	void BreakDaPot()
	{
		if (broken)
			return;
		broken = true;
		transform.parent = null;
		GameObject pot = Instantiate(myBreakPot, transform.position, transform.rotation);
		pot.transform.localScale = transform.localScale;
		if (itemPot)
		{
			pot.transform.Find("Loot").GetComponent<MeshRenderer>().enabled = true;
			pot.transform.Find("Loot").GetComponent<MeshCollider>().enabled = true;
			pot.transform.Find("Loot").parent = null;
		}
		Destroy(gameObject);
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "Workbench")
			canBreakOnGround = true;
		if(speed > 2 && canBreakOnGround)
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
