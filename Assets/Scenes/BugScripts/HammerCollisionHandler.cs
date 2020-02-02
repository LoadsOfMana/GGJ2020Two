using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerCollisionHandler : MonoBehaviour
{
    public GameObject SpiderPrefab;
    public GameController Game;

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
        var name = c.gameObject.name;

        if (name.StartsWith("machine"))
        {
            if (Game.BugCount <= 0) {
                return;
            }
            Debug.Log(c);
            var newSpider = Instantiate(SpiderPrefab);

            newSpider.transform.position = transform.position;
            Vector3 velocity;
            velocity.x = Random.Range(-.5f,.5f);
            velocity.y = Random.Range(3f,6f);
            velocity.z = Random.Range(.2f, .5f);

            var newScale = newSpider.transform.localScale * Random.Range(.3f, 1f);
            newSpider.transform.localScale = newScale;

            newSpider.GetComponent<Rigidbody>().velocity = velocity;
        }
    }

}
