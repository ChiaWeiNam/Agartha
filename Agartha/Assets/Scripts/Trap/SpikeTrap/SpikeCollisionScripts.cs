using UnityEngine;
using System.Collections;

public class SpikeCollisionScripts : MonoBehaviour 
{
	float delayTimer = 0.0f;
	float delayDuration = 2.0f;
	public int scorePoints = 10;     // Player gets 10 points 
	SpawnEnemy spawnEnemy;
	int monsterHitCount;
	float comboTimer = 0.0f;
	float comboDuration = 1.0f;
	bool isCombo = false;
	public GameObject blood;
	float x;
	float y;

	void Start () 
	{
		spawnEnemy = GameObject.FindGameObjectWithTag("SpawnEnemy").GetComponent<SpawnEnemy>();
	}
	
	void Update () 
	{
		delayTimer += Time.deltaTime;

		if(delayTimer >= delayDuration)
		{
			delayTimer = 0.0f;
			Destroy(this.gameObject);
		}


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
		if(other.CompareTag("Rolang") || other.CompareTag("SnowLion") || other.CompareTag("GDon"))
		{
			x = other.transform.position.x;
			y = other.transform.position.y;
			Instantiate(blood, new Vector3 (x,y,0.0f), Quaternion.identity);
			isCombo = true;
			monsterHitCount++;
			Destroy(other.gameObject);
			ScoringManagerScript.scoreCount += scorePoints * monsterHitCount; 
			spawnEnemy.enemyCounter -= 1;
		}

		if(other.CompareTag("Yeti"))
		{
			other.GetComponent<YetiMonsterMovementScripts>().slowSpeed = 0.3f;
			other.GetComponent<YetiMonsterMovementScripts>().isSlowed = true;
			other.GetComponent<YetiMonsterMovementScripts>().slowDuration = 2.0f;
		}

		if(other.CompareTag("Gyalpo"))
		{
			other.GetComponent<GyalpoMonsterMovementScripts>().slowSpeed = 0.1f;
			other.GetComponent<GyalpoMonsterMovementScripts>().isSlowed = true;
			other.GetComponent<GyalpoMonsterMovementScripts>().slowDuration = 2.0f;
		}
	}
}
