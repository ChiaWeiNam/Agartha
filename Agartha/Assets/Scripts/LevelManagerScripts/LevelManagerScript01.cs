using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManagerScript01 : MonoBehaviour 
{
	public static bool isLevel01; 
	private static LevelManagerScript01 mInstance;

	public static LevelManagerScript01 Instance
	{
		get
		{
			if(mInstance == null)
			{
				GameObject tempObject = GameObject.FindGameObjectWithTag ("LevelManager");

				if(tempObject == null)
				{
					GameObject obj = new GameObject("_LevelManager");
					mInstance = obj.AddComponent<LevelManagerScript01>();
					obj.tag = "LevelManager";
				}
				else
				{
					mInstance = tempObject.GetComponent<LevelManagerScript01>();
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
	public GameObject Level1;

	int oneTime;

	void Awake()
	{
		isLevel01 = true; 
	}

	// Use this for initialization
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
			GameObject.Find("Level1").GetComponent<Text>().enabled = false;
		}		

		if(spawnEnemy.enemyCounter <= 0)
		{
			switchSceneDelayTimer += Time.deltaTime;
			GameObject.Find("YouWin").GetComponent<Text>().enabled = true;

			if(switchSceneDelayTimer >= switchSceneDelayDuration)
			{
				GameObject.Find ("ChangeLevel").GetComponent<ChangeLevelScript>().loadLevel02 = true;
				GameObject.Find("YouWin").GetComponent<Text>().enabled = false;
				isLevel01 = false; 
			}
		}

		if(spawnEnemy.gameStart == true && oneTime <= 0)
		{
			SoundManagerScript.Instance.PlayBGM(AudioClipID.BGM_LEVEL00_01);
			oneTime++;
		}
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
