using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSpawner : MonoBehaviour
{
	public GameObject[] puzzles;
	public int currentPuzzle = 0;
    

    [ContextMenu("Spawn")]
	void SpawnNext()
	{
		Instantiate(puzzles[currentPuzzle], transform.position, transform.rotation);
		currentPuzzle++;
		if (currentPuzzle == puzzles.Length)
			currentPuzzle = 0;
	}

	private void Start()
	{
		SpawnNext();
	}
}
