using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCore : MonoBehaviour
{
	private HingeJoint myHinge;
	private bool done = false;
	public Transform shackle;
    // Start is called before the first frame update
    void Start()
    {
		myHinge = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
		if(myHinge.angle < -88 && !done)
		{
			done = true;
			JointSpring sprong = myHinge.spring;
			sprong.targetPosition = -90;
			myHinge.spring = sprong;
			Vector3 shacklePos = shackle.transform.localPosition;
			shacklePos.y = 0.05f;
			shackle.transform.localPosition = shacklePos;
			MCP.mcp.queuedScore = 1;
		}
    }
}
