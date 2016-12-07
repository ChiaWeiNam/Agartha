using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGameScripts : MonoBehaviour 
{
	Button button;
	public Sprite idle;
	public Sprite hover;
	public Sprite clicking;

	public GameObject menuHolder;
	public GameObject optionHolder;

	// Use this for initialization
	void Start () 
	{
		//GameObject.Find("Fading").GetComponent<Fading> ().OnLevelWasLoaded ();
		button = this.GetComponent<Button>();
		button.image.overrideSprite = idle;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void OnPointerStay()
	{
		button.image.overrideSprite = hover;
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_HOVER);
	}

	public void OnPointerExit()
	{
		button.image.overrideSprite = idle;
	}

	public void OnClick()
	{
		button.image.overrideSprite = clicking;
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_CLICKING);
		gameObject.GetComponent<ChangeLevelScript>().loadLevel00 = true;
	}

	public void Back()
	{
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_CLICKING);
		menuHolder.SetActive(true);
		optionHolder.SetActive(false);
	}

	public void Option()
	{
		button.image.overrideSprite = idle;
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_CLICKING);
		menuHolder.SetActive(false);
		optionHolder.SetActive(true);
	}
}
