using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifespan : MonoBehaviour
{
	public float variance = 0;
	public float lifeSpan = 3f;
    // Start is called before the first frame update
    void Start()
    {
		Destroy(gameObject, lifeSpan + Random.Range(-variance,variance));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
