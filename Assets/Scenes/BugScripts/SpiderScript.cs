using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : MonoBehaviour
{
    public float SpawnTime;
    public GameController Game;

    // Start is called before the first frame update
    void Start()
    {
        SpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(0, Mathf.Sin(Time.time*10)*35, 0);
    }

    private void OnTriggerEnter(Collider collider)
    {
        var name = collider.gameObject.name;

        if (name.StartsWith("Plane")) {
            var f = collider.gameObject.transform.up;

            var r = GetComponent<Rigidbody>();
            var v = r.velocity;
            var newV = Vector3.Reflect(v, f);

            //Debug.Log("spider hit, up is" + f + " oldV " + v + " newV " + newV);

            // reflect velocity off collision plane
            r.velocity = newV;
        }
        else if (name.StartsWith("Hammer"))
        {
            Debug.Log("hit with " + name + "detected");
            var aliveTime = Time.time - SpawnTime;
            // have cooldown before spider can be killed with hammer,
            // since right now hammer spawns spider it might disappear
            // right when it's created otherwise
            if (aliveTime > .5f)
            {
                collider.gameObject.transform.parent.gameObject.GetComponent<AudioSource>().Play();
                Destroy(gameObject);
                if (Game != null)
                {
                    Game.BugKilled();
                }
            }
        } else if (name.StartsWith("Floor"))
        {
            // in this case destroy the object without decrementing
            // bug count, we can assume it makes it's way back into the machine
            Debug.Log("spider hit floor");
            Destroy(gameObject);
        }
        
    }
}
