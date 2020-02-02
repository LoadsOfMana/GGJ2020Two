using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeAI : MonoBehaviour
{
	public float force = 0.1f;
	private Rigidbody myBody;
	// Start is called before the first frame update
	void Start()
	{
		myBody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		myBody.AddForce((MCP.mcp.player.position - transform.position).normalized * force);
	}
	private void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name.StartsWith("Hammer"))
		{
			if ((collider.transform.parent.GetComponent<WrenchHead1>() && collider.transform.parent.GetComponent<WrenchHead1>().speed > 2) || !collider.transform.parent.GetComponent<WrenchHead1>())
			{
				collider.gameObject.transform.parent.gameObject.GetComponent<AudioSource>().Play();
				Destroy(gameObject);
			}
		}
	}
}

