using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugExplosionScript : MonoBehaviour
{
    float createTime;
    public bool IsPrefab;

    // Start is called before the first frame update
    void Start()
    {
        createTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        var elapsed = Time.time - createTime;
        if (elapsed > 3 && !IsPrefab)
        {
            Destroy(gameObject);
        }
    }
}
