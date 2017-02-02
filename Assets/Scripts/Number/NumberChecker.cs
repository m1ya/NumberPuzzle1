using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class NumberChecker : MonoBehaviour {

	private Subject<int> numberSubject = new Subject<int>();

	public IObservable<int> OnNumberChanged
	{
		get { return numberSubject; }
	} 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NumberChanged(int number){
			//UniRxでGameManagerに変更通知
			numberSubject.OnNext(number);
	}
}
