using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour 
{
	public GameObject trapEffect;
	public int trapCounter;

	public virtual void ActivateTrap() 
	{
		Debug.Log("Parent Activate");
	}
}
