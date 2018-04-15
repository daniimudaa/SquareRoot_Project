using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour 
{
	public Text[] numbersText = new Text [2];
	public int[] numbers = new int[1];

	public float time;
	public float roundLength;

	public Text timeText;

	//buttons
	public Button [] buttons;

	//answer

	public float Answer;

	void Start () 
	{
		time = 0.1f;
	}
	
	void Update () 
	{
		time -= Time.deltaTime;
		timeText.text = "Time : " + time.ToString ();

		if (time <= 0)
		{
			time = roundLength;
			randomNums();
			Answer = numbers [0] + numbers [1];
			displayResults ();
		}
	}

	void randomNums()
	{
		for (int i = 0; i < numbers.Length; i++) 
		{
			numbers [i] = Random.Range (1, 9);
			numbersText [i].GetComponent<Text>().text = numbers [i].ToString ();
		}

//		if (p.Level < 40f) {
//			Timer = roundLength;
//		} 
//
//		else 
//		{
//			Timer = 10f;
//		}
//
//		result = numbers [0] + numbers [1];
//		Debug.Log (result);
	}

	void displayResults()
	{
		for (int i = 0; i < buttons.Length; i++) 
		{
			buttons [i].gameObject.GetComponentInChildren<Text> ().text = Answer.ToString();
		}
	}
}
