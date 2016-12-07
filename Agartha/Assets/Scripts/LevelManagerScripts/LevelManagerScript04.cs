using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManagerScript04 : MonoBehaviour 
{
	public static bool isLevel04; 
	private static LevelManagerScript04 mInstance;

	public static LevelManagerScript04 Instance
	{
		get
		{
			if(mInstance == null)
			{
				GameObject tempObject = GameObject.FindGameObjectWithTag ("LevelManager");

				if(tempObject == null)
				{
					GameObject obj = new GameObject("_LevelManager");
					mInstance = obj.AddComponent<LevelManagerScript04>();
					obj.tag = "LevelManager";
				}
				else
				{
					mInstance = tempObject.GetComponent<LevelManagerScript04>();
				}
			}
			return mInstance; 
		}
	}

	SpawnEnemy spawnEnemy;
	float wordDelayTimer = 0.0f;
	float wordDelayDuration = 1.5f;
	float switchSceneDelayTimer = 0.0f;
	float switchSceneDelayDuration = 3.0f;
	// Use this for initialization

	int oneTime;

	void Awake()
	{
		isLevel04 = true; 
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
		wordDelayTimer += Time.deltaTime;

		if(wordDelayTimer >= wordDelayDuration)
		{
			GameObject.Find("Level4").GetComponent<Text>().enabled = false;
		}

		if(spawnEnemy.enemyCounter <= 0)
		{
			switchSceneDelayTimer += Time.deltaTime;
			GameObject.Find("YouWin").GetComponent<Text>().enabled = true;
			GameObject.Find("Thanks").GetComponent<Text>().enabled = true;

			if(switchSceneDelayTimer >= switchSceneDelayDuration)
			{
				GameObject.Find ("ChangeLevel").GetComponent<ChangeLevelScript>().loadMainMenu = true;
				GameObject.Find("YouWin").GetComponent<Text>().enabled = false;
				GameObject.Find("Thanks").GetComponent<Text>().enabled = false;
				isLevel04 = false;
			}
		}

		if(spawnEnemy.gameStart == true && oneTime <= 0)
		{
			SoundManagerScript.Instance.PlayBGM(AudioClipID.BGM_LEVEL03_04);
			oneTime ++;
		}
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
