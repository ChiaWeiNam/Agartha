using UnityEngine;
using System.Collections;

public class TutorialWindHorseMonsterMovementScripts : MonsterMovement 
{
	float slowTimer = 0.0f;
	public float slowDuration;

	// Use this for initialization
	void Start ()
	{
		speed = 1.5f;
		isFacingRight = true;
	}

	// Update is called once per frame
	void Update ()
	{
		Movement();

		if(isSlowed == true)
		{
			slowTimer += Time.deltaTime;

			if(slowTimer >= slowDuration)
			{
				slowTimer = 0.0f;
				currentSpeed = speed;
				isSlowed = false;
			}
		}
	}
}
