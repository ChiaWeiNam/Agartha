using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManagerScript00B : MonoBehaviour 
{
	public static bool isLevel00B; 
	//float loseTimer,RestartTimer = 0.0f;
	//float loseDuration = 2.0f;
	//float RestartDuration = 0.5f;
	private static LevelManagerScript02 mInstance;

	public static LevelManagerScript02 Instance
	{
		get
		{
			if(mInstance == null)
			{
				GameObject tempObject = GameObject.FindGameObjectWithTag ("LevelManager");

				if(tempObject == null)
				{
					GameObject obj = new GameObject("_LevelManager");
					mInstance = obj.AddComponent<LevelManagerScript02>();
					obj.tag = "LevelManager";
				}
				else
				{
					mInstance = tempObject.GetComponent<LevelManagerScript02>();
				}
			}
			return mInstance; 
		}
	}

	SpawnEnemy spawnEnemy;
	float switchSceneDelayTimer = 0.0f;
	float switchSceneDelayDuration = 3.0f;
	public bool isExtraScoreAdded;
	public static int totalTrapUnitLeft;
	// Use this for initialization
	int oneTime;

	void Awake()
	{
		isLevel00B = true; 
		isExtraScoreAdded = false;
		totalTrapUnitLeft = 0;
	}
	void Start () 
	{
		GameObject.Find("Fading").GetComponent<Fading> ().OnLevelWasLoaded ();
		spawnEnemy = GameObject.FindGameObjectWithTag("SpawnEnemy").GetComponent<SpawnEnemy>();
		oneTime = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(spawnEnemy.enemyCounter <= 0)
		{
			ExtraScore();
			//GameObject.Find("ScoreText").GetComponent<ScoringManagerScript>().isExtraScoreAdded = true;

			switchSceneDelayTimer += Time.deltaTime;
			GameObject.Find("YouWin").GetComponent<Text>().enabled = true;
			GameObject.Find ("VictoryTheme").GetComponent<AudioSource> ().enabled = true;

			if(switchSceneDelayTimer >= switchSceneDelayDuration)
			{
				GameObject.Find ("ChangeLevel").GetComponent<ChangeLevelScript>().loadLevel01 = true;
				GameObject.Find("YouWin").GetComponent<Text>().enabled = false;
				GameObject.Find ("VictoryTheme").GetComponent<AudioSource> ().enabled = false;
				isLevel00B = false;
			}
		}

		/*if (ScoringManagerScript.trapCountDropOnSlot != 0) 
		{
			if (ScoringManagerScript.trapCounterLeft == 0 && spawnEnemy.enemyCounter != 0 && spawnEnemy.gameStart == true) {
				loseTimer += Time.deltaTime;
				GameObject.Find ("TrapFinished").GetComponent<Text> ().enabled = true;
				if (loseTimer >= loseDuration) {
					GameObject.Find ("TrapFinished").GetComponent<Text> ().enabled = false;
					RestartTimer += Time.deltaTime;

					if (RestartTimer >= RestartDuration) {
						SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
					}
				}
			}
		}*/

		if (spawnEnemy.gameStart == true && oneTime <= 0 ) 
		{
			SoundManagerScript.Instance.PlayBGM(AudioClipID.BGM_LEVEL00_01);
			oneTime ++;
		}
	}

	public void ExtraScore()
	{
		if(isExtraScoreAdded == false)
		{
			ScoringManagerScript.scoreCount += totalTrapUnitLeft * 100;
			isExtraScoreAdded = true;
		}

		isExtraScoreAdded = true;
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

}
