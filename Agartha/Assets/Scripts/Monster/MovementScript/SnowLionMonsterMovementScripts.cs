using UnityEngine;
using System.Collections;

public class SnowLionMonsterMovementScripts : MonsterMovement 
{
	float slowTimer = 0.0f;
	public float slowDuration;
	public static bool isLeftSnowLion;

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
		if(isLeftSnowLion)
		{
			isFacingRight = false;
		}
		else
		{
			isFacingRight = true;
		}

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
