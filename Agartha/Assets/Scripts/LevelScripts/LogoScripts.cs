using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LogoScripts : MonoBehaviour 
{
	float timer = 0.0f;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
		if(timer >= 3)
		{
			SceneManager.LoadScene("TeamNameScene");
		}
	}
}
