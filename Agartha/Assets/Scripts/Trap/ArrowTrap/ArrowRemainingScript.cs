using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ArrowRemainingScript : MonoBehaviour 
{
	public static int arrowTrap;
	Text arrowTrapText;

	void Awake()
	{
		arrowTrapText = this.GetComponent<Text>();
	}
		
	// Update is called once per frame
	void Update () 
	{
		arrowTrap = trapPrefabScript.arrowCount; 

		if(arrowTrapText != null)
		{
			arrowTrapText.text = "x" + arrowTrap;
		}
	}
}
