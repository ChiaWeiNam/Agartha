using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateUI : MonoBehaviour 
{
	public GameObject trapText;
	public Transform textPoint;
	public static bool isSpikeCanDisplay;
	public static bool isLogCanDisplay;
	public static bool isAxeCanDisplay;
	public static bool isArrowCanDisplay;
	public static bool isFireCanDisplay;
	public static bool isIceCanDisplay;
	GameObject SpikeText;
	GameObject LogText;
	GameObject AxeText;
	GameObject ArrowText;
	GameObject FireText;
	GameObject IceText;

	float x; 
	float y;

	// Use this for initialization
	void Start () 
	{
		SpikeText = GameObject.FindGameObjectWithTag("SpikeText");
		LogText = GameObject.FindGameObjectWithTag("LogText");
		AxeText = GameObject.FindGameObjectWithTag("AxeText");
		ArrowText = GameObject.FindGameObjectWithTag("ArrowText");
		FireText = GameObject.FindGameObjectWithTag("FireText");
	    IceText = GameObject.FindGameObjectWithTag("IceText");
	}
	
	// Update is called once per frame
	void Update () 
	{
		x = textPoint.transform.position.x - 1.0f;
		y = textPoint.transform.position.y;
		trapText.transform.position = new Vector3 (x, y, 0.0f);

		/*if (LevelManagerScript01.isLevel01 == true) 
		{
			TextLevel01 ();
		}

		if (LevelManagerScript02.isLevel02 == true) 
		{
			TextLevel02 ();
		}*/
	}

	/*public void TextLevel01()
	{
		if(isSpikeCanDisplay == true)
		{
			SpikeText.GetComponent<Text>().enabled = true;
		}
		else if(isSpikeCanDisplay == false)
		{
			SpikeText.GetComponent<Text>().enabled = false;
		}

		if(isLogCanDisplay == true)
		{
			trapText.GetComponent<Text> ().enabled = true; 
		}
		else if(isLogCanDisplay == false)
		{
			trapText.GetComponent<Text>().enabled = false;
		}

		if(isAxeCanDisplay == true)
		{
			AxeText.GetComponent<Text>().enabled = true;
		}
		else if(isAxeCanDisplay == false)
		{
			AxeText.GetComponent<Text>().enabled = false;
		}

		if(isArrowCanDisplay == true)
		{
			ArrowText.GetComponent<Text>().enabled = true;
		}
		else if(isArrowCanDisplay == false)
		{
			ArrowText.GetComponent<Text>().enabled = false;
		}
	}

	public void TextLevel02()
	{
		if(isSpikeCanDisplay == true)
		{
			SpikeText.GetComponent<Text>().enabled = true;
		}
		else if(isSpikeCanDisplay == false)
		{
			SpikeText.GetComponent<Text>().enabled = false;
		}

		if(isLogCanDisplay == true)
		{
			LogText.GetComponent<Text>().enabled = true;
		}
		else if(isLogCanDisplay == false)
		{
			LogText.GetComponent<Text>().enabled = false;
		}

		if(isAxeCanDisplay == true)
		{
			AxeText.GetComponent<Text>().enabled = true;
		}
		else if(isAxeCanDisplay == false)
		{
			AxeText.GetComponent<Text>().enabled = false;
		}

		if(isArrowCanDisplay == true)
		{
			ArrowText.GetComponent<Text>().enabled = true;
		}
		else if(isArrowCanDisplay == false)
		{
			ArrowText.GetComponent<Text>().enabled = false;
		}

		if(isFireCanDisplay == true)
		{
			FireText.GetComponent<Text>().enabled = true;
		}
		else if(isFireCanDisplay == false)
		{
			FireText.GetComponent<Text>().enabled = false;
		}

		if(isIceCanDisplay == true)
		{
			IceText.GetComponent<Text>().enabled = true;
		}
		else if(isIceCanDisplay == false)
		{
			IceText.GetComponent<Text>().enabled = false;
		}
	} */
}
