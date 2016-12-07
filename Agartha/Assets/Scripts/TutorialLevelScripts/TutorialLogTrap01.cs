using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialLogTrap01 : Trap 
{
	public static int trapID; 
	int createCounter = 0;
	//public AudioClip buttonSound;
	//public AudioSource source;
	TutorialSpawnEnemyScritps checkStart;
	float x;
	float y;

	public Transform startPoint, endPoint;
	RaycastHit2D whatIHit;

	bool canPause01 = true;
	bool canPause02 = true;
	bool canCreate = false;

	public static GameObject TrapName;
	public static bool isLogOnSlot; 
	public static bool logBegin;
	bool canDrag;

	void Awake()
	{
		checkStart = GameObject.FindGameObjectWithTag("TutorialSpawnEnemy").GetComponent<TutorialSpawnEnemyScritps>();
		//source = GameObject.FindGameObjectWithTag("SpawnEnemy").GetComponent<AudioSource>();
	}

	// Use this for initialization
	void Start () 
	{
		isLogOnSlot = false;
		canDrag = false; 
	}

	// Update is called once per frame
	void Update () 
	{
		RayCasting();

		if(logBegin == true)
		{
			canDrag = true;
			GetComponent<Button>().interactable = true;
			GetComponent<TutorialLevelDragAndDrop>().enabled = true;
			TrapName = GameObject.Find("TutorialLogTrap(Clone)");
			TrapName.name = "LogTrapIdle";
			GameObject.Find("ClickThis02").GetComponent<Text>().enabled = true;	
			GameObject.Find("TutorialLogSlot").GetComponent<Outline>().enabled = true;
			logBegin = false;	
		}
	}

	public void OnBeginDrag()
	{
		if(canDrag == true)
		{
			TrapName.name = "DraggingLogTrap";
			GameObject.Find("ClickThis02").GetComponent<Text>().enabled = false;
			GameObject.Find("DragThis02").GetComponent<Text>().enabled = true;	
			GameObject.Find("TutorialLogSlot").GetComponent<Outline>().enabled = false;
			GameObject.Find("LogSlot").GetComponent<Outline>().enabled = true;
			GameObject.Find("LogSlot").GetComponent<Image>().raycastTarget = true;
		}
	}

	public void OnEndDrag()
	{
		if(canDrag == true)
		{
			if(isLogOnSlot == true)
			{
				TrapName.name = "LogTrapReady";
				GameObject.Find("DragThis02").GetComponent<Text>().enabled = false;
				GameObject.Find("LogSlot").GetComponent<Outline>().enabled = false;
				if(TrapName.name == "LogTrapReady")
				{
					canDrag = false;
					TutorialAxeTrap01.axeBegin = true;
				}
			}

			else 
			{
				TrapName.name = "LogTrapIdle";
				GameObject.Find("ClickThis02").GetComponent<Text>().enabled = true;
				GameObject.Find("DragThis02").GetComponent<Text>().enabled = false;
				GameObject.Find("TutorialLogSlot").GetComponent<Outline>().enabled = true;
				GameObject.Find("LogSlot").GetComponent<Outline>().enabled = false;
			}
		}

		else
		{
			GameObject.Find("ClickThis02").GetComponent<Text>().enabled = false;
			GameObject.Find("DragThis02").GetComponent<Text>().enabled = false;
			GameObject.Find("TutorialLogSlot").GetComponent<Outline>().enabled = false;
			GameObject.Find("LogSlot").GetComponent<Outline>().enabled = false;
		}

		
	}
		
	/*public void OnPointerEnter()
	{
		if (trapPrefabScript.logCount != 0)
		{
			this.GetComponentInChildren<Text> ().enabled = true;
			UpdateUI.isLogCanDisplay = true;
		}
	}

	public void OnPointerExit()
	{
		this.GetComponentInChildren<Text> ().enabled = true;
		UpdateUI.isLogCanDisplay = false;
	}*/

	void RayCasting()
	{
		if(whatIHit = Physics2D.Linecast(startPoint.position, endPoint.position, 1<<LayerMask.NameToLayer("TutorialWindHorse")))
		{
			if(canPause01 == true)
			{
				GameObject.Find("Text04").GetComponent<Text>().enabled = true;
				Time.timeScale = 0;
				canPause01 = false;
				canCreate = true;
			}
		}

		if(whatIHit = Physics2D.Linecast(startPoint.position, endPoint.position, 1<<LayerMask.NameToLayer("TutorialYeti")))
		{
			if(canPause02 == true)
			{
				GameObject.Find("Text06").GetComponent<Text>().enabled = true;
				Time.timeScale = 0;
				canPause02 = false;
				canCreate = true;
			}
		}
	}

	public override void ActivateTrap()
	{
		base.ActivateTrap();

		x = transform.position.x;
		y = transform.position.y - 0.5f;

		if(createCounter < 2 && checkStart.gameStart == true && !gameObject.GetComponent<TutorialLevelDragAndDrop>().canDrag && canCreate == true)
		{
			SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_CLICKING);
			Instantiate(trapEffect, new Vector3(x,y,0.0f), Quaternion.identity);
			GameObject.Find("Text06").GetComponent<Text>().enabled = false;
			GameObject.Find("Text04").GetComponent<Text>().enabled = false;
			Time.timeScale = 1;
			canCreate = false;
			//source.PlayOneShot(buttonSound,1f);
			createCounter++;
		}
	}
}
