using UnityEngine;
using System.Collections;

public class GarudaMonsterMovementScipts : MonsterMovement 
{
	float slowTimer = 0.0f;
	public float slowDuration;
	public static int GarudaID;

	void Awake()
	{
		if(LevelManagerScript04.isLevel04 == true)
		{
			gameObject.name = "Garuda" + GarudaID;
		}
	}

	// Use this for initialization
	void Start () 
	{
		speed = 1.2f;

		if(gameObject.name == "Garuda1")
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
