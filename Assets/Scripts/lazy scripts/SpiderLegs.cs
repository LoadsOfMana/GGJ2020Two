using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderLegs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.localRotation = Quaternion.Euler(0, 0, Mathf.Sin((Time.time) * 10) * 35);
	}
}
