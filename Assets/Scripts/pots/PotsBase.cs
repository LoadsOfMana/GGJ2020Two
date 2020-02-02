using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotsBase : MonoBehaviour
{
	public BreakPot[] pots;
    // Start is called before the first frame update
    void Start()
    {
		pots[Random.Range(0, 3)].itemPot = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
