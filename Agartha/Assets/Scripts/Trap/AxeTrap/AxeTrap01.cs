using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AxeTrap01 : Trap
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
	bool canShowToolTips = true;

	public Sprite ready;
	public Sprite rosak;
	public Sprite hover;
	public Sprite clicking;
	Button button;


	bool fakeCanCreate = true;
	int fakeCounter;
	float fakeTimer = 0.0f;
	float fakeDuration = 5.0f;

	GameObject FakeAxe;

	void Awake()
	{
		checkStart = GameObject.FindGameObjectWithTag("SpawnEnemy").GetComponent<SpawnEnemy>();
		source = GameObject.FindGameObjectWithTag("SpawnEnemy").GetComponent<AudioSource>();
		button = this.GetComponent<Button>();
		text = this.GetComponentInChildren<Text> ();
		text.color = Color.clear;
		fadeTime = 10.0f;
	}

	void Start()
	{
		fakeCanCreate = true;
		fakeCounter = 0;
		canShowToolTips = true;
	}

	// Update is called once per frame
	void Update () 
	{
		FadeText ();

		if(fakeCanCreate == false)
		{
			fakeTimer += Time.deltaTime;

			if(fakeTimer >= fakeDuration)
			{
				Debug.Log("Fake Axe: " + fakeTimer);
				fakeTimer = 0.0f;
				fakeCanCreate = true;
			}
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
			this.button.image.overrideSprite = hover;
			this.GetComponentInChildren<Text> ().enabled = true;
			UpdateUI.isAxeCanDisplay = true;

			if(!gameObject.GetComponent<DragHandle>().canDrag)
			{
				fakeCounter ++;
				if(fakeCanCreate == true && fakeCounter >= 2 && checkStart.gameStart == false)
				{
					x = transform.position.x;
					y = transform.position.y - 0.40f;
						
					if(this.name == "AxeTrap01(Clone)")
					{
						trapEffect.name = "FakeAxe01";
					}

					if(this.name == "AxeTrap02(Clone)")
					{
						trapEffect.name = "FakeAxe02";
					}
					trapEffect.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.5f);
					trapEffect.GetComponent<BoxCollider2D>().enabled = false;
					Instantiate(trapEffect, new Vector3(x,y,0.0f), Quaternion.identity);
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
			UpdateUI.isAxeCanDisplay = false;
		}
		else
		{
			this.button.image.overrideSprite = rosak;
			this.GetComponentInChildren<Text> ().enabled = false;
			UpdateUI.isAxeCanDisplay = false;
		}

	}

	void FadeText()
	{
		if (UpdateUI.isAxeCanDisplay) 
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


		Debug.Log("Axe Trap Activate");

		x = transform.position.x;
		y = transform.position.y - 0.40f;

		if(createCounter < 1 && checkStart.gameStart == true && !gameObject.GetComponent<DragHandle>().canDrag)
		{
			this.button.image.overrideSprite = rosak;
			trapEffect.name = "RealAxe";
			trapEffect.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
			trapEffect.GetComponent<BoxCollider2D>().enabled = true;
			Instantiate(trapEffect, new Vector3(x,y,0.0f), Quaternion.identity);
			SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_CLICKING);
			SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_AXESOUND);
			ScoringManagerScript.trapCounterLeft -= 1;
			createCounter++;
			canShowToolTips = false;
			if(canShowToolTips == false)
			{
				if(this.name == "AxeTrap01(Clone)")
				{	
					FakeAxe = GameObject.Find("FakeAxe01(Clone)");
					Destroy(FakeAxe);
				}

				if(this.name == "AxeTrap02(Clone)")
				{	
					FakeAxe = GameObject.Find("FakeAxe02(Clone)");
					Destroy(FakeAxe);
				}
			}
		}
	}
}
