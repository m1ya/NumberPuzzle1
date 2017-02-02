using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class QuestionView : MonoBehaviour {

	//それぞれインスタンスはインスペクタビューから設定

	[SerializeField] private QuestionManager questionManager;
	[SerializeField] private Text questionLavel;

	void Start()
	{
		//問題値が変化したイベントを受けてuGUI Textを更新する
		questionManager.OnQuestionChanged.Subscribe(questionNumber =>
			{
				//現在の問題値をUIに反映する
				questionLavel.text = questionNumber.ToString();
			});
	}
}
