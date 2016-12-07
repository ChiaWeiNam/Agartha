using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreditScripts : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void OnClick()
	{
		GameObject.Find("TeamCredit").GetComponent<SpriteRenderer>().enabled = true;
		SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_CLICKING);
	}
}
