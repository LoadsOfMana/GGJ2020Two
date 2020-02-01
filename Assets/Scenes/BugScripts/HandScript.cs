using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        var p = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LHand);
        var r = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LHand);
        //Debug.Log(p);
        transform.position = p;
        transform.rotation = r;
    }

    void OnCollisionEnter(Collision c)
    {
        Debug.Log(c);
    }
}
