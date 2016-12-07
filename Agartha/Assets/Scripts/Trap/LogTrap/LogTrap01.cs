using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LogTrap01 : Trap 
{
	public static int trapID; 
	public int createCounter = 0;
	public AudioClip buttonSound;
	public AudioSource source;
	float fadeTime;
	Text text;
	SpawnEnemy checkStart;
	float x;
	float y;
	public bool canShowToolTips = true;

	public Sprite ready;
	public Sprite rosak;
	public Sprite hover;
	public Sprite clicking;
	Button button;


	bool fakeCanCreate = true;
	int fakeCounter;
	public GameObject fakeLog;

	void Awake()
	{
		checkStart = GameObject.FindGameObjectWithTag("SpawnEnemy").GetComponent<SpawnEnemy>();
		source = GameObject.FindGameObjectWithTag("SpawnEnemy").GetComponent<AudioSource>();
		button = this.GetComponent<Button>();
		text = this.GetComponentInChildren<Text> ();
		text.color = Color.clear;
		fadeTime = 10.0f;
	}

	// Use this for initialization
	void Start () 
	{
		fakeCanCreate = true;
		fakeCounter = 0;
		canShowToolTips = true;
	}

	// Update is called once per frame
	void Update () 
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
			UpdateUI.isLogCanDisplay = true;

			if(!gameObject.GetComponent<DragHandle>().canDrag)
			{
				fakeCounter ++;
				if(fakeCanCreate == true && fakeCounter >= 2 && checkStart.gameStart == false)
				{
					x = transform.position.x;
					y = transform.position.y - 0.5f;
					Instantiate(fakeLog, new Vector3(x,y,0.0f), Quaternion.identity);
					fakeCanCreate = false;
				}
			}
		}
	}

	public void OnPointerExit()
	{
		if(canShowToolTips == true)
		{
			button.image.overrideSprite = ready;
			this.GetComponentInChildren<Text> ().enabled = false;
			UpdateUI.isLogCanDisplay = false;
			fakeCanCreate = true;
		}
		else
		{
			button.image.overrideSprite = rosak;
			this.GetComponentInChildren<Text> ().enabled = false;
			UpdateUI.isLogCanDisplay = false;
		}

	}

	void FadeText()
	{
		if (UpdateUI.isLogCanDisplay) 
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


		Debug.Log("Log Trap Activate");

		x = transform.position.x;
		y = transform.position.y - 0.5f;

		if(createCounter < 1 && checkStart.gameStart == true && !gameObject.GetComponent<DragHandle>().canDrag)
		{
			trapEffect.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
			trapEffect.GetComponent<BoxCollider2D>().enabled = true;
			Instantiate(trapEffect, new Vector3(x,y,0.0f), Quaternion.identity);
			SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_LOGSOUND);
			SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_CLICKING);
			ScoringManagerScript.trapCounterLeft -= 1;
			createCounter++;
			canShowToolTips = false;
		}
	}
}
