using UnityEngine;
using System.Collections;

public class ExplosionCollisionScripts : MonoBehaviour 
{
	float delayTimer = 0.0f;
	float delayDuration = 2.0f;
	public int scorePoints = 10;     // Player gets 10 points 
	SpawnEnemy spawnEnemy;
	int monsterHitCount;
	float comboTimer = 0.0f;
	float comboDuration = 1.0f;
	bool isCombo = false;


	// Use this for initialization
	void Start () 
	{
		spawnEnemy = GameObject.FindGameObjectWithTag("SpawnEnemy").GetComponent<SpawnEnemy>();
	}
	
	// Update is called once per frame
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
		if(other.CompareTag("Rolang") || other.CompareTag("SnowLion") || other.CompareTag("GDon") || other.CompareTag("Yeti") || other.CompareTag("Gyalpo") || other.CompareTag("Garuda") || other.CompareTag("WindHorse"))
		{
			isCombo = true;
			monsterHitCount++;
			Destroy(other.gameObject);
			ScoringManagerScript.scoreCount += scorePoints * monsterHitCount; 
			spawnEnemy.enemyCounter -= 1;
		}
	}
}
