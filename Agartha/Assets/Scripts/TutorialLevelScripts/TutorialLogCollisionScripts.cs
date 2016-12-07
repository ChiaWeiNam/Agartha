using UnityEngine;
using System.Collections;

public class TutorialLogCollisionScripts : MonoBehaviour 
{
	public float speed = 2.5f;
	public int scorePoints = 10; 
	TutorialSpawnEnemyScritps spawnEnemy;

	// Use this for initialization
	void Start () 
	{
		spawnEnemy = GameObject.FindGameObjectWithTag("TutorialSpawnEnemy").GetComponent<TutorialSpawnEnemyScritps>();
	}

	// Update is called once per frame
	void Update () 
	{
		transform.Translate (Vector3.down * Time.deltaTime * speed);
	}

	void OnTriggerEnter2D (Collider2D other)
	{

		if(other.CompareTag("Floor"))
		{
			Destroy(this.gameObject);
		}

		if(other.CompareTag("TutorialWindHorse"))
		{
			ScoringManagerScript.scoreCount += scorePoints; 
			Destroy(other.gameObject);
			spawnEnemy.enemyCounter -= 1;
			spawnEnemy.isYetiCanSpawn = true;
		}

		/*if(other.CompareTag("Yeti"))
		{
			other.GetComponent<YetiMonsterMovementScripts>().slowSpeed = 0.0f;
			other.GetComponent<YetiMonsterMovementScripts>().isSlowed = true;
			other.GetComponent<YetiMonsterMovementScripts>().slowDuration = 2.0f;
		}*/
	}
}
