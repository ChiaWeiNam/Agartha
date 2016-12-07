using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeLevelScript : MonoBehaviour 
{
	public bool loadTeamNameScene = false;
	public bool loadCreditScene = false;
	public bool loadMainMenu = false;
	public bool loadLevel00 = false;
	public bool loadLevel00B = false;
	public bool loadLevel01 = false;
	public bool loadLevel02 = false;
	public bool loadLevel03 = false;
	public bool loadLevel04 = false;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(loadTeamNameScene == true)
		{
			StartCoroutine("LoadTeamName");
		}
		if(loadMainMenu)
		{
			StartCoroutine("LoadMainMenu");
		}
		if(loadCreditScene == true)
		{
			StartCoroutine("LoadCreditScene");
		}
		if (loadLevel00 == true) 
		{
			StartCoroutine ("LoadLevel00");
		} 
		if (loadLevel00B == true) 
		{
			StartCoroutine ("LoadLevel00B");
		} 
		if (loadLevel01 == true) 
		{
			StartCoroutine ("LoadLevel01");
		} 
		if (loadLevel02 == true) 
		{
			StartCoroutine ("LoadLevel02");
		}
		if (loadLevel03 == true) 
		{
			StartCoroutine ("LoadLevel03");
		}
		if (loadLevel04 == true) 
		{
			StartCoroutine ("LoadLevel04");
		}
	}

	IEnumerator LoadTeamName ()
	{
		float fadeTime = GameObject.Find ("Fading").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene("TeamNameScene");
	}

	IEnumerator LoadMainMenu ()
	{
		float fadeTime = GameObject.Find ("Fading").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene("MainMenu");
	}

	IEnumerator LoadCreditScene ()
	{
		float fadeTime = GameObject.Find ("Fading").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene("CreditScene");
	}

	IEnumerator LoadLevel00 ()
	{
		float fadeTime = GameObject.Find ("Fading").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene("Level00");
	}

	IEnumerator LoadLevel00B ()
	{
		float fadeTime = GameObject.Find ("Fading").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene("Level00B");
	}

	IEnumerator LoadLevel01 ()
	{
		float fadeTime = GameObject.Find ("Fading").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene("Level01");
	}

	IEnumerator LoadLevel02 ()
	{
		float fadeTime = GameObject.Find ("Fading").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene("Level02");
	}

	IEnumerator LoadLevel03 ()
	{
		float fadeTime = GameObject.Find ("Fading").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene("Level03");
	}

	IEnumerator LoadLevel04 ()
	{
		float fadeTime = GameObject.Find ("Fading").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene("Level04");
	}
}
