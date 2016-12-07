using UnityEngine;
using System.Collections;

public class GDonMonsterMovementScripts : MonsterMovement 
{
	float slowTimer = 0.0f;
	public float slowDuration;
	public static int GdonID;

	void Awake()
	{
		if(LevelManagerScript04.isLevel04 == true)
		{
			gameObject.name = "G-Don" + GdonID;
		}
	}

	// Use this for initialization
	void Start () 
	{
		speed = 1.2f;

		if(gameObject.name == "G-Don1" || gameObject.name == "G-Don2")
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
