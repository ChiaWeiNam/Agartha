using UnityEngine;
using System.Collections;

public class BoomScripts : MonoBehaviour
{
	public float dropSpeed;
	public static bool isFakeBoom;
	public GameObject explosion;
	public GameObject boomTrap01;
	float x;
	float y;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (Vector3.down * Time.deltaTime * dropSpeed);

		if(isFakeBoom == true)
		{
			explosion.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.5f);
			explosion.GetComponent<BoxCollider2D>().enabled = false;
		}
		if(isFakeBoom == false)
		{
			explosion.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
			explosion.GetComponent<BoxCollider2D>().enabled = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Floor"))
		{
			x = this.transform.position.x;
			y = this.transform.position.y + 0.5f;


			if(isFakeBoom == true)
			{
				Instantiate(explosion, new Vector3(x,y,0.0f), Quaternion.identity);
			}

			if(isFakeBoom == false)
			{
				SoundManagerScript.Instance.PlaySFX(AudioClipID.SFX_BOOMSOUND);
				Instantiate(explosion, new Vector3(x,y,0.0f), Quaternion.identity);
			}
			Destroy(this.gameObject);
		}
	}
}
