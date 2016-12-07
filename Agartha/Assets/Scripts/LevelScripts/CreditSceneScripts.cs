using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreditSceneScripts : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GameObject.Find("TeamCredit").GetComponent<SpriteRenderer>().enabled == true)
		{
			if(Input.GetMouseButtonDown(0))
			{
				GameObject.Find("TeamCredit").GetComponent<SpriteRenderer>().enabled = false;
			}
		}
	}
}
