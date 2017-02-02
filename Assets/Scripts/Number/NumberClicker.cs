using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NumberClicker : MonoBehaviour, IPointerClickHandler {

	NumberParameter numberParameter;
	NumberDroper numberDroper;

	// Use this for initialization
	void Start () {
		numberParameter = GetComponent<NumberParameter> ();
		numberDroper = transform.FindChild ("Text").GetComponent<NumberDroper> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerClick(PointerEventData eventData){
		if (numberParameter.number != 0) {
			numberParameter.plus = !numberParameter.plus;
			numberDroper.enabled = !numberDroper.enabled;
		}
	}

}
