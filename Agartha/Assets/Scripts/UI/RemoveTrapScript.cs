using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class RemoveTrapScript : MonoBehaviour 
{
	SpawnEnemy checkStart;
	public Sprite idle;
	public Sprite hover;
	Button button;

	void Start () 
	{
		checkStart = GameObject.FindGameObjectWithTag("SpawnEnemy").GetComponent<SpawnEnemy>();
		button = this.GetComponent<Button>();
		button.image.overrideSprite = idle;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(checkStart.gameStart == true)
		{
			button.interactable = false;
		}
	}

	public void RemoveTrap()
	{
		if (checkStart.gameStart == false)
		{
			SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_CLICKING);
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}

	public void OnPointerEnter()
	{
		if(checkStart.gameStart == false)
		{
			SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_HOVER);
			button.image.overrideSprite = hover;
		}
	}

	public void OnPointerExit()
	{
		if(checkStart.gameStart == false)
		{
			button.image.overrideSprite = idle;
		}
	}
}
