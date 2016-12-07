using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialSpikeTrap01 : Trap
{
	int createCounter = 0;
	//public AudioClip buttonSound;
	//public AudioSource source;
	float x;
	float y;
	TutorialSpawnEnemyScritps checkStart;

	public Transform startPoint, endPoint;
	RaycastHit2D whatIHit;

	bool canPause01 = true;
	bool canPause02 = true;
	bool canPause03 = true;
	bool canCreate = false;

	public static GameObject TrapName;
	public static bool isSpikeOnSlot; 
	bool canDrag; 

	void Awake()
	{
		checkStart = GameObject.FindGameObjectWithTag("TutorialSpawnEnemy").GetComponent<TutorialSpawnEnemyScritps>();
		//source = GameObject.FindGameObjectWithTag("SpawnEnemy").GetComponent<AudioSource>();
	}

	void Start()
	{
		TrapName = GameObject.Find("TutorialSpikeTrap(Clone)");
		isSpikeOnSlot = false;
		canDrag = true;
		TrapName.name = "SpikeTrapIdle";
		GameObject.Find("ClickThis01").GetComponent<Text>().enabled = true;
	}
		
	void Update()
	{
		RayCasting();

		if(checkStart.gameStart == true)
		{
			GetComponent<Image>().raycastTarget = true;
		}
	}

	public void OnBeginDrag()
	{
		if(canDrag == true)
		{
			TrapName.name = "DraggingSpikeTrap";
			GameObject.Find("ClickThis01").GetComponent<Text>().enabled = false;
			GameObject.Find("DragThis01").GetComponent<Text>().enabled = true;
			GameObject.Find("TutorialSpikeSlot").GetComponent<Outline>().enabled = false;
			GameObject.Find("SpikeSlot").GetComponent<Outline>().enabled = true;
		}
	}

	public void OnEndDrag()
	{
		if(canDrag == true)
		{
			if(isSpikeOnSlot == true)
			{
				TrapName.name = "SpikeTrapReady";
				GameObject.Find("DragThis01").GetComponent<Text>().enabled = false;
				GameObject.Find("SpikeSlot").GetComponent<Outline>().enabled = false;
				if(TrapName.name == "SpikeTrapReady")
				{
					canDrag = false;
					TutorialLogTrap01.logBegin = true;
				}
			}

			else 
			{
				TrapName.name = "SpikeTrapIdle";
				GameObject.Find("ClickThis01").GetComponent<Text>().enabled = true;
				GameObject.Find("DragThis01").GetComponent<Text>().enabled = false;
				GameObject.Find("TutorialSpikeSlot").GetComponent<Outline>().enabled = true;
				GameObject.Find("SpikeSlot").GetComponent<Outline>().enabled = false;
			}
		}

		else 
		{
			GameObject.Find("ClickThis01").GetComponent<Text>().enabled = false;
			GameObject.Find("DragThis01").GetComponent<Text>().enabled = false;
			GameObject.Find("TutorialSpikeSlot").GetComponent<Outline>().enabled = false;
			GameObject.Find("SpikeSlot").GetComponent<Outline>().enabled = false;
		}


	}

	/*public void OnPointerEnter()
	{
		if (trapPrefabScript.spikeCount != 0)
		{
			this.GetComponentInChildren<Text> ().enabled = true;
			UpdateUI.isSpikeCanDisplay = true;
		}
	}

	public void OnPointerExit()
	{
		this.GetComponentInChildren<Text> ().enabled = true;
		UpdateUI.isSpikeCanDisplay = false;
	}*/

	void RayCasting()
	{
		if(whatIHit = Physics2D.Linecast(startPoint.position, endPoint.position, 1<<LayerMask.NameToLayer("Floor")))
		{
			y = whatIHit.transform.position.y + 0.3f;
		}

		if(whatIHit = Physics2D.Linecast(startPoint.position, endPoint.position, 1<<LayerMask.NameToLayer("TutorialRolang")))
		{
			if(canPause01 == true)
			{
				Time.timeScale = 0;
				Debug.Log("HELLO");
				GameObject.Find("Text01").GetComponent<Text>().enabled = true;
				canPause01 = false;
				canCreate = true;
			}
		}

		if(whatIHit = Physics2D.Linecast(startPoint.position, endPoint.position, 1<<LayerMask.NameToLayer("TutorialWindHorse")))
		{
			if(canPause02 == true)
			{
				Time.timeScale = 0;
				GameObject.Find("Text02").GetComponent<Text>().enabled = true;
				canPause02 = false;
				canCreate = true;
			}
		}

		if(whatIHit = Physics2D.Linecast(startPoint.position, endPoint.position, 1<<LayerMask.NameToLayer("TutorialYeti")))
		{
			if(canPause03 == true)
			{
				Time.timeScale = 0;
				GameObject.Find("Text03").GetComponent<Text>().enabled = true;
				canPause03 = false;
				canCreate = true;
			}
		}
	}

	public override void ActivateTrap() 
	{

		base.ActivateTrap();

		x = this.transform.position.x;

		if(createCounter < 3 && checkStart.gameStart == true && !gameObject.GetComponent<TutorialLevelDragAndDrop>().canDrag && canCreate == true)
		{
			SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_CLICKING);
			Instantiate(trapEffect, new Vector3(x,y,0.0f), Quaternion.identity);

			GameObject.Find("Text01").GetComponent<Text>().enabled = false;
			GameObject.Find("Text02").GetComponent<Text>().enabled = false;
			GameObject.Find("Text03").GetComponent<Text>().enabled = false;
			Time.timeScale = 1;
			canCreate = false;
			//source.PlayOneShot(buttonSound,1f);
			createCounter++;
		}
	}
}
