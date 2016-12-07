using UnityEngine;
using System.Collections;

public class FireCollisionScript : MonoBehaviour 
{
	float delayTimer = 0.0f;
	float delayDuration = 3.0f;
	public int scorePoints = 10;     // Player gets 10 points 
	SpawnEnemy spawnEnemy;
	public GameObject deadFire;
	float x;
	float y;
	int monsterHitCount;
	float comboTimer = 0.0f;
	float comboDuration = 1.0f;
	bool isCombo = false;

	/*public GameObject blood;
	float x2;
	float y2;*/

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
		if(other.CompareTag("Rolang") || other.CompareTag("Garuda") || other.CompareTag("WindHorse"))
		{
			/*x2 = other.transform.position.x;
			y2 = other.transform.position.y;
			Instantiate(blood, new Vector3 (x,y,0.0f), Quaternion.identity);*/
			x = this.transform.position.x;
			y = this.transform.position.y;
			Instantiate(deadFire,new Vector3(x,y,0.0f), Quaternion.identity);
			isCombo = true;
			monsterHitCount++;
			Destroy(other.gameObject);
			ScoringManagerScript.scoreCount += scorePoints; 
			spawnEnemy.enemyCounter -= 1;
		}

		if(other.CompareTag("GDon"))
		{
			other.GetComponent<GDonMonsterMovementScripts>().slowSpeed = other.GetComponent<GDonMonsterMovementScripts>().speed + 0.2f;
			other.GetComponent<GDonMonsterMovementScripts>().isSlowed = true;
			other.GetComponent<GDonMonsterMovementScripts>().slowDuration = 3.0f;
		}

		if(other.CompareTag("Gyalpo"))
		{
			other.GetComponent<GyalpoMonsterMovementScripts>().slowSpeed = other.GetComponent<GyalpoMonsterMovementScripts>().speed + 0.2f;
			other.GetComponent<GyalpoMonsterMovementScripts>().isSlowed = true;
			other.GetComponent<GyalpoMonsterMovementScripts>().slowDuration = 3.0f;
		}
	}
}
