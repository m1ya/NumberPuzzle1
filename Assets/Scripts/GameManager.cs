using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject hex;
	public GameObject panels;
	[SerializeField] private GameObject[] hexInstance = new GameObject[12];

	private NumberParameter numberParameter;

	[SerializeField] private GameObject gameOverCanvas;

	//それぞれインスタンスはインスペクタビューから設定
	[SerializeField] private QuestionManager questionManager;

	// Use this for initialization
	void Start () {
		int j = 0;

		for (int i = -2; i < 2; i++) {
			//中央列
			hexInstance[j] = (GameObject)Instantiate (hex, new Vector3 (0, i * 85, 0), Quaternion.identity);
			hexInstance[j].transform.SetParent(panels.transform,false);
			//右列
			hexInstance[j+1] = (GameObject)Instantiate (hex, new Vector3 (73, 43 + i * 85, 0), Quaternion.identity);
			hexInstance[j+1].transform.SetParent(panels.transform,false);
			//左列
			hexInstance[j+2] = (GameObject)Instantiate (hex, new Vector3 (-73, 43 + i * 85, 0), Quaternion.identity);
			hexInstance[j+2].transform.SetParent(panels.transform,false);

			j += 3;
		}

		//問題値が変化したイベントを受けてuGUI Textを更新する
		questionManager.OnQuestionChanged.Subscribe(questionNumber =>
			{
				modChecker();
				randomNumberGenerator(questionNumber);
			});

		questionManager.OnNumberChanged.Subscribe (questionNumber => {
			Check();
		});
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene ("Main");	
		}
		
	}

	void Check(){
		int n = 0;
		//数字が入っている個数を数える
		for (int i = 0; i < hexInstance.Length; i++) {

			if(hexInstance [i].GetComponent<NumberParameter> ().number > 0 && hexInstance [i].GetComponent<NumberParameter> ().active)
				n++;
		}
		if(n <= 1) gameOverCanvas.SetActive(true);
	}

	//残っている数字をチェック
	void modChecker(){
		int sum = 0;
		int j = -1;

		for (int i = 0; i < hexInstance.Length; i++) {
			if (hexInstance [i].GetComponent<NumberParameter> ().number > 0) {
				sum += hexInstance [i].GetComponent<NumberParameter> ().number;
				hexInstance [i].GetComponent<NumberParameter> ().number = 0;
			}
		}

		while(sum != 0){
			if (sum + j >= hexInstance.Length) {
				gameOverCanvas.SetActive(true);
				break;
			}
			if (hexInstance [sum + j].GetComponent<NumberParameter> ().active) {
				hexInstance [sum + j].GetComponent<NumberParameter> ().active = false;
				hexInstance [sum + j].GetComponent<NumberParameter> ().number = -2;
				sum--;
			} else {
				j++;
			}
		}
	}

	//ランダムな数字をパネルに与える
	void randomNumberGenerator(int questionNumber){
		int randomNumber;
		int j = 0;

		//数字を与えるhexInstanceの決定
		for (int i = 0; i < 3 + questionNumber / 3; i++) {
			//空いているパネルに数字を与える
			while (true) {
				if (j >= hexInstance.Length) {
					Debug.Log ("error");
					break;
				}
				randomNumber = Random.Range (0, 12);
				if (hexInstance [randomNumber].GetComponent<NumberParameter> ().number == 0) {
					hexInstance [randomNumber].GetComponent<NumberParameter> ().number = Random.Range (1, 9);
					break;
				}
				j++;
			}

		}
	}
		
}
