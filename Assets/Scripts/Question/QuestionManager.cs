using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class QuestionManager : MonoBehaviour {

	private int questionNumber = 1;

	private Subject<int> questionSubject = new Subject<int>();
	private Subject<int> numberSubject = new Subject<int>();

	public IObservable<int> OnQuestionChanged
	{
		get { return questionSubject; }
	} 

	public IObservable<int> OnNumberChanged
	{
		get { return numberSubject; }
	}

	[SerializeField] private NumberChecker numberChecker;

	// Use this for initialization
	void Start () {
		//1問目の出題を伝える
		questionSubject.OnNext(questionNumber);

		numberChecker.OnNumberChanged.Subscribe (number => {
			if(number == questionNumber){
				NumberDroper.lastNumberParameter.number = 0;
				questionNumber++;
				questionSubject.OnNext (questionNumber);
			}else{
				numberSubject.OnNext (questionNumber);
			}
		});
	}
	
	// Update is called once per frame
	void Update () {

	}
}
