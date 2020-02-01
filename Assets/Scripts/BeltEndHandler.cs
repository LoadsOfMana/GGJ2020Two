using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltEndHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject incoming = other.gameObject;
        if(incoming) 
        {
            // XXX we need to check incoming for a score, text, audio, etc first
            Score(incoming.GetComponent<PuzzleWithOutcome>());
            Destroy(incoming, 5.0f); // XXX this could lead to a race, change to
                                    // a queued approach?
        }

    }

    void Score(PuzzleWithOutcome p)
    {
        // XXX add logic here to send text to UI, sound to player, score to total
        Debug.Log(p);
        return;
    }
}
