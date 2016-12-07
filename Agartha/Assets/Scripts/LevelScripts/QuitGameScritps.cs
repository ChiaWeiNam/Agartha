using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Scripting;
using System.Collections;

public class QuitGameScritps : MonoBehaviour 
{
	Button button;
	public Sprite idle;
	public Sprite hover;
	public Sprite clicking;

	// Use this for initialization
	void Start () 
	{
		button = this.GetComponent<Button>();
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
		Application.Quit();
	}
}
