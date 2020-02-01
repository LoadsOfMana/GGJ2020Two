using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenchHead1 : MonoBehaviour
{
	private Vector3 speedVector;
	private Vector3 lastFramePos;
	public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		speed = Vector3.Distance(transform.position, lastFramePos) / Time.deltaTime;
		lastFramePos = transform.position;
    }
}
