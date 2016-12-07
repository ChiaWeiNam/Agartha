using UnityEngine;
using System.Collections;

public class RolangMonsterMovementScritps : MonsterMovement 
{
	float slowTimer = 0.0f;
	public float slowDuration;
	public static int RolangID;

	void Awake()
	{
		if(LevelManagerScript04.isLevel04 == true)
		{
			gameObject.name = "Rolang" + RolangID;
		}
	}

	// Use this for initialization
	void Start () 
	{
		speed = 0.9f;
	
		if(gameObject.name == "Rolang1")
		{
			isFacingRight = false;
		}

		else if(gameObject.name == "Rolang2")
		{
			isFacingRight = false;
		}

		else if(gameObject.name == "Rolang3")
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
