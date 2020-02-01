using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerInput : MonoBehaviour
{
	public SteamVR_Action_Vector2 thumbStick;
	public SteamVR_Action_Vector2 touchPad;
	public SteamVR_Action_Single squeeze;
	public SteamVR_Action_Boolean grip;
	public SteamVR_Action_Boolean pinch;
	public SteamVR_Action_Boolean trigger;
	public SteamVR_Action_Skeleton skeleton;
	public SteamVR_Action_Boolean buttonA;
	public SteamVR_Action_Boolean buttonB;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	//	ThumbStick();
	//	TouchPad();
	//	Squeeze();
	//	Grab();
		Pinch();
	//	Trigger();
	//	Skeleton();
	}
	
	void ThumbStick()
	{
		if (thumbStick.axis != Vector2.zero)
			print(gameObject.name +" " + thumbStick.axis);
	}
	void TouchPad()
	{
		if (touchPad.axis != Vector2.zero)
			print(gameObject.name + " " + touchPad.axis);
	}
	void Squeeze()
	{
		if (squeeze.axis != 0)
			print(gameObject.name + " " + squeeze.axis);
	}

	void Grip()
	{
		if (grip.stateDown)
			print(gameObject.name + " " + "grabbed");
		if (grip.stateUp)
			print(gameObject.name + " " + "grab released");
	}
	void Pinch()
	{
		if (pinch.stateDown)
			print(gameObject.name + " " + "pinched");
		if (pinch.stateUp)
			print(gameObject.name + " " + "pinch released");
	}
	void Trigger()
	{
		if (trigger.stateDown)
			print(gameObject.name + " " + "triggered");
		if (trigger.stateUp)
			print(gameObject.name + " " + "trigger released");
	}

	void Skeleton()
	{
		float[] allFingers = skeleton.fingerCurls;
		print(gameObject.name + " " + allFingers[0]);
		print(gameObject.name + " " + allFingers[1]);
		print(gameObject.name + " " + allFingers[2]);
		print(gameObject.name + " " + allFingers[3]);
		print(gameObject.name + " " + allFingers[4]);
	}
}
