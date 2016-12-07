using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoomRemainingScript : MonoBehaviour {

	public static int boomTrap;
	Text boomTrapText;

	void Awake()
	{
		boomTrapText = this.GetComponent<Text> ();
	}
	void Update () 
	{
		boomTrap = trapPrefabScript.boomCount;

		if(boomTrapText != null)
		{
			boomTrapText.text = "x" + boomTrap;
		}

	}
}
