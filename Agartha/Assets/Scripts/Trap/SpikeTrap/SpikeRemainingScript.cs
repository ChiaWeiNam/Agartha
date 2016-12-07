using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpikeRemainingScript : MonoBehaviour 
{
	public static int spikeTrap;
	Text spikeTrapText;

	void Awake()
	{
		spikeTrapText = this.GetComponent<Text>();
	}
		
	// Update is called once per frame
	void Update () 
	{
		spikeTrap = trapPrefabScript.spikeCount; 

		if(spikeTrapText != null)
		{
			spikeTrapText.text = "x" + spikeTrap;
		}
	}
}
