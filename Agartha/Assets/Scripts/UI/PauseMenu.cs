using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour 
{

	public GameObject PauseUI;

	public Button resumeButton;
	public Sprite resumeIdle;
	public Sprite resumeHover;
	/*public Sprite resumeClicking;
	float resumeDelayTimer = 0.0f;
	float resumeDelayDuration = 1.0f;
	bool resumeDelay = false;*/

	public Button restartButton;
	public Sprite restartIdle;
	public Sprite restartHover;

	public Button mainMenuButton;
	public Sprite mainMenuIdle;
	public Sprite mainMenuHover;

	public Button exitButton;
	public Sprite exitIdle;
	public Sprite exitHover;


	public bool paused = false;

	void Start()
	{
		PauseUI.SetActive (false);
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			resumeButton.image.overrideSprite = resumeIdle;
			Time.timeScale = 0;
			paused = true;
			Debug.Log ("Pause");
		}

		if (paused) 
		{
			PauseUI.SetActive (true);
			GameObject.Find("ESC").GetComponent<Button>().interactable = false;
		}
		if (!paused) 
		{
			PauseUI.SetActive (false);
			GameObject.Find("ESC").GetComponent<Button>().interactable = true;
		}
	}

	public void OnClick()
	{
		resumeButton.image.overrideSprite = resumeIdle;
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_CLICKING);
		Time.timeScale = 0;
		paused = true;
		Debug.Log ("Pause");
	}

	public void Resume()
	{
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_CLICKING);
		Time.timeScale = 1;
		paused = false;
		Debug.Log ("Resume");
	}

	public void ResumeOnPointerStay()
	{
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_HOVER);
		resumeButton.image.overrideSprite = resumeHover;
	}

	public void ResumeOnPointerExit()
	{
		resumeButton.image.overrideSprite = resumeIdle;
	}

	public void Restart()
	{	
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_CLICKING);
		Debug.Log ("Restart");
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void RestartOnPointerStay()
	{
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_HOVER);
		restartButton.image.overrideSprite = restartHover;
	}

	public void RestartOnPointerExit()
	{
		restartButton.image.overrideSprite = restartIdle;
	}

	public void ReturnMainMenu()
	{	
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_CLICKING);
		Time.timeScale = 1;
		Debug.Log ("Return Main Menu");
		Resume (); // If time scale doesnt return 0, fading wont run and the scene wont change. if Set Time.timeScale = 1 wont work because paused and PauseUI still active.
		GameObject.Find ("ChangeLevel").GetComponent<ChangeLevelScript>().loadMainMenu = true;
		//SceneManager.LoadScene ("MainMenu"); <-- this will ignore the fading function and turn into black screen.
	}

	public void MainMenuOnPointerEnter()
	{
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_HOVER);
		mainMenuButton.image.overrideSprite = mainMenuHover;
	}
	public void MainMenuOnPointerExit()
	{
		mainMenuButton.image.overrideSprite = mainMenuIdle;
	}

	public void ExitGame()
	{	
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_CLICKING);
		Time.timeScale = 1;
		Debug.Log ("Quit Game");
		Application.Quit();
	}

	public void ExitOnPointerEnter()
	{
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_HOVER);
		exitButton.image.overrideSprite = exitHover;
	}
	public void ExitOnPointerExit()
	{
		exitButton.image.overrideSprite = exitIdle;
	}
}
