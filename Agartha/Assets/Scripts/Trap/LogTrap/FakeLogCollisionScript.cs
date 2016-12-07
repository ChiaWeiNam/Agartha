using UnityEngine;
using System.Collections;

public class FakeLogCollisionScript : MonoBehaviour 
{
	public float speed;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (Vector3.down * Time.deltaTime * speed);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.CompareTag("Floor"))
		{
			Destroy(this.gameObject);
		}
	}
}
