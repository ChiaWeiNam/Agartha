using UnityEngine;
using System.Collections;

public class YetiMonsterMovementScripts : MonsterMovement 
{
	float slowTimer = 0.0f;
	public float slowDuration;
	public static int YetiID;

	void Awake()
	{
		if(LevelManagerScript04.isLevel04 == true)
		{
			gameObject.name = "Yeti" + YetiID;
		}
	}

	// Use this for initialization
	void Start () 
	{
		speed = 0.6f;

		if(gameObject.name == "Yeti1")
		{
			isFacingRight = false;
		}
		else
		{
			isFacingRight = true;
		}
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
