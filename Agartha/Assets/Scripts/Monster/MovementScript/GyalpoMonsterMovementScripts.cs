using UnityEngine;
using System.Collections;

public class GyalpoMonsterMovementScripts : MonsterMovement 
{
	float slowTimer = 0.0f;
	public float slowDuration;
	public static int GyalpoID;

	void Awake()
	{
		if(LevelManagerScript04.isLevel04 == true)
		{
			gameObject.name = "Gyalpo" + GyalpoID;
		}
	}

	// Use this for initialization
	void Start () 
	{
		speed = 0.3f;

		if(gameObject.name == "Gyalpo1")
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
