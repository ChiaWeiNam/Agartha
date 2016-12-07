using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManagerScript02 : MonoBehaviour 
{
	public static bool isLevel02; 
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
	float wordDelayTimer = 0.0f;
	float wordDelayDuration = 1.5f;
	float switchSceneDelayTimer = 0.0f;
	float switchSceneDelayDuration = 3.0f;
	int oneTime;
	// Use this for initialization

	void Awake()
	{
		isLevel02 = true; 
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
			GameObject.Find("Level2").GetComponent<Text>().enabled = false;
		}

		if(spawnEnemy.enemyCounter <= 0)
		{
			switchSceneDelayTimer += Time.deltaTime;
			GameObject.Find("YouWin").GetComponent<Text>().enabled = true;

			if(switchSceneDelayTimer >= switchSceneDelayDuration)
			{
				GameObject.Find ("ChangeLevel").GetComponent<ChangeLevelScript>().loadLevel03 = true;
				GameObject.Find("YouWin").GetComponent<Text>().enabled = false;
				isLevel02 = false;
			}
		}

		if(spawnEnemy.gameStart == true && oneTime <= 0)
		{
			SoundManagerScript.Instance.PlayBGM(AudioClipID.BGM_LEVEL02);
			oneTime++;
		}
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
