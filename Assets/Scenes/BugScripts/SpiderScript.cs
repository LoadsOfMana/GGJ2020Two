using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(0, Mathf.Sin(Time.time*10)*35, 0);
    }

    private void OnTriggerEnter(Collider collider)
    {
        var f = collider.gameObject.transform.up;

        var r = GetComponent<Rigidbody>();
        var v = r.velocity;
        var newV = Vector3.Reflect(v, f);

        //Debug.Log("spider hit, up is" + f + " oldV " + v + " newV " + newV);

        // reflect velocity off collision plane
        r.velocity = newV;
    }
}
