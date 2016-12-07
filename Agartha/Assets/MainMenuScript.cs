using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		SoundManagerScript.Instance.PlayBGM(AudioClipID.BGM_MAINMENU);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
