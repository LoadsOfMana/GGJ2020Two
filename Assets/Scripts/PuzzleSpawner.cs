using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSpawner : MonoBehaviour
{
	public GameObject[] puzzles;
    

    [ContextMenu("Spawn")]
	public void SpawnNext(int which)
	{
		Instantiate(puzzles[which], transform.position, transform.rotation);
	}

}
