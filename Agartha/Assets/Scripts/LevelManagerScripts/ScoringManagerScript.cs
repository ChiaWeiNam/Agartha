using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class ScoringManagerScript : MonoBehaviour 
{

	public static int scoreCount; 
	Text scoreText; 
	public static int trapCounterLeft;
	public static bool isExtraScoreAdded;
	public static bool isFinalScore;
	public int trapUsed;
	SpawnEnemy spawnEnemy;


	// Use this for initialization
	void Awake () 
	{
		scoreText = GetComponent<Text> (); 
		scoreCount = 0; 
		isExtraScoreAdded = false;
		isFinalScore = false;
		trapCounterLeft = 0;
	}

	void Start()
	{
		spawnEnemy = GameObject.FindGameObjectWithTag("SpawnEnemy").GetComponent<SpawnEnemy>();
		if(LevelManagerScript00B.isLevel00B == true)
		{
			trapCounterLeft = 4;
		}
		if(LevelManagerScript01.isLevel01 == true)
		{
			trapCounterLeft = 6;
		}
		if(LevelManagerScript02.isLevel02 == true)
		{
			trapCounterLeft = 9;
		}
		if(LevelManagerScript03.isLevel03 == true)
		{
			trapCounterLeft = 9;
		}
		if(LevelManagerScript04.isLevel04 == true)
		{
			trapCounterLeft = 9;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*if(trapCountDropOnSlot <= 0 && Slot.canLose == true)
		{
			TeleportScripts.isLose = true;
			TeleportScripts.whichWayLose = 2;
			Slot.canLose = false;
		}*/

		if( spawnEnemy.enemyCounter <= 0)
		{
			isExtraScoreAdded = true;
			if (isFinalScore == true)
			{
				isExtraScoreAdded = false;
			}
		}

		if( isExtraScoreAdded == true)
		{
			ExtraScore();
			isFinalScore = true;
		}

		isExtraScoreAdded = false;
		scoreText.text = "Scores: " + scoreCount; 
	}

	public void ExtraScore()
	{
		scoreCount += trapCounterLeft * 100;
	}
}
