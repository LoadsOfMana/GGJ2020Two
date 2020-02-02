using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCP : MonoBehaviour
{
	public static MCP mcp;
	public List<GameObject> mustClearList;
	public Transform player;
	public float queuedScore;
	public float currentScore;
	public PuzzleSpawner puzzleSpawn;
	public TMPro.TextMeshPro textDisplay;
	public SpriteRenderer imgDisplay;
	public AudioSource monitorSound;
	public Stage[] stages;
	private int whichStage = 0;
	// Start is called before the first frame update
	void Awake()
    {
		mcp = this;
    }
	private void Start()
	{
		NextPuzzle();
	}

	// Update is called once per frame
	void Update()
    {
        if(queuedScore != 0 && mustClearList.Count == 0)
		{
			currentScore += queuedScore;
			queuedScore = 0;
			NextPuzzle();
		}
    }
	void NextPuzzle()
	{
		puzzleSpawn.SpawnNext(whichStage);
		imgDisplay.sprite = stages[whichStage].sprite;
		textDisplay.text = stages[whichStage].text;
		monitorSound.Play();
		whichStage++;
	}
}

[System.Serializable]
public class Stage
{
	public string name;
	public Sprite sprite;
	public string text;
}