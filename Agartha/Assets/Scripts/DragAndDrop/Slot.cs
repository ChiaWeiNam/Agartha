using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IDropHandler 
{
	public Button StartButton;
	public SpawnEnemy checkStart;
	public static bool canLose = false;
	int counter;

	void Awake()
	{
		checkStart = GameObject.FindGameObjectWithTag("SpawnEnemy").GetComponent<SpawnEnemy>();
	}

	void Start()
	{
		//StartButton.GetComponent<Image>().color = Color.white;
		canLose = false;
	}

	void Update()
	{
		if(checkStart.gameStart == true)
		{
			this.GetComponent<Image>().enabled = false;
		}
	}

	public GameObject item
	{
		get
		{
			if (transform.childCount > 0) 
			{
				return transform.GetChild (0).gameObject;
			}
			return null;
		}
	}

	#region IDropHandler implementation
	public void OnDrop (PointerEventData eventData)
	{
		if (!item) {
			DragHandle.itemBeingDragged.transform.SetParent (transform);
			if (checkStart.gameStart == false) {
				StartButton.GetComponent<Selectable> ().interactable = true; 
				StartButton.GetComponent<Image> ().color = Color.white;
			}
		}

		if (LogTrap01.trapID == 1)
		{
			this.gameObject.GetComponent<Image> ().raycastTarget = false; 
			trapPrefabScript.logCount -= 1;
			trapPrefabScript.isLogCreated = false; 
		}
			
		if (SpikeTrap01.trapID == 1)
		{
			this.gameObject.GetComponent<Image> ().raycastTarget = false; 
			trapPrefabScript.spikeCount  -= 1;
			trapPrefabScript.isSpikeCreated = false; 

		}

		if (AxeTrap01.trapID == 1)
		{
			this.gameObject.GetComponent<Image> ().raycastTarget = false; 
			trapPrefabScript.axeCount  -= 1;
			trapPrefabScript.isAxeCreated = false; 
		}

		if (ArrowTrap01.trapID == 1)
		{
			this.gameObject.GetComponent<Image> ().raycastTarget = false;  
			trapPrefabScript.arrowCount -= 1;
			trapPrefabScript.isArrowCreated = false; 
		}

		if(FireTrap01.trapID == 1)
		{
			this.gameObject.GetComponent<Image>().raycastTarget = false;
			trapPrefabScript.fireCount -= 1;
			trapPrefabScript.isFireCreated = false;
		}

		if(IceTrap01.trapID == 1)
		{
			this.gameObject.GetComponent<Image>().raycastTarget = false;
			trapPrefabScript.iceCount -= 1;
			trapPrefabScript.isIceCreated = false;
		}

		if(BoomTrap01.trapID == 1)
		{
			this.gameObject.GetComponent<Image>().raycastTarget = false;
			trapPrefabScript.boomCount -= 1;
			trapPrefabScript.isBoomCreated = false;
		}
			
		canLose = true;
	}
	#endregion
}
