using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LogRemainingScript : MonoBehaviour 
{
	public static int logTrap;
	Text logTrapText;

	void Awake()
	{
		logTrapText = this.GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		logTrap = trapPrefabScript.logCount; 

		if(logTrapText != null)
		{
			logTrapText.text = "x" + logTrap;
		}
	}
}
