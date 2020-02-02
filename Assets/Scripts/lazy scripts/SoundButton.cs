using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton : MonoBehaviour
{
	private AudioSource mySound;
    // Start is called before the first frame update
    void Start()
    {
		mySound = GetComponent<AudioSource>();
    }

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Wrench")
		{
			mySound.Play();
		}
	}
}
