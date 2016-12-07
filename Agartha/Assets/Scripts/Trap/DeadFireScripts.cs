using UnityEngine;
using System.Collections;

public class DeadFireScripts : MonoBehaviour 
{
	float delayTimer;
	float delayDuration;

	// Use this for initialization
	void Start () 
	{
		delayTimer = 0.0f;
		delayDuration = 2.0f;

	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (Vector3.up * Time.deltaTime * 0.5f);
		delayTimer += Time.deltaTime;
		if(delayTimer >= delayDuration)
		{
			delayTimer = 0.0f;
			Destroy(this.gameObject);
		}
	}
}
