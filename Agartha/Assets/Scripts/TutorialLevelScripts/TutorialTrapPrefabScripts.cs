using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialTrapPrefabScripts : MonoBehaviour 
{
	public GameObject tutorialSpikePanel;
	public GameObject tutorialLogPanel;
	public GameObject tutorialAxePanel;

	public GameObject tutorialSpikePrefab; 
	public GameObject tutorialLogPrefab; 
	public GameObject tutorialAxePrefab;

	public static int spikeCount; 
	public static int logCount; 
	public static int axeCount;

	public static bool isSpikeCreated;
	public static bool isLogCreated;
	public static bool isAxeCreated;

	// Use this for initialization
	void Start () 
	{
		spikeCount = 1;
		logCount = 1;
		axeCount = 1;
		isSpikeCreated = false; 
		isLogCreated = false; 
		isAxeCreated = false;

	}
	// Update is called once per frame
	void Update () 
	{
		if (isSpikeCreated == false) 
		{
			CreateSpikeButton ();
			isSpikeCreated = true; 
		}

		if (isLogCreated == false) 
		{
			CreateLogButton ();
			isLogCreated = true; 
		}

		if (isAxeCreated == false) 
		{
			CreateAxeButton ();
			isAxeCreated = true; 
		}

		if (spikeCount == 0)
		{
			spikeCount = 0; 
		}

		if (logCount == 0)
		{
			logCount = 0; 
		}

		if (axeCount == 0)
		{
			axeCount = 0; 
		}
	}

	void CreateSpikeButton()
	{
		if (spikeCount != 0) 
		{
			GameObject spikeTrapButton = Instantiate (tutorialSpikePrefab) as GameObject;
			spikeTrapButton.transform.SetParent (tutorialSpikePanel.transform, false);
		}
	}

	void CreateLogButton()
	{
		if (logCount != 0) 
		{
			GameObject logTrapButton = Instantiate (tutorialLogPrefab) as GameObject;
			logTrapButton.transform.SetParent (tutorialLogPanel.transform, false);
		}
	}

	void CreateAxeButton()
	{
		if (axeCount != 0) 
		{
			GameObject axeTrapButton = Instantiate (tutorialAxePrefab) as GameObject;
			axeTrapButton.transform.SetParent (tutorialAxePanel.transform, false);
		}
	}
}
