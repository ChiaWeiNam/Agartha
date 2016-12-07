using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TeleportScripts : MonoBehaviour 
{
	float x;
	float y;
	float isLoseTimer = 0.0f;
	float isLoseDuration = 2.0f;
	float RestartTimer = 0.0f;
	float RestartDuration= 0.5f;
	public static bool isLose = false;
	public static int whichWayLose;

	// Use this for initialization
	void Start () 
	{
		whichWayLose = 0;
	}

	// Update is called once per frame
	void Update () 
	{
		if (isLose == true) 
		{
			if(whichWayLose == 1)
			{
				isLoseTimer += Time.deltaTime;
				GameObject.Find("YouLose").GetComponent<Text>().enabled = true;
				if (isLoseTimer >= isLoseDuration) 
				{
					GameObject.Find("YouLose").GetComponent<Text>().enabled = false;
					RestartTimer  += Time.deltaTime;
					if (RestartTimer >= RestartDuration) 
					{
						isLose = false;
						SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
					}

				}
			}

			if(whichWayLose == 2)
			{
				isLoseTimer += Time.deltaTime;
				GameObject.Find("YouLose2").GetComponent<Text>().enabled = true;
				if (isLoseTimer >= isLoseDuration) 
				{
					GameObject.Find("YouLose2").GetComponent<Text>().enabled = false;
					RestartTimer  += Time.deltaTime;
					if (RestartTimer >= RestartDuration) 
					{
						isLose = false;
						SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
					}

				}
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		//!Level00
		if(this.CompareTag("Level00BlueDoorEnter"))
		{
			GameObject TeleportLoacton = GameObject.FindGameObjectWithTag("Level00BlueDoorExit");
			if(other.CompareTag("TutorialRolang"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.25f;
				other.GetComponent<TutorialRolangMonsterMovementScripts>().isFacingRight = false;
			}
			if(other.CompareTag("TutorialYeti"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y;
				other.GetComponent<TutorialYetiMonsterMovementScripts>().isFacingRight = false;
			}
			if(other.CompareTag("TutorialWindHorse"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y;
				other.GetComponent<TutorialWindHorseMonsterMovementScripts>().isFacingRight = false;
			}

			other.transform.position = new Vector3 (x,y,0.0f);
		}

		if(this.CompareTag("Level00GreenDoorEnter"))
		{
			GameObject TeleportLoacton = GameObject.FindGameObjectWithTag("Level00GreenDoorExit");
			if(other.CompareTag("TutorialRolang"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.25f;
				other.GetComponent<TutorialRolangMonsterMovementScripts>().isFacingRight = true;
			}
			if(other.CompareTag("TutorialYeti"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.08f;
				other.GetComponent<TutorialYetiMonsterMovementScripts>().isFacingRight = true;
			}
			if(other.CompareTag("TutorialWindHorse"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y;
				other.GetComponent<TutorialWindHorseMonsterMovementScripts>().isFacingRight = true;
			}

			other.transform.position = new Vector3 (x,y,0.0f);
		}

		//! Level 00B 
		if(this.CompareTag("Level00BlueDoorEnter"))
		{
			GameObject TeleportLoacton = GameObject.FindGameObjectWithTag("Level00BlueDoorExit");
			if(other.CompareTag("Rolang"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.25f;
				other.GetComponent<RolangMonsterMovementScritps>().isFacingRight = false;
			}
			if(other.CompareTag("Yeti"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y + 0.05f;
				other.GetComponent<YetiMonsterMovementScripts>().isFacingRight = false;
			}
			if(other.CompareTag("Garuda"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y;
				other.GetComponent<GarudaMonsterMovementScipts>().isFacingRight = false;
			}

			other.transform.position = new Vector3 (x,y,0.0f);
		}

		if(this.CompareTag("Level00GreenDoorEnter"))
		{
			GameObject TeleportLoacton = GameObject.FindGameObjectWithTag("Level00GreenDoorExit");
			if(other.CompareTag("Rolang"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.25f;
				other.GetComponent<RolangMonsterMovementScritps>().isFacingRight = true;
			}
			if(other.CompareTag("Yeti"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y + 0.05f;
				other.GetComponent<YetiMonsterMovementScripts>().isFacingRight = true;
			}
			if(other.CompareTag("Garuda"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y;
				other.GetComponent<GarudaMonsterMovementScipts>().isFacingRight = true;
			}

			other.transform.position = new Vector3 (x,y,0.0f);
		}
			
		if(this.CompareTag("Level00LastDoor"))
		{	
			isLose = true;
			whichWayLose = 1;
			Destroy(other.gameObject);
		}

		//!Level01
		if(this.CompareTag("Level01BlueDoorEnter"))
		{
			GameObject TeleportLoacton = GameObject.FindGameObjectWithTag("Level01BlueDoorExit");
			if(other.CompareTag("Rolang"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.23f;
			}
			if(other.CompareTag("Yeti"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y + 0.05f;
			}
			if(other.CompareTag("SnowLion"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y -0.32f;
			}
			other.transform.position = new Vector3 (x,y,0.0f);
		}

		if(this.CompareTag("Level01GreenDoorEnter"))
		{
			GameObject TeleportLoacton = GameObject.FindGameObjectWithTag("Level01GreenDoorExit");
			if(other.CompareTag("Rolang"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.20f;
			}
			if(other.CompareTag("Yeti"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y + 0.1f;
			}
			if(other.CompareTag("SnowLion"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.27f;
			}
			other.transform.position = new Vector3 (x,y,0.0f);
		}

		if(this.CompareTag("Level01LastDoor"))
		{	
			isLose = true;
			whichWayLose = 1;
			Destroy(other.gameObject);
		}

		//!Level02
		if(this.CompareTag("Level02OrangeDoorEnter"))
		{
			GameObject TeleportLoacton = GameObject.FindGameObjectWithTag("Level02OrangeDoorExit");
			if(other.CompareTag("Rolang"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y -0.25f;
			}
			if(other.CompareTag("Yeti"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y;
			}
			if(other.CompareTag("Garuda"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.1f;
			}
			if(other.CompareTag("SnowLion"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.35f;
			}
			other.transform.position = new Vector3 (x,y,0.0f);
		}

		if(this.CompareTag("Level02BlueDoorEnter"))
		{
			GameObject TeleportLoacton = GameObject.FindGameObjectWithTag("Level02BlueDoorExit");
			if(other.CompareTag("Rolang"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.25f;
			}
			if(other.CompareTag("Yeti"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y;
			}
			if(other.CompareTag("Garuda"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.1f;
			}
			if(other.CompareTag("SnowLion"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.35f;
			}
			other.transform.position = new Vector3 (x,y,0.0f);
		}

		if(this.CompareTag("Level02GreenDoorEnter"))
		{
			GameObject TeleportLoacton = GameObject.FindGameObjectWithTag("Level02GreenDoorExit");
			if(other.CompareTag("Rolang"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.25f;
			}
			if(other.CompareTag("Yeti"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y;
			}
			if(other.CompareTag("Garuda"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.1f;
			}
			if(other.CompareTag("SnowLion"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.35f;
			}
			other.transform.position = new Vector3 (x,y,0.0f);
		}

		if(this.CompareTag("Level02PurpleDoorEnter"))
		{
			GameObject TeleportLoacton = GameObject.FindGameObjectWithTag("Level02PurpleDoorExit");
			if(other.CompareTag("Rolang"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.25f;
			}
			if(other.CompareTag("Yeti"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y;
			}
			if(other.CompareTag("Garuda"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.1f;
			}
			if(other.CompareTag("SnowLion"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.35f;
			}
			other.transform.position = new Vector3 (x,y,0.0f);
		}

		if(this.CompareTag("Level02LastDoor"))
		{	
			isLose = true ;
			whichWayLose = 1;
			Destroy(other.gameObject);
		}

		//!Level03
		if(this.CompareTag("Level03PurpleDoorEnterA"))
		{
			GameObject TeleportLoacton = GameObject.FindGameObjectWithTag("Level03PurpleDoorExit");
			if(other.CompareTag("Rolang"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.26f;
			}

			if(other.CompareTag("WindHorse"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y + 0.1f;
			}

			if(other.CompareTag("Gyalpo"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.1f;
			}

			if(other.CompareTag("Garuda"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y + 0.1f;
			}

			if(other.CompareTag("GDon"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.1f;
			}

			other.transform.position = new Vector3 (x,y,0.0f);
		}
		if(this.CompareTag("Level03PurpleDoorEnterB"))
		{
			GameObject TeleportLoacton = GameObject.FindGameObjectWithTag("Level03PurpleDoorExit");
			if(other.CompareTag("Rolang"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.26f;
			}

			if(other.CompareTag("WindHorse"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y + 0.1f;
			}

			if(other.CompareTag("Gyalpo"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.1f;
			}

			if(other.CompareTag("Garuda"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y + 0.1f;
			}

			if(other.CompareTag("GDon"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.1f;
			}

			other.transform.position = new Vector3 (x,y,0.0f);
		}
		if(this.CompareTag("Level03LastDoor"))
		{	
			isLose = true ;
			whichWayLose = 1;
			Destroy(other.gameObject);
		}

		//! Level04
		if(this.CompareTag("Level04PurpleDoorEnter"))
		{
			GameObject TeleportLoacton = GameObject.FindGameObjectWithTag("Level04PurpleDoorExit");
			if(other.CompareTag("Rolang"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.26f;
				other.gameObject.GetComponent<RolangMonsterMovementScritps>().isFacingRight = false;
			}
			if(other.CompareTag("WindHorse"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y + 0.1f;
				other.gameObject.GetComponent<WindHorseMonsterMovementScripts>().isFacingRight = false;
			}
			if(other.CompareTag("Gyalpo"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.1f;
				other.gameObject.GetComponent<GyalpoMonsterMovementScripts>().isFacingRight =false;
			}
			if(other.CompareTag("Garuda"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y + 0.1f;
				other.gameObject.GetComponent<GarudaMonsterMovementScipts>().isFacingRight = false;
			}
			if(other.CompareTag("GDon"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.1f;
				other.gameObject.GetComponent<GDonMonsterMovementScripts>().isFacingRight = false;
			}
			other.transform.position = new Vector3(x,y,0.0f);
		}

		if(this.CompareTag("Level04GreenDoorEnter"))
		{
			GameObject TeleportLoacton = GameObject.FindGameObjectWithTag("Level04GreenDoorExit");
			if(other.CompareTag("Rolang"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.26f;

				if(other.gameObject.name == "Rolang1")
				{
					other.gameObject.GetComponent<MonsterMovement>().isFacingRight = true;
				}

				if(other.gameObject.name == "Rolang2")
				{
					other.gameObject.GetComponent<MonsterMovement>().isFacingRight = true;
				}

				if(other.gameObject.name == "Rolang3")
				{
					other.gameObject.GetComponent<MonsterMovement>().isFacingRight = true;
				}
			}

			if(other.CompareTag("Gyalpo"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.1f;
			
				if(other.gameObject.name == "Gyalpo1")
				{
					other.gameObject.GetComponent<MonsterMovement>().isFacingRight = true;
				}
			}

			if(other.CompareTag("Garuda"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y + 0.1f;

				if(other.gameObject.name == "Garuda1")
				{
					other.gameObject.GetComponent<MonsterMovement>().isFacingRight = true;
				}
			}

			if(other.CompareTag("GDon"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.1f;
				if(other.gameObject.name == "G-Don1" || other.gameObject.name == "G-Don2")
				{
					other.gameObject.GetComponent<MonsterMovement>().isFacingRight = true;
				}
			}

			if(other.CompareTag("Yeti"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.1f;
				if(other.gameObject.name == "Yeti1")
				{
					other.gameObject.GetComponent<MonsterMovement>().isFacingRight = true;
				}
			}

			other.transform.position = new Vector3(x,y,0.0f);
		}

		if(this.CompareTag("Level04OrangeDoorEnter"))
		{
			GameObject TeleportLoacton = GameObject.FindGameObjectWithTag("Level04OrangeDoorExit");
			if(other.CompareTag("Rolang"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.26f;
				other.gameObject.GetComponent<RolangMonsterMovementScritps>().isFacingRight = true;;
			}
			if(other.CompareTag("WindHorse"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y + 0.1f;
				other.gameObject.GetComponent<WindHorseMonsterMovementScripts>().isFacingRight = true;
			}
			if(other.CompareTag("Gyalpo"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.1f;
				other.gameObject.GetComponent<GyalpoMonsterMovementScripts>().isFacingRight =true;
			}
			if(other.CompareTag("Garuda"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y + 0.1f;
				other.gameObject.GetComponent<GarudaMonsterMovementScipts>().isFacingRight = true;
			}
			if(other.CompareTag("GDon"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.1f;
				other.gameObject.GetComponent<GDonMonsterMovementScripts>().isFacingRight = true;
			}
			if(other.CompareTag("Yeti"))
			{
				x = TeleportLoacton.transform.position.x;
				y = TeleportLoacton.transform.position.y - 0.1f;
				other.gameObject.GetComponent<YetiMonsterMovementScripts>().isFacingRight = true;
			}
			other.transform.position = new Vector3(x,y,0.0f);
		}

		if(this.CompareTag("Level04LastDoor"))
		{	
			isLose = true ;
			whichWayLose = 1;
			Destroy(other.gameObject);
		}
	}
}
