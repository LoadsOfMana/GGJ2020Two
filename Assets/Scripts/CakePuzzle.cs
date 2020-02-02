using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakePuzzle : MonoBehaviour
{
    private int[] cutEndpoints;
    private int cutNumber = 0;
    private int cutState = -1;

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
        
    }

    private void Fail()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
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

    }
}
