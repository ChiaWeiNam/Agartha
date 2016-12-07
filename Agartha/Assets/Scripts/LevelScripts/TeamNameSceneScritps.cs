using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TeamNameSceneScritps : MonoBehaviour 
{
	float timer = 0.0f;

	// Use this for initialization
	void Start () 
	{
		SoundManagerScript.Instance.PlayBGM(AudioClipID.BGM_TEAMNAME);
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
		if(timer >= 3)
		{
			SceneManager.LoadScene("MainMenu");
		}
	}
}
