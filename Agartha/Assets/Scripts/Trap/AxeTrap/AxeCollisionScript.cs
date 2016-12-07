using UnityEngine;
using System.Collections;

public class AxeCollisionScript : MonoBehaviour 
{
	float delayTimer = 0.0f;
	float delayDuration = 5.0f;
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
		if(other.CompareTag("Yeti") || other.CompareTag("Garuda") || other.CompareTag("Gyalpo") || other.CompareTag("WindHorse"))
		{
			x = other.transform.position.x;
			y = other.transform.position.y;
			Instantiate(blood, new Vector3 (x,y,0.0f), Quaternion.identity);
			isCombo = true;
			monsterHitCount++;
			Destroy(other.gameObject);
			ScoringManagerScript.scoreCount += scorePoints;
			spawnEnemy.enemyCounter -= 1;
		}
	}
}
