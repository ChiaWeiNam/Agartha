using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IceRemainingScript : MonoBehaviour 
{
	public static int iceTrap;
	Text iceTrapText;

	void Awake()
	{
		iceTrapText = this.GetComponent<Text> ();
	}
	void Update () 
	{
		iceTrap = trapPrefabScript.iceCount;

		if(iceTrapText != null)
		{
			iceTrapText.text = "x" + iceTrap;
		}

	}
}
