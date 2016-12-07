using UnityEngine;
using System.Collections;

public class MonsterMovement : MonoBehaviour 
{
	public float speed;
	public float currentSpeed;
	public float slowSpeed;
	public bool isFacingRight;
	public bool isSlowed = false;
	public bool isDied = false;
	//public bool isGameEnded = false;
	//public bool isDrop = false;

	// Use this for initialization
	void Start () 
	{
		currentSpeed = speed;
		//isGameEnded = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Movement();
	}

	public void Movement()
	{
		if(Input.GetKey(KeyCode.LeftShift))
		{
			currentSpeed = 5.0f;
		}
		else if(Input.GetKeyUp(KeyCode.LeftShift))
		{
			currentSpeed = speed;
		}
			

		if(isFacingRight == true)
		{
			transform.Translate (Vector3.right * Time.deltaTime * currentSpeed);
			this.GetComponent<SpriteRenderer>().flipX = false;
		}

		if(isFacingRight == false)
		{
			transform.Translate (Vector3.left * Time.deltaTime * currentSpeed);
			this.GetComponent<SpriteRenderer>().flipX = true;
		}

		/*if(isGameEnded == true)
		{
			speed = 2.0f;
		}*/

		if(isSlowed == false)
		{
			currentSpeed = speed;
		}

		if(isSlowed == true)
		{
			currentSpeed = slowSpeed;
		}

		/*if(isDrop == true)
		{
			this.GetComponent<Rigidbody2D>().isKinematic = false;
			this.GetComponent<BoxCollider2D>().isTrigger = false;
		}
		if(isDrop == false)
		{
			this.GetComponent<Rigidbody2D>().isKinematic = true;
			this.GetComponent<BoxCollider2D>().isTrigger = true;
		}*/
	}
}
