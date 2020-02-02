using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltEndHandler : MonoBehaviour
{
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
		if (other.gameObject.transform.root.GetComponent<SpawnOnDestroy>())
			other.gameObject.transform.root.GetComponent<SpawnOnDestroy>().disarm = true;
		if (other.gameObject.transform.root.GetComponent<MustClear>())
		{
			MCP.mcp.queuedScore += other.gameObject.transform.root.GetComponent<MustClear>().addScore;
			Destroy(other.transform.root.gameObject);
		}
	}

}
