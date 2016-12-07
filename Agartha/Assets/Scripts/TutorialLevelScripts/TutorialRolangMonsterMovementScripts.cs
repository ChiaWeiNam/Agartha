using UnityEngine;
using System.Collections;

public class TutorialRolangMonsterMovementScripts : MonsterMovement 
{
	// Use this for initialization
	void Start () 
	{
		speed = 0.9f;
		isFacingRight = true;
	}

	// Update is called once per frame
	void Update () 
	{
		Movement();

		if(isSlowed == true)
		{
			currentSpeed = speed;
		}
	}
}
