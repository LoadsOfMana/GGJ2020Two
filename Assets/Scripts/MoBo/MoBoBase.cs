using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoBoBase : MonoBehaviour
{
	public Spin fanSpinner;
	public List<BreakablePart> parts;
	public List<GameObject> bugs;
	private bool doneThing = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		for(int i = bugs.Count; i > 0; i--)
		{
			if (bugs[i - 1] == null)
				bugs.RemoveAt(i - 1);
		}
		for (int i = parts.Count; i > 0; i--)
		{
			if (parts[i - 1] == null)
				parts.RemoveAt(i - 1);
		}
		if (bugs.Count == 0 && parts.Count > 5 && !doneThing)
		{
			doneThing = true;
			GetComponent<AudioSource>().Play();
			StartCoroutine(FanSpinup());
		}
    }
	IEnumerator FanSpinup()
	{
		for (float i = 0; i < 1; i += 0.05f)
		{
			fanSpinner.speed.y = 50 * i;
			yield return new WaitForSeconds(0.05f);
		}
	}
}
