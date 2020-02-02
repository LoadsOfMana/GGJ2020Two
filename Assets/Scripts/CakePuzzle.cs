using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakePuzzle : MonoBehaviour
{
    private int[] cutEndpoints = new int[6];
    private int cutNumber = 0;
    private int cutState = -1;
	public List<CakeTrigger> theBois;
	public int firstNum = -1;
	public Transform firstPointVis;
	public GameObject cakeLineRender;
	public GameObject splatCake;
	private bool splatfix = false;
    private bool between (int low, int high, int x)
    {
        return (low < x && x < high);
    }

    private bool intersects(int x, int y, int a, int b)
    {
        return (between(x, y, a) != between(x, y, b));
    }

    private void Pass()
    {
		ShutDownTheBois();
		MCP.mcp.queuedScore = 1;
    }

    private void Fail()
	{
		ShutDownTheBois();
		MCP.mcp.queuedScore = -1;
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Wrench")
		{
			if (other.gameObject.GetComponent<WrenchHead1>().speed > 2.5f)
			{
				if (splatfix)
					return;
				splatfix = true;
				Instantiate(splatCake, transform.position, transform.rotation);
				Destroy(gameObject);
			}

		}
	}
	void ResetTheBois()
	{
		foreach(CakeTrigger boi in theBois)
		{
			boi.touched = false;
		}
		firstNum = -1;
	}
	void ShutDownTheBois()
	{
		foreach (CakeTrigger boi in theBois)
		{
			boi.gameObject.SetActive(false);
		}
	}
	public void AddNum(int whatNum, Transform visPoint)
	{
		if (firstNum == -1)
		{
			firstNum = whatNum;
			firstPointVis = visPoint;
		}
		else if (whatNum > firstNum + 1 || whatNum < firstNum - 1)
		{
			CakeLine lineo = Instantiate(cakeLineRender).GetComponent<CakeLine>();
			lineo.firstPoint = firstPointVis;
			lineo.secondPoint = visPoint;
			Cut(firstNum, whatNum);

		}
	}
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Cut(int end1, int end2)
    {
        switch (cutState) { // changed from state to cutState to fix compile error, not sure if correct
            case -1: // start state, just remember the first cut
                cutEndpoints[0] = end1 < end2 ? end1 : end2;
                cutEndpoints[1] = end1 < end2 ? end2 : end1;
                cutState = 0;
                break;

            case 0: // 
                cutEndpoints[2] = end1 < end2 ? end1 : end2;
                cutEndpoints[3] = end1 < end2 ? end2 : end1;
                if(intersects(cutEndpoints[0], cutEndpoints[1], cutEndpoints[2], cutEndpoints[3]))
                {
                    cutState = 2; // first two cuts intersect
                }
                else
                {
                    cutState = 1; // no intersection of first two cuts
                }
                break;

            case 1:
                cutEndpoints[4] = end1 < end2 ? end1 : end2;
                cutEndpoints[5] = end1 < end2 ? end2 : end1;
                if (!intersects(cutEndpoints[0], cutEndpoints[1], cutEndpoints[4], cutEndpoints[5]) &&
                    !intersects(cutEndpoints[2], cutEndpoints[3], cutEndpoints[4], cutEndpoints[5]))
                {
                    cutState = 3; // no intersections
                    Fail();
                }
                else if (intersects(cutEndpoints[0], cutEndpoints[1], cutEndpoints[4], cutEndpoints[5]) &&
                    intersects(cutEndpoints[2], cutEndpoints[3], cutEndpoints[4], cutEndpoints[5]))
                {
                    cutState = 5; // the third line intersects both of the first two
                    Pass();
                }
                else
                {
                    cutState = 4; // the third line intersects just one of the first two
                    Fail();
                }
                break;

            case 2:
                cutEndpoints[4] = end1 < end2 ? end1 : end2;
                cutEndpoints[5] = end1 < end2 ? end2 : end1;
                if (!intersects(cutEndpoints[0], cutEndpoints[1], cutEndpoints[4], cutEndpoints[5]) &&
                    !intersects(cutEndpoints[2], cutEndpoints[3], cutEndpoints[4], cutEndpoints[5]))
                {
                    cutState = 6; // third line intersects neither of the others
                    Fail();
                }
                else if (!intersects(cutEndpoints[0], cutEndpoints[1], cutEndpoints[4], cutEndpoints[5]) !=
                    !intersects(cutEndpoints[2], cutEndpoints[3], cutEndpoints[4], cutEndpoints[5]))
                {
                    cutState = 7; // third line intersects just one of the others
                    Pass();
                }
                else // all three lines intersect, but at the same place?
                {

                    if( cutEndpoints[1] - cutEndpoints[0] == 5 &&
                        cutEndpoints[3] - cutEndpoints[2] == 5 &&
                        cutEndpoints[5] - cutEndpoints[4] == 5
                    )
                    {
                        cutState = 9;
                        Pass();
                    }
                    else
                    {
                        cutState = 8;
                        Fail();
                    }
                }
                break;
		}
		ResetTheBois();

	}
}
