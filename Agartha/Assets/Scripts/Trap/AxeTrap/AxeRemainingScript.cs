using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AxeRemainingScript : MonoBehaviour 
{
	public static int axeTrap;
	Text axeTrapText;

	void Awake()
	{
		axeTrapText = this.GetComponent<Text>();
	}
		
	// Update is called once per frame
	void Update () 
	{
		axeTrap = trapPrefabScript.axeCount;

		if(axeTrapText != null)
		{
			axeTrapText.text = "x" + axeTrap;
		}
	}
}
