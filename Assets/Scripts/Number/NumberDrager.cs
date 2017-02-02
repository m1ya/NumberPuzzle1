using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NumberDrager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{

	private RectTransform r;
	public static int dragNumber = 0;
	public static bool dragPlus;

	private GameObject draggingObject;
	public GameObject draggingPrefab;

	private NumberParameter numberParameter;

	void Start(){
		numberParameter = this.gameObject.transform.parent.GetComponent<NumberParameter> ();
	}

	public void OnBeginDrag(PointerEventData e){
		CreateDragObject ();
		dragNumber = numberParameter.number;
		dragPlus = numberParameter.plus;
		GetComponent<NumberDroper> ().enabled = false;
	}

	public void OnDrag(PointerEventData e){
		numberParameter.number = -1;
		r.position = e.position;
	}

	public void OnEndDrag(PointerEventData e){
		Destroy(draggingObject);
		if(dragPlus) GetComponent<NumberDroper> ().enabled = true;
		numberParameter.number = dragNumber;
		numberParameter.plus = dragPlus;
	}

	void CreateDragObject(){
		draggingObject = Instantiate(draggingPrefab) as GameObject;
		draggingObject.transform.SetParent (this.gameObject.transform.parent.parent);
		r = draggingObject.GetComponent<RectTransform> ();

		// レイキャストがブロックされないように
		CanvasGroup canvasGroup = draggingObject.AddComponent<CanvasGroup>();
		canvasGroup.blocksRaycasts = false;

		Text draggingText = draggingObject.GetComponent<Text> ();
		draggingText.text = numberParameter.number.ToString ();
	}
}
