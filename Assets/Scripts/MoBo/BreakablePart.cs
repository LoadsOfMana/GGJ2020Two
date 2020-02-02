using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePart : MonoBehaviour
{
	public float breakThreshold = 3.5f;
	public GameObject particles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Wrench")
		{
			if(other.gameObject.GetComponent<WrenchHead1>().speed > breakThreshold)
			{
				Instantiate(particles, transform.position,transform.rotation);
				Destroy(gameObject);
			}
		}
	}
}
