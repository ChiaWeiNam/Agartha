using UnityEngine;
using System.Collections;

public class IceCollisionScript : MonoBehaviour 
{
	float delayTimer = 0.0f;
	float delayDuration = 4.0f;

	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{
		delayTimer += Time.deltaTime;

		if(delayTimer >= delayDuration)
		{
			delayTimer = 0.0f;
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.CompareTag("Rolang"))
		{
			other.GetComponent<RolangMonsterMovementScritps>().slowSpeed = 0.5f;
			other.GetComponent<RolangMonsterMovementScritps>().isSlowed = true;
			other.GetComponent<RolangMonsterMovementScritps>().slowDuration = 6.0f;
		}

		if(other.CompareTag("Garuda"))
		{
			other.GetComponent<GarudaMonsterMovementScipts>().slowSpeed = 0.5f;
			other.GetComponent<GarudaMonsterMovementScipts>().isSlowed = true;
			other.GetComponent<GarudaMonsterMovementScipts>().slowDuration = 6.0f;
		}

		if(other.CompareTag("Yeti"))
		{
			other.GetComponent<YetiMonsterMovementScripts>().slowSpeed = other.GetComponent<YetiMonsterMovementScripts>().speed + 0.2f;
			other.GetComponent<YetiMonsterMovementScripts>().isSlowed = true;
			other.GetComponent<YetiMonsterMovementScripts>().slowDuration = 3.0f;
		}

		if(other.CompareTag("SnowLion"))
		{
			other.GetComponent<SnowLionMonsterMovementScripts>().slowSpeed = other.GetComponent<SnowLionMonsterMovementScripts>().speed + 0.2f;
			other.GetComponent<SnowLionMonsterMovementScripts>().isSlowed = true;
			other.GetComponent<SnowLionMonsterMovementScripts>().slowDuration = 3.0f;
		}

		if(other.CompareTag("Gyalpo"))
		{
			other.GetComponent<GyalpoMonsterMovementScripts>().slowSpeed = 0.1f;
			other.GetComponent<GyalpoMonsterMovementScripts>().isSlowed = true;
			other.GetComponent<GyalpoMonsterMovementScripts>().slowDuration = 6.0f;
		}

		if(other.CompareTag("WindHorse"))
		{
			other.GetComponent<WindHorseMonsterMovementScripts>().slowSpeed = 0.5f;
			other.GetComponent<WindHorseMonsterMovementScripts>().isSlowed = true;
			other.GetComponent<WindHorseMonsterMovementScripts>().slowDuration = 6.0f;
		}
	}
}
