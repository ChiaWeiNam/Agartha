using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class trapPrefabScript : MonoBehaviour 
{
	public GameObject logPanel;
	public GameObject spikePanel;
	public GameObject axePanel;
	public GameObject arrowPanel;
	public GameObject firePanel;
	public GameObject icePanel;
	public GameObject boomPanel;

	public GameObject logPrefab; 
	public GameObject spikePrefab; 
	public GameObject axePrefab; 
	public GameObject arrowPrefab;
	public GameObject firePrefab;
	public GameObject icePrefab;
	public GameObject boomPrefab;

	public static int spikeCount; 
	public static int logCount; 
	public static int axeCount; 
	public static int arrowCount; 
	public static int fireCount;
	public static int iceCount;
	public static int boomCount;

	public static bool isSpikeCreated;
	public static bool isLogCreated;
	public static bool isAxeCreated;
	public static bool isArrowCreated;
	public static bool isFireCreated;
	public static bool isIceCreated;
	public static bool isBoomCreated;

	// Use this for initialization
	void Start () 
	{
		if (LevelManagerScript00B.isLevel00B == true)
		{
			LevelManagerScript01.isLevel01 = false;
			LevelManagerScript02.isLevel02 = false;
			LevelManagerScript03.isLevel03 = false;
			LevelManagerScript04.isLevel04 = false;
			spikeCount = 1;
			logCount = 2;
			axeCount = 1;
			isSpikeCreated = false; 
			isLogCreated = false; 
			isAxeCreated = false;
		}

		if (LevelManagerScript01.isLevel01 == true)
		{
			LevelManagerScript02.isLevel02 = false;
			LevelManagerScript03.isLevel03 = false;
			LevelManagerScript04.isLevel04 = false;
			spikeCount = 1;
			logCount = 2;
			axeCount = 1;
			arrowCount = 2;
			isSpikeCreated = false; 
			isLogCreated = false; 
			isAxeCreated = false;
			isArrowCreated = false;
		}

		if(LevelManagerScript02.isLevel02 == true)
		{
			LevelManagerScript01.isLevel01 = false;
			LevelManagerScript03.isLevel03 = false;
			LevelManagerScript04.isLevel04 = false;
			spikeCount = 2;
			arrowCount = 1;
			iceCount = 1;
			logCount = 2;
			fireCount = 1;
			axeCount = 2;
			isSpikeCreated = false;
			isArrowCreated = false;
			isIceCreated = false;
			isLogCreated = false;
			isFireCreated = false;
			isAxeCreated = false;
		}

		if(LevelManagerScript03.isLevel03 == true)
		{
			LevelManagerScript01.isLevel01 = false;
			LevelManagerScript02.isLevel02 = false;
			LevelManagerScript04.isLevel04 = false;
			spikeCount = 2;
			arrowCount = 1;
			iceCount = 1;
			logCount = 2;
			fireCount = 1;
			axeCount = 2;
			boomCount = 1;
			isSpikeCreated = false;
			isArrowCreated = false;
			isIceCreated = false;
			isLogCreated = false;
			isFireCreated = false;
			isAxeCreated = false;
			isBoomCreated = false;
		}

		if(LevelManagerScript04.isLevel04 == true)
		{
			LevelManagerScript01.isLevel01 = false;
			LevelManagerScript02.isLevel02 = false;
			LevelManagerScript03.isLevel03 = false;	
			spikeCount = 2;
			arrowCount = 2;
			iceCount = 2;
			logCount = 2;
			fireCount = 2;
			axeCount = 2;
			boomCount = 1;
			isSpikeCreated = false;
			isArrowCreated = false;
			isIceCreated = false;
			isLogCreated = false;
			isFireCreated = false;
			isAxeCreated = false;
			isBoomCreated = false;
		}
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

		if (isArrowCreated == false) 
		{
			CreateArrowButton ();
			isArrowCreated = true; 
		}

		if(isFireCreated == false)
		{
			CreateFireButton();
			isFireCreated = true;
		}

		if(isIceCreated == false)
		{
			CreateIceButton();
			isIceCreated = true;
		}

		if(isBoomCreated == false)
		{
			CreateBoomButton();
			isBoomCreated = true;
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

		if (arrowCount == 0)
		{
			arrowCount = 0; 
		}

		if(fireCount == 0)
		{
			fireCount = 0;
		}

		if(iceCount == 0)
		{
			iceCount =0;
		}

		if(boomCount == 0)
		{
			boomCount = 0;
		}
	}

	void CreateSpikeButton()
	{
		if (spikeCount != 0) 
		{
			GameObject spikeTrapButton = Instantiate (spikePrefab) as GameObject;
			spikeTrapButton.transform.SetParent (spikePanel.transform, false);
		}
	}

	void CreateLogButton()
	{
		if (logCount != 0) 
		{
			GameObject logTrapButton = Instantiate (logPrefab) as GameObject;
			logTrapButton.transform.SetParent (logPanel.transform, false);
		}
	}

	void CreateAxeButton()
	{
		if (axeCount != 0) 
		{
			if(axeCount == 2)
			{	
				axePrefab.name = "AxeTrap01";
				GameObject axeTrapButton = Instantiate (axePrefab) as GameObject;
				axeTrapButton.transform.SetParent (axePanel.transform, false);
			}

			if(axeCount == 1)
			{	
				axePrefab.name = "AxeTrap02";
				GameObject axeTrapButton = Instantiate (axePrefab) as GameObject;
				axeTrapButton.transform.SetParent (axePanel.transform, false);
			}
		}
	}

	void CreateArrowButton()
	{
		if (arrowCount != 0) 
		{
			GameObject arrowTrapButton = Instantiate (arrowPrefab) as GameObject;
			arrowTrapButton.transform.SetParent (arrowPanel.transform, false);
		}
	}

	void CreateFireButton()
	{
		if(fireCount != 0)
		{
			GameObject fireTrapButton = Instantiate (firePrefab) as GameObject;
			fireTrapButton.transform.SetParent (firePanel.transform, false);
		}
	}

	void CreateIceButton()
	{
		if(iceCount != 0)
		{
			GameObject iceTrapButton = Instantiate (icePrefab) as GameObject;
			iceTrapButton.transform.SetParent (icePanel.transform, false);
		}
	}

	void CreateBoomButton()
	{
		if(boomCount != 0)
		{
			GameObject testTrapButton = Instantiate (boomPrefab) as GameObject;
			testTrapButton.transform.SetParent (boomPanel.transform, false);
		}
	}
}
