using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeLine : MonoBehaviour
{
	public Transform firstPoint;
	public Transform secondPoint;
	private LineRenderer myRend;
	// Start is called before the first frame update
    void Start()
    {
		myRend = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
		if(firstPoint)
		myRend.SetPosition(0, firstPoint.position);
		if(secondPoint)
		myRend.SetPosition(1, secondPoint.position);
	}
	private void LateUpdate()
	{
		if(!firstPoint && !secondPoint)
		{
			Destroy(gameObject);
		}
	}
}
