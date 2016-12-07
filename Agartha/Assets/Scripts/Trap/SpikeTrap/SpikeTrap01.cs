using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpikeTrap01 : Trap
{
	public static int trapID; 
	public static bool mouseHover; 
	public int createCounter = 0;
	public AudioClip buttonSound;
	public AudioSource source;
	float fadeTime;
	Text text;
	float x;
	float y;
	bool canShowToolTips = true;
	SpawnEnemy checkStart;

	public Transform startPoint, endPoint;
	RaycastHit2D whatIHit;

	public Sprite ready;
	public Sprite rosak;
	public Sprite hover;
	public Sprite clicking;
	Button button;

	bool fakeCanCreate = true;
	int fakeCounter;
	float fakeTimer = 0.0f;
	float fakeDuration = 2.0f;

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
	
	void Update()
	{
		RayCasting();
		FadeText ();

		/*if (createCounter >= 1) 
		{
			button.image.overrideSprite = rosak;
		}*/

		if(fakeCanCreate == false)
		{
			fakeTimer += Time.deltaTime;

			if(fakeTimer >= fakeDuration)
			{
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
			UpdateUI.isSpikeCanDisplay = true;

			if(!gameObject.GetComponent<DragHandle>().canDrag)
			{
				fakeCounter ++;
				if(fakeCanCreate == true && fakeCounter >= 2 && checkStart.gameStart == false)
				{
					x = this.transform.position.x;
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
			UpdateUI.isSpikeCanDisplay = false;
		}
		else
		{
			this.button.image.overrideSprite = rosak;
			this.GetComponentInChildren<Text> ().enabled = false;
			UpdateUI.isSpikeCanDisplay = false;
		}
	}
		
	void RayCasting()
	{
		if(whatIHit = Physics2D.Linecast(startPoint.position, endPoint.position, 1<<LayerMask.NameToLayer("Floor")))
		{
			y = whatIHit.transform.position.y + 0.3f;
		}
	}

	void FadeText()
	{
		if (UpdateUI.isSpikeCanDisplay) 
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

		if(createCounter < 1 && checkStart.gameStart == true && !gameObject.GetComponent<DragHandle>().canDrag)
		{
			this.button.image.overrideSprite = rosak;
			trapEffect.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
			trapEffect.GetComponent<BoxCollider2D>().enabled = true;
			Instantiate(trapEffect, new Vector3(x,y,0.0f), Quaternion.identity);
			SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_CLICKING);
			SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_SPIKESOUND);
			ScoringManagerScript.trapCounterLeft -= 1;
			createCounter++;
			canShowToolTips = false;
		}
	}
}
