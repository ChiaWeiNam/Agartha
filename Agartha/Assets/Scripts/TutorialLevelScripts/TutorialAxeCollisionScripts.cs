using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutorialAxeCollisionScripts : MonoBehaviour 
{
	float delayTimer = 0.0f;
	float delayDuration = 3.0f;
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
			GameObject.Find ("ChangeLevel").GetComponent<ChangeLevelScript>().loadLevel00B = true;
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.CompareTag("TutorialYeti"))
		{
			Destroy(other.gameObject);
			GameObject.Find ("Real03").GetComponent<Text> ().enabled = true; 
			ScoringManagerScript.scoreCount += scorePoints;
			spawnEnemy.enemyCounter -= 1;
		}
	}
}
