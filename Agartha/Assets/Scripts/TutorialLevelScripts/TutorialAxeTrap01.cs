using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialAxeTrap01 : Trap
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
	bool canCreate = false;

	public static GameObject TrapName;
	public static bool isAxeOnSlot; 
	public static bool axeBegin;
	bool canDrag;

	void Awake()
	{
		checkStart = GameObject.FindGameObjectWithTag("TutorialSpawnEnemy").GetComponent<TutorialSpawnEnemyScritps>();
		//source = GameObject.FindGameObjectWithTag("SpawnEnemy").GetComponent<AudioSource>();
	}

	void Start()
	{
		isAxeOnSlot = false;
	}

	// Update is called once per frame
	void Update () 
	{
		RayCasting();

		if(axeBegin == true)
		{
			canDrag = true;
			GetComponent<Button>().interactable = true;
			GetComponent<TutorialLevelDragAndDrop>().enabled = true;
			TrapName = GameObject.Find("TutorialAxeTrap(Clone)");
			TrapName.name = "AxeTrapIdle";
			GameObject.Find("ClickThis03").GetComponent<Text>().enabled = true;	
			GameObject.Find("TutorialAxeSlot").GetComponent<Outline>().enabled = true;
			axeBegin = false;	
		}
	}

	public void OnBeginDrag()
	{
		if(canDrag == true)
		{
			TrapName.name = "DraggingAxeTrap";
			GameObject.Find("ClickThis03").GetComponent<Text>().enabled = false;
			GameObject.Find("DragThis03").GetComponent<Text>().enabled = true;	
			GameObject.Find("TutorialAxeSlot").GetComponent<Outline>().enabled = false;
			GameObject.Find("AxeSlot").GetComponent<Outline>().enabled = true;
			GameObject.Find("AxeSlot").GetComponent<Image>().raycastTarget = true;
		}
	}

	public void OnEndDrag()
	{
		if(canDrag == true)
		{
			if(isAxeOnSlot == true)
			{
				TrapName.name = "AxeTrapReady";
				GameObject.Find("DragThis03").GetComponent<Text>().enabled = false;
				GameObject.Find("AxeSlot").GetComponent<Outline>().enabled = false;
				GameObject.Find("ClickStart").GetComponent<Text>().enabled = true;
				GameObject.Find("MonsterSpawnHere").GetComponent<Text>().enabled = true;
				checkStart.StartButton.GetComponent<Button>().interactable = true;
				canDrag = false;
			}

			else 
			{
				TrapName.name = "AxeTrapIdle";
				GameObject.Find("ClickThis03").GetComponent<Text>().enabled = true;
				GameObject.Find("DragThis03").GetComponent<Text>().enabled = false;
				GameObject.Find("TutorialAxeSlot").GetComponent<Outline>().enabled = true;
				GameObject.Find("AxeSlot").GetComponent<Outline>().enabled = false;
			}
		}

		else 
		{
			GameObject.Find("ClickThis03").GetComponent<Text>().enabled = false;
			GameObject.Find("DragThis03").GetComponent<Text>().enabled = false;
			GameObject.Find("TutorialAxeSlot").GetComponent<Outline>().enabled = false;
			GameObject.Find("AxeSlot").GetComponent<Outline>().enabled = false;
		}
	}

	/*public void OnPointerEnter()
	{
		if (trapPrefabScript.axeCount != 0)
		{
			this.GetComponentInChildren<Text> ().enabled = true;
			UpdateUI.isAxeCanDisplay = true;
		}
	}

	public void OnPointerExit()
	{
		this.GetComponentInChildren<Text> ().enabled = true;
		UpdateUI.isAxeCanDisplay = false;
	}*/

	void RayCasting()
	{
		if(whatIHit = Physics2D.Linecast(startPoint.position, endPoint.position, 1<<LayerMask.NameToLayer("TutorialYeti")))
		{
			if(canPause01 == true)
			{
				GameObject.Find("Text05").GetComponent<Text>().enabled = true;
				Time.timeScale = 0;
				canPause01 = false;
				canCreate = true;
			}
		}
	}

	public override void ActivateTrap()
	{
		base.ActivateTrap();

		x = transform.position.x;
		y = transform.position.y - 0.40f;

		if(createCounter < 1 && checkStart.gameStart == true && !gameObject.GetComponent<TutorialLevelDragAndDrop>().canDrag && canCreate == true)
		{
			SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_CLICKING);
			Instantiate(trapEffect, new Vector3(x,y,0.0f), Quaternion.identity);
			GameObject.Find("Text05").GetComponent<Text>().enabled = false;
			Time.timeScale = 1;
			canCreate = false;
			//source.PlayOneShot(buttonSound,1f);
			createCounter++;
		}
	}
}
