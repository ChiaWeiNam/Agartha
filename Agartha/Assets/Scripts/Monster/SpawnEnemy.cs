using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour 
{
	public GameObject spawnClone; 
	public float spawnWait; 
	public int enemyCounter;
	public Transform[] spawnLocations; 
	public GameObject[] spawnPrefab; 
	public Button StartButton;
	public bool gameStart = false;
	public bool canDisplay;
	public int maxEnemy;
	public AudioSource source;
	public AudioClip buttonSound;
	bool level04FirstWave = false;

	public Button gameStartButton;
	public Sprite gameStartIdle;
	public Sprite gameStartHover;

	bool yeti;

	//public float startWait;

	void Awake()
	{
		source = GameObject.FindGameObjectWithTag("SpawnEnemy").GetComponent<AudioSource>();
	}

	void Start()
	{
		maxEnemy = enemyCounter;
	}

	public void OnMouseDown ()
	{
		if (gameStart == false) 
		{
			if(LevelManagerScript00B.isLevel00B == true)
			{ 
				StartCoroutine (SpawnEnemyLevel00B());
				StartButton.GetComponent<Selectable>().interactable = false;
				SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_CLICKING);
				gameStart = true;
				//music.canPlay = true;
				StartButton.GetComponent<Image>().color = Color.white;
			}

			if(LevelManagerScript01.isLevel01 == true)
			{ 
				StartCoroutine (SpawnEnemyLevel01());
				StartButton.GetComponent<Selectable>().interactable = false;
				SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_CLICKING);
				gameStart = true;
				//music.canPlay = true;
				StartButton.GetComponent<Image>().color = Color.white;
			}

			if (LevelManagerScript02.isLevel02 == true) 
			{
				StartCoroutine (SpawnEnemyLevel02());
				StartButton.GetComponent<Selectable>().interactable = false;
				SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_CLICKING);
				gameStart = true;
				//music.canPlay = true;
				StartButton.GetComponent<Image>().color = Color.white;
			}

			if(LevelManagerScript03.isLevel03 == true)
			{
				StartCoroutine(SpawnEnemyLevel03());
				StartButton.GetComponent<Selectable>().interactable = false;
				SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_CLICKING);
				gameStart = true;
				StartButton.GetComponent<Image>().color = Color.white;
			}

			if(LevelManagerScript04.isLevel04 == true)
			{
				StartCoroutine(SpawnEnemyLevel04());
				StartButton.GetComponent<Selectable>().interactable = false;
				SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_CLICKING);
				gameStart = true;
				StartButton.GetComponent<Image>().color = Color.white;
			}
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
		
	}


	//! Level 00B  
	IEnumerator SpawnEnemyLevel00B()
	{
		int rolangSpawn = 3; 
		int windhorseSpawn = 1; 
		int yetiSpawn = 1;

		for (int i = 0; i < rolangSpawn; i++)
		{
			spawnClone = Instantiate (spawnPrefab [0], spawnLocations [0].transform.position, Quaternion.identity) as GameObject;
			yield return new WaitForSeconds (spawnWait); 
		}

		for (int i = 0; i < windhorseSpawn; i++)
		{
			spawnClone = Instantiate (spawnPrefab [1], spawnLocations [1].transform.position, Quaternion.identity) as GameObject;
			yield return new WaitForSeconds (spawnWait); 
		}

		for (int i = 0; i < yetiSpawn; i++)
		{
			spawnClone = Instantiate (spawnPrefab [2], spawnLocations [2].transform.position, Quaternion.identity) as GameObject;
			yield return new WaitForSeconds (spawnWait); 
		}
	}

	//! Level 01 
	IEnumerator SpawnEnemyLevel01()
	{
		int rolangSpawn = 4; 
		int yetiSpawn = 1; 
		int snowlionSpawn = 2;

		for (int i = 0; i < rolangSpawn; i++)
		{
			spawnClone = Instantiate (spawnPrefab [0], spawnLocations [0].transform.position, Quaternion.identity) as GameObject;
			yield return new WaitForSeconds (spawnWait); 
		}

		for (int i = 0; i < yetiSpawn; i++)
		{
			spawnClone = Instantiate (spawnPrefab [1], spawnLocations [1].transform.position, Quaternion.identity) as GameObject;
			yield return new WaitForSeconds (spawnWait); 
		}

		for (int i = 0; i < snowlionSpawn; i++)
		{
			spawnClone = Instantiate (spawnPrefab [2], spawnLocations [2].transform.position, Quaternion.identity) as GameObject;
			yield return new WaitForSeconds (spawnWait); 
		}
	}

	//! Level 02
	IEnumerator SpawnEnemyLevel02()
	{
		int rolangSpawn = 3;
		int garudaSpawn = 1;
		int snowLionSpawn = 1;
		int demonicRolangSpawn = 3;
		int snowLionSpawn2 = 1;
		int yetiSpawn = 1;
		int garudaSpawn2 = 1;

		for (int i = 0; i < rolangSpawn; i++)
		{
			spawnClone = Instantiate (spawnPrefab [1], spawnLocations [1].transform.position, Quaternion.identity) as GameObject;
			yield return new WaitForSeconds (spawnWait); 
		}

		for (int i = 0; i < garudaSpawn; i++)
		{
			spawnClone = Instantiate (spawnPrefab [0], spawnLocations [0].transform.position, Quaternion.identity) as GameObject;
			yield return new WaitForSeconds (spawnWait); 
		}

		for (int i = 0; i < snowLionSpawn; i++)
		{
			spawnClone = Instantiate (spawnPrefab [4], spawnLocations [4].transform.position, Quaternion.identity) as GameObject;
			yield return new WaitForSeconds (spawnWait); 
		}

		for (int i = 0; i < demonicRolangSpawn; i++)
		{
			spawnClone = Instantiate (spawnPrefab [3], spawnLocations [3].transform.position, Quaternion.identity) as GameObject;
			yield return new WaitForSeconds (spawnWait); 
		}

		for (int i = 0; i < snowLionSpawn2; i++)
		{
			spawnClone = Instantiate (spawnPrefab [4], spawnLocations [4].transform.position, Quaternion.identity) as GameObject;
			yield return new WaitForSeconds (spawnWait); 
		}

		for (int i = 0; i < yetiSpawn; i++)
		{
			spawnClone = Instantiate (spawnPrefab [2], spawnLocations [2].transform.position, Quaternion.identity) as GameObject;
			yield return new WaitForSeconds (spawnWait); 
		}

		for (int i = 0; i < garudaSpawn2; i++)
		{
			spawnClone = Instantiate (spawnPrefab [0], spawnLocations [0].transform.position, Quaternion.identity) as GameObject;
			yield return new WaitForSeconds (spawnWait); 
		}
	}

	//!Level03
	IEnumerator SpawnEnemyLevel03()
	{
		int rolangSpawnDown = 3;
		int windHorseSpawnDown = 1;
		int gyalpoSpawnDown = 1;
		int garudaSpawnDown = 1;
		int gdonSpawnDown = 1;
		int rolangSpawnUp = 3;
		int gyalpoSpawnUp = 1;
		int garudaSpawnUp = 1;
		int gdonSpawnUp = 1;
		bool isFirstWaveEnd = false;

		if(isFirstWaveEnd == false)
		{
			for (int i = 0; i < rolangSpawnDown; i++)
			{
				spawnClone = Instantiate (spawnPrefab [0], spawnLocations [0].transform.position, Quaternion.identity) as GameObject;
				yield return new WaitForSeconds (spawnWait); 
			}

			for (int i = 0; i < windHorseSpawnDown; i++)
			{
				spawnClone = Instantiate (spawnPrefab [1], spawnLocations [1].transform.position, Quaternion.identity) as GameObject;
				yield return new WaitForSeconds (spawnWait); 
			}

			for (int i = 0; i < gyalpoSpawnDown; i++)
			{
				spawnClone = Instantiate (spawnPrefab [2], spawnLocations [2].transform.position, Quaternion.identity) as GameObject;
				yield return new WaitForSeconds (spawnWait); 
			}

			for (int i = 0; i < garudaSpawnDown; i++)
			{
				spawnClone = Instantiate (spawnPrefab [3], spawnLocations [3].transform.position, Quaternion.identity) as GameObject;
				yield return new WaitForSeconds (spawnWait); 
			}

			for (int i = 0; i <  gdonSpawnDown; i++)
			{
				spawnClone = Instantiate (spawnPrefab [4], spawnLocations [4].transform.position, Quaternion.identity) as GameObject;
				yield return new WaitForSeconds (5.0f);
				isFirstWaveEnd = true;
			}
		}

		if(isFirstWaveEnd == true)
		{
			for (int i = 0; i < rolangSpawnUp; i++)
			{
				spawnClone = Instantiate (spawnPrefab [0], spawnLocations [5].transform.position, Quaternion.identity) as GameObject;
				yield return new WaitForSeconds (spawnWait); 
			}

			for (int i = 0; i < gyalpoSpawnUp; i++)
			{
				spawnClone = Instantiate (spawnPrefab [2], spawnLocations [6].transform.position, Quaternion.identity) as GameObject;
				yield return new WaitForSeconds (spawnWait); 
			}

			for (int i = 0; i < garudaSpawnUp; i++)
			{
				spawnClone = Instantiate (spawnPrefab [3], spawnLocations [7].transform.position, Quaternion.identity) as GameObject;
				yield return new WaitForSeconds (spawnWait); 
			}

			for (int i = 0; i < gdonSpawnUp; i++)
			{
				spawnClone = Instantiate (spawnPrefab [4], spawnLocations [8].transform.position, Quaternion.identity) as GameObject;
				yield return new WaitForSeconds (spawnWait); 
			}
		}

	}

	//!Level04
	IEnumerator SpawnEnemyLevel04()
	{
		int yetiSpawnLeft = 1;
		int garudaSpawnLeft = 1;
		int rolangSpawnLeft = 3;
		int gdonSpawnLeft = 2;
		int gyalpoSpawnLeft = 1;
		int gdonSpawnRight = 3;
		int rolangSpawnRight = 2;
		int garudaSpawnRight = 1;
		int gyalpoSpawnRight = 1;

		YetiMonsterMovementScripts.YetiID = 0;
		GarudaMonsterMovementScipts.GarudaID = 0;
		RolangMonsterMovementScritps.RolangID = 0;
		GDonMonsterMovementScripts.GdonID = 0;
		GyalpoMonsterMovementScripts.GyalpoID = 0;

		if(level04FirstWave == false)
		{
			for (int i = 0; i < yetiSpawnLeft; i++)
			{
				YetiMonsterMovementScripts.YetiID ++;
				spawnClone = Instantiate (spawnPrefab [0], spawnLocations [0].transform.position, Quaternion.identity) as GameObject;
				yield return new WaitForSeconds (spawnWait); 
			}

			for (int i = 0; i < garudaSpawnLeft; i++)
			{
				GarudaMonsterMovementScipts.GarudaID ++;
				spawnClone = Instantiate (spawnPrefab [1], spawnLocations [1].transform.position, Quaternion.identity) as GameObject;
				yield return new WaitForSeconds (spawnWait); 
			}

			for (int i = 0; i < rolangSpawnLeft; i++)
			{
				RolangMonsterMovementScritps.RolangID ++;
				spawnClone = Instantiate (spawnPrefab [2], spawnLocations [2].transform.position, Quaternion.identity) as GameObject;
				yield return new WaitForSeconds (spawnWait); 
			}

			for (int i = 0; i < gdonSpawnLeft; i++)
			{
				GDonMonsterMovementScripts.GdonID ++;
				spawnClone = Instantiate (spawnPrefab [3], spawnLocations [3].transform.position, Quaternion.identity) as GameObject;
				yield return new WaitForSeconds (spawnWait); 
			}

			for (int i = 0; i <  gyalpoSpawnLeft; i++)
			{
				GyalpoMonsterMovementScripts.GyalpoID++;
				spawnClone = Instantiate (spawnPrefab [4], spawnLocations [4].transform.position, Quaternion.identity) as GameObject;
				yield return new WaitForSeconds (5.0f);
				level04FirstWave = true;
			}
		}

		if(level04FirstWave == true)
		{
			for (int i = 0; i < gdonSpawnRight; i++)
			{
				GDonMonsterMovementScripts.GdonID ++;
				spawnClone = Instantiate (spawnPrefab [3], spawnLocations [5].transform.position, Quaternion.identity) as GameObject;
				yield return new WaitForSeconds (spawnWait); 
			}

			for (int i = 0; i < rolangSpawnRight; i++)
			{
				RolangMonsterMovementScritps.RolangID ++;
				spawnClone = Instantiate (spawnPrefab [2], spawnLocations [6].transform.position, Quaternion.identity) as GameObject;
				yield return new WaitForSeconds (spawnWait); 
			}

			for (int i = 0; i < garudaSpawnRight; i++)
			{
				GarudaMonsterMovementScipts.GarudaID ++;
				spawnClone = Instantiate (spawnPrefab [1], spawnLocations [7].transform.position, Quaternion.identity) as GameObject;
				yield return new WaitForSeconds (spawnWait); 
			}

			for (int i = 0; i < gyalpoSpawnRight; i++)
			{
				GyalpoMonsterMovementScripts.GyalpoID ++;
				spawnClone = Instantiate (spawnPrefab [4], spawnLocations [8].transform.position, Quaternion.identity) as GameObject;
				yield return new WaitForSeconds (spawnWait); 
			}
		}
	}

}

