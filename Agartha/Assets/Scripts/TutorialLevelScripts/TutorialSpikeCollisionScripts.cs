using UnityEngine;
using System.Collections;

public class TutorialSpikeCollisionScripts : MonoBehaviour 
{
	float delayTimer = 0.0f;
	float delayDuration = 1.0f;
	public int scorePoints = 10;     // Player gets 10 points 
	TutorialSpawnEnemyScritps spawnEnemy;

	void Start () 
	{
		spawnEnemy = GameObject.FindGameObjectWithTag("TutorialSpawnEnemy").GetComponent<TutorialSpawnEnemyScritps>();
	}

	void Update () 
	{
		delayTimer += Time.deltaTime;

		if(delayTimer >= delayDuration)
		{
			delayTimer = 0.0f;
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.CompareTag("TutorialRolang"))
		{
			Destroy(other.gameObject);
			ScoringManagerScript.scoreCount += scorePoints; 
			spawnEnemy.enemyCounter -= 1;
			spawnEnemy.isWindHorseCanSpawn = true;
		}
	}
}
