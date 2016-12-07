using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

public class DestroyOutline : MonoBehaviour {

	public int destroyID; 

	// Use this for initialization
	void Start () 
	{
		
	}	

	// Update is called once per frame
	void Update ()
	{
		if (trapPrefabScript.spikeCount == 0 && destroyID == 1)
		{
			Cancel ();
		}

		if (trapPrefabScript.logCount == 0 && destroyID == 2)
		{
			Cancel ();
		}

		if (trapPrefabScript.axeCount == 0 && destroyID == 3)
		{
			Cancel ();
		}

		if (trapPrefabScript.arrowCount == 0 && destroyID == 4)
		{
			Cancel ();
		}

		if (trapPrefabScript.fireCount == 0 && destroyID == 5)
		{
			Cancel ();
		}

		if (trapPrefabScript.iceCount == 0 && destroyID == 6)
		{
			Cancel ();
		}
	}

	public void Cancel()
	{
		Destroy (GetComponent<EventTrigger> ());
	}
}
