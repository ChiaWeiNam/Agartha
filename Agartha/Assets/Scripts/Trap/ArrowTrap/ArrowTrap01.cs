using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ArrowTrap01 : Trap 
{
	public static int trapID; 
	public int createCounter = 0;
	public AudioClip buttonSound;
	public AudioSource source;
	float fadeTime;
	Text text;
	float x;
	float y;
	SpawnEnemy checkStart;
	bool canShowToolTips = true;

	public Sprite ready;
	public Sprite rosak;
	public Sprite hover;
	public Sprite clicking;
	Button button;

	bool fakeCanCreate = true;
	int fakeCounter;

	public GameObject fakeArrow;

	void Awake()
	{
		checkStart = GameObject.FindGameObjectWithTag("SpawnEnemy").GetComponent<SpawnEnemy>();
		source = GameObject.FindGameObjectWithTag("SpawnEnemy").GetComponent<AudioSource>();
		button = this.GetComponent<Button>();
		text = this.GetComponentInChildren<Text> ();
		text.color = Color.clear;
		fadeTime = 10.0f;
	}
	
	// Update is called once per frame
	void Update()
	{
		FadeText ();

		if (createCounter >= 1) 
		{
			button.image.overrideSprite = rosak;
		}
	}

	public void OnBeginDrag()
	{
		trapID = 1;
	}

	public void OnEndDrag()
	{
		trapID = 0; 
	}

	public void OnPointerEnter()
	{
		if(canShowToolTips == true)
		{
			button.image.overrideSprite = hover;
			this.GetComponentInChildren<Text> ().enabled = true;
			UpdateUI.isArrowCanDisplay = true;

			if(!gameObject.GetComponent<DragHandle>().canDrag)
			{
				fakeCounter ++;
				if(fakeCanCreate == true && fakeCounter >= 2 && checkStart.gameStart == false)
				{
					x = this.transform.position.x;
					y = this.transform.position.y - 0.25f;
					Instantiate(fakeArrow, new Vector3(x,y,0.0f), Quaternion.identity);
					fakeCanCreate = false;
				}
			}
		}
	}

	public void OnPointerExit()
	{
		if(canShowToolTips == true)
		{
			this.button.image.overrideSprite = ready;
			this.GetComponentInChildren<Text> ().enabled = false;
			UpdateUI.isArrowCanDisplay = false;
			fakeCanCreate = true;
		}
		else
		{
			this.button.image.overrideSprite = rosak;
			this.GetComponentInChildren<Text> ().enabled = false;
			UpdateUI.isArrowCanDisplay = false;
		}
	}

	void FadeText()
	{
		if (UpdateUI.isArrowCanDisplay) 
		{
			text.color = Color.Lerp (text.color, Color.white, fadeTime * Time.deltaTime);
		} 

		else 
		{
			text.color = Color.Lerp (text.color, Color.clear, fadeTime * Time.deltaTime);
		}
	}

	public override void ActivateTrap() 
	{

		base.ActivateTrap();

		if(canShowToolTips == true)
		{
			button.image.overrideSprite = clicking;
		}

		x = this.transform.position.x;
		y = this.transform.position.y - 0.25f;

		if(createCounter < 1 && checkStart.gameStart == true && !gameObject.GetComponent<DragHandle>().canDrag)
		{
			Instantiate(trapEffect, new Vector3(x,y,0.0f), Quaternion.identity);
			ScoringManagerScript.trapCounterLeft -= 1;
			SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_CLICKING);
			SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_ARROWSOUND);
			createCounter++;
			canShowToolTips = false;
		}
	}
}
