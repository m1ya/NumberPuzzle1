using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NumberDroper : MonoBehaviour, IDropHandler {

	private NumberParameter numberParameter;
	[SerializeField] private NumberChecker numberChecker;
	public static NumberParameter lastNumberParameter;

	// Use this for initialization
	void Start () {
		numberParameter = this.gameObject.transform.parent.GetComponent<NumberParameter> ();
		numberChecker = GameObject.Find ("NumberChecker").GetComponent<NumberChecker> ();
	}
	
	public void OnDrop(PointerEventData e){
		int dropedNumber = numberParameter.number;
		if (!NumberDrager.dragPlus && (NumberDrager.dragNumber > dropedNumber)) return;
		if (!NumberDrager.dragPlus) NumberDrager.dragNumber = -NumberDrager.dragNumber; 
		numberParameter.number +=  NumberDrager.dragNumber;
		NumberDrager.dragNumber = 0;
		NumberDrager.dragPlus = true;
		lastNumberParameter = numberParameter;
		numberChecker.NumberChanged (numberParameter.number);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
