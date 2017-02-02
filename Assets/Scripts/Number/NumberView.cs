using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class NumberView : MonoBehaviour {

	[SerializeField] private Text numberLavel;
	private RawImage hexImage;
	private NumberParameter numberParameter;

	void Start () {
		numberParameter = GetComponent<NumberParameter> ();
		hexImage = this.gameObject.GetComponent<RawImage>();
	}
	
	// Update is called once per frame
	void Update () {
		
		//active = false ならパネルをグレーにする
		if (!numberParameter.active) {
			hexImage.color = Color.gray;
			numberLavel.enabled = false;
		} else if (!numberParameter.plus) {
			hexImage.color = Color.cyan;
			numberLavel.enabled = true;
		} else {
			hexImage.color = Color.white;
			numberLavel.enabled = true;
		}

		//number = 0 なら数字を表示しない
		if (numberParameter.number == 0) {
			numberLavel.enabled = false;
			numberParameter.plus = true;
		} else if (numberParameter.number == -1) {
			numberLavel.enabled = false;
		} else if (!numberParameter.active) {
		} else {
			numberLavel.enabled = true;
			numberLavel.text = numberParameter.number.ToString ();
		}
	}
}
