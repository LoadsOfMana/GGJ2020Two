using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeTrigger : MonoBehaviour
{
	public int myNum;
	private CakePuzzle cakeMaster;
	public bool touched = false;
	public GameObject visPoint;
    // Start is called before the first frame update
    void Start()
    {
		cakeMaster = transform.parent.GetComponent<CakePuzzle>();
		cakeMaster.theBois.Add(this);
		visPoint = new GameObject();
		visPoint.transform.position = transform.position;
		visPoint.transform.parent = transform;
		visPoint.transform.localPosition += new Vector3(0, 0.75f, 0);
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "CakeCutter")
		{
			touched = true;
			cakeMaster.AddNum(myNum,visPoint.transform);
		}
	}
}
