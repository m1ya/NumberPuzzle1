using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class NumberParameter : MonoBehaviour {

	public int number;
	public bool plus = true;
	public bool active = true;


	void Start()
	{
		plus = true;
		active = true;
	}
}
