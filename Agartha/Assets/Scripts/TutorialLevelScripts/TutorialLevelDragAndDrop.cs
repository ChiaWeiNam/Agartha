using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class TutorialLevelDragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler 
{
	public static GameObject itemBeingDragged;
	Vector3 startPosition;
	Transform startParent;
	TutorialSpawnEnemyScritps checkStart;
	public bool canDrag = true;
 
	void Awake()
	{
		checkStart = GameObject.FindGameObjectWithTag("TutorialSpawnEnemy").GetComponent<TutorialSpawnEnemyScritps>();
	}

	void Update()
	{
		
	}

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		if(canDrag == true && checkStart.gameStart == false)
		{
			itemBeingDragged = gameObject;
			startPosition = transform.position;
			startParent = transform.parent;
			GetComponent<CanvasGroup> ().blocksRaycasts = false;
		}
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{ 
		if(canDrag == true && checkStart.gameStart == false)
		{
			Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			newPos.z = 0f;
			transform.position = newPos;
		}
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		itemBeingDragged = null;

		if (checkStart.gameStart == false) 
		{
			if (transform.parent == startParent) 
			{
				transform.position = startPosition;
				canDrag = true;
			} 
			else 
			{
				canDrag = false;
			}
			GetComponent<CanvasGroup> ().blocksRaycasts = true;
		}
	}
	#endregion
}
