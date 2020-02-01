using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public delegate void onScoreHandler(); // xxx revisit, easy plan won't work

public class PuzzleWithOutcome: MonoBehaviour
{
    public int outcomeState;
    public int[] scores;
    public AudioClip[] sounds;
    public string[] messages;
    // public onScoreHandler onScore();
}

/* HOW THIS SHOULD WORK:
 * For each possible outcome, assign an outcomeState value: for a simple
 * pass/fail test, let's say fail==0 and pass==1. Then, put the score for a
 * failed test at scores[0] and for a passed test at scores[1], and so on
 * for the other arrays. 
 * 
 * Then, make onScore do any puzzle-specific logic
 * by inspecting the value of outcomeState. xxx once we figure out how to make
 * the delegation work easily.
 * 
 * Once that's all done, we destroy the puzzle's GameObjects.
 */