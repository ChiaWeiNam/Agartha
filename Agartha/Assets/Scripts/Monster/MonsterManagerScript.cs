using UnityEngine;
using UnityEngine.UI; 
using System.Collections;
using UnityEngine.SceneManagement;

public class MonsterManagerScript : MonoBehaviour {

	int enemyCounter01;
	//int enemyCounter02;
	public int totalEnemyCounter;
	SpawnEnemy spawnEnemy;
	Text enemyText; 

	// Use this for initialization
	void Awake () 
	{
		spawnEnemy = GameObject.FindGameObjectWithTag("SpawnEnemy").GetComponent<SpawnEnemy>();
		enemyText = GetComponent<Text> (); 
		enemyCounter01 = spawnEnemy.enemyCounter;
	}

	// Update is called once per frame
	void Update ()
	{
		enemyCounter01 = spawnEnemy.enemyCounter;
		enemyText.text = "Enemy: " + enemyCounter01;
	}
}
