using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FireRemainingScript : MonoBehaviour 
{
	public static int fireTrap;
	Text fireTrapText;

	void Awake()
	{
		fireTrapText = this.GetComponent<Text> ();
	}

	void Update () 
	{
		fireTrap = trapPrefabScript.fireCount;

		if(fireTrapText != null)
		{
			fireTrapText.text = "x" + fireTrap;
		}
	}
}
