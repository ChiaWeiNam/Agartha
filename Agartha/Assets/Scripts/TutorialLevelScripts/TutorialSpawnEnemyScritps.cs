using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialSpawnEnemyScritps : MonoBehaviour 
{
	public GameObject spawnClone; 
	//public float spawnWait; 
	public int enemyCounter;
	public Transform[] spawnLocations; 
	public GameObject[] spawnPrefab; 
	public Button StartButton;
	public bool gameStart = false;
	public bool canDisplay;
	public int maxEnemy;
	public AudioSource source;
	public AudioClip buttonSound;

	public bool isRolangCanSpawn = false;
	public bool isWindHorseCanSpawn = false;
	public bool isYetiCanSpawn = false;

	public Button gameStartButton;
	public Sprite gameStartHover;
	public Sprite gameStartIdle;
	//public AudioSource source;
	//public AudioClip buttonSound;

	//public float startWait;

	void Awake()
	{
		//source = GameObject.FindGameObjectWithTag("SpawnEnemy").GetComponent<AudioSource>();
	}

	void Start()
	{
		maxEnemy = enemyCounter;
	}

	public void OnMouseDown ()
	{
		if (gameStart == false) 
		{
			isRolangCanSpawn = true;
			StartButton.GetComponent<Selectable>().interactable = false;
			SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_CLICKING);
			gameStart = true;
			//music.canPlay = true;
			StartButton.GetComponent<Image>().color = Color.white;
			GameObject.Find("ClickStart").GetComponent<Text>().enabled = false;
			GameObject.Find("MonsterSpawnHere").GetComponent<Text>().enabled = false;
		}
	}
	public void GameStartOnPointerEnter()
	{
		if(StartButton.GetComponent<Selectable>().interactable == true)
		{
			SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_HOVER);
			gameStartButton.image.overrideSprite = gameStartHover;
		}
	}
	public void GameStartOnPointerExit()
	{
		if(StartButton.GetComponent<Selectable>().interactable == true)
		{
			gameStartButton.image.overrideSprite = gameStartIdle;
		}
	}


	public void Update()
	{
		if(isRolangCanSpawn == true)
		{
			for (int i = 0; i < 1; i++)
			{
				spawnClone = Instantiate (spawnPrefab [0], spawnLocations [0].transform.position, Quaternion.identity) as GameObject;
				isRolangCanSpawn = false;
			}
		}

		if(isWindHorseCanSpawn == true)
		{
			for (int i = 0; i < 1; i++)
			{
				spawnClone = Instantiate (spawnPrefab [1], spawnLocations [1].transform.position, Quaternion.identity) as GameObject;
				isWindHorseCanSpawn = false;
			}
		}

		if(isYetiCanSpawn == true)
		{
			for (int i = 0; i < 1; i++)
			{
				spawnClone = Instantiate (spawnPrefab [2], spawnLocations [2].transform.position, Quaternion.identity) as GameObject;
				isYetiCanSpawn = false;
			}
		}
	}
}

