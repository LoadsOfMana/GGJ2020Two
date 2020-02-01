using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerCollisionHandler : MonoBehaviour
{
    public GameObject SpiderPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider c)
    {
        Debug.Log(c);
        var newSpider = Instantiate(SpiderPrefab);

        newSpider.transform.position = transform.position;
        Vector3 velocity;
        var minV = -0.5f;
        var maxV = -minV;
        velocity.x = Random.Range(minV, maxV);
        velocity.y = Random.Range(minV, maxV);
        velocity.z = Random.Range(minV, maxV);

        var newScale = newSpider.transform.localScale * Random.Range(.3f, 1f);
        newSpider.transform.localScale = newScale;

        newSpider.GetComponent<Rigidbody>().velocity = velocity;
    }

}
