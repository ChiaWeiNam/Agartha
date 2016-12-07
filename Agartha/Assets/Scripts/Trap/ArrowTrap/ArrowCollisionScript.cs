using UnityEngine;
using System.Collections;

public class ArrowCollisionScript : MonoBehaviour 
{
	public float speed;
	public int scorePoints = 10; 
	SpawnEnemy spawnEnemy;
	int monsterHitCount;
	float comboTimer = 0.0f;
	float comboDuration = 1.0f;
	bool isCombo = false;

	public GameObject blood;
	float x;
	float y;

	// Use this for initialization
	void Start () 
	{
		spawnEnemy = GameObject.FindGameObjectWithTag("SpawnEnemy").GetComponent<SpawnEnemy>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (Vector3.down * Time.deltaTime * speed);

		if(isCombo == true)
		{
			comboTimer += Time.deltaTime;
			if(comboTimer >= comboDuration)
			{
				monsterHitCount = 0;
				isCombo = false;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.CompareTag("Floor"))
		{
			Destroy(this.gameObject);
		}

		if(other.CompareTag("Rolang") || other.CompareTag("SnowLion") || other.CompareTag("GDon") || other.CompareTag("WindHorse"))
		{
			x = other.transform.position.x;
			y = other.transform.position.y;
			Instantiate(blood, new Vector3 (x,y,0.0f), Quaternion.identity);
			isCombo = true;
			monsterHitCount++;
			ScoringManagerScript.scoreCount += scorePoints; 
			Destroy(other.gameObject);
			spawnEnemy.enemyCounter -= 1;
		}

		if(other.CompareTag("Yeti"))
		{
			other.GetComponent<YetiMonsterMovementScripts>().slowSpeed = 0.3f;
			other.GetComponent<YetiMonsterMovementScripts>().isSlowed = true;
			other.GetComponent<YetiMonsterMovementScripts>().slowDuration = 2.0f;
		}

		if(other.CompareTag("Garuda"))
		{
			other.GetComponent<GarudaMonsterMovementScipts>().slowSpeed = 0.0f;
			other.GetComponent<GarudaMonsterMovementScipts>().isSlowed = true;
			other.GetComponent<GarudaMonsterMovementScipts>().slowDuration = 2.0f;
		}

		if(other.CompareTag("Gyalpo"))
		{
			other.GetComponent<GyalpoMonsterMovementScripts>().slowSpeed = 0.1f;
			other.GetComponent<GyalpoMonsterMovementScripts>().isSlowed = true;
			other.GetComponent<GyalpoMonsterMovementScripts>().slowDuration = 2.0f;
		}
	}
}
