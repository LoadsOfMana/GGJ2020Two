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
	public TMPro.TextMeshPro scoreText;
	public Stage[] stages;
	private int whichStage = 0;
	public bool fixTheDamnPlate = false;
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
		if (Input.GetKeyDown(KeyCode.P))
			SkipPuzzle();
        if(queuedScore != 0 && mustClearList.Count == 0)
		{
			if(queuedScore > 0)
				currentScore += queuedScore;
			if (queuedScore == -1)
				queuedScore = 0;
			scoreText.text = currentScore + "";
			queuedScore = 0;
			NextPuzzle();
		}
    }
	void SkipPuzzle()
	{
		for (int i = mustClearList.Count; i >0; i--)
		{
			Destroy(mustClearList[i - 1]);
		}
		mustClearList.Clear();
		queuedScore = 1;
	}
	void NextPuzzle()
	{
		puzzleSpawn.SpawnNext(whichStage);
		imgDisplay.sprite = stages[whichStage].sprite;
		textDisplay.text = stages[whichStage].text;
		monitorSound.Play();
		whichStage++;
		if (whichStage >= stages.Length)
			whichStage = 0;
	}
}

[System.Serializable]
public class Stage
{
	public string name;
	public Sprite sprite;
	public string text;
}