using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialSlotScripts : MonoBehaviour 
{
	TutorialSpawnEnemyScritps checkStart;

	// Use this for initialization
	void Start () 
	{
		checkStart = GameObject.FindGameObjectWithTag("TutorialSpawnEnemy").GetComponent<TutorialSpawnEnemyScritps>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(checkStart.gameStart == true)
		{
			this.GetComponent<Image>().enabled = false;
		}
	}
}
