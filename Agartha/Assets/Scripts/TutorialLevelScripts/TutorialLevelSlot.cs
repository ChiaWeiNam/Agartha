using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TutorialLevelSlot : MonoBehaviour, IDropHandler 
{
	public Button StartButton;
	public TutorialSpawnEnemyScritps checkStart;
	int counter;

	void Awake()
	{
		checkStart = GameObject.FindGameObjectWithTag("TutorialSpawnEnemy").GetComponent<TutorialSpawnEnemyScritps>();
	}

	void Start()
	{
		StartButton.GetComponent<Image>().color = Color.white;
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
		if (!item) 
		{	
			TutorialLevelDragAndDrop.itemBeingDragged.transform.SetParent (transform);
		}

		if(this.gameObject.name == "SpikeSlot")
		{
			if(TutorialSpikeTrap01.TrapName.name == "DraggingSpikeTrap" && TutorialSpikeTrap01.isSpikeOnSlot == false)
			{
				GetComponent<Image>().raycastTarget = false;
				TutorialSpikeTrap01.isSpikeOnSlot = true;
			}
		}

		if(this.gameObject.name == "LogSlot")
		{
			if(TutorialLogTrap01.TrapName.name == "DraggingLogTrap" && TutorialLogTrap01.isLogOnSlot == false)
			{
				GetComponent<Image>().raycastTarget = false;
				TutorialLogTrap01.isLogOnSlot = true;
			}
		}

		if(this.gameObject.name == "AxeSlot")
		{
			if(TutorialAxeTrap01.TrapName.name == "DraggingAxeTrap" && TutorialAxeTrap01.isAxeOnSlot == false)
			{
				GetComponent<Image>().raycastTarget = false;
				TutorialAxeTrap01.isAxeOnSlot = true;
			}
		}
	}
	#endregion
}
