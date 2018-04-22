using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour 
{
	//number UI text
	public Text[] numbersText = new Text [2];

	//number values
	public int[] numbers = new int[1];

	public Button [] buttons;
	public int Answer;
	public bool correct;

	//number amount leaves collected
	public int amnCollected;


	void Start () 
	{
		//setting the first values for all UI text
		randomNums(); //ransomising the numbers
		Answer = numbers [0] + numbers [1]; //calulating the answer
		displayResults (); //displaying collected result
		amnCollected = 0;
		correct = false;
	}
	
	void Update () 
	{
		//if answer is correct then next random math problem
		if (correct)
		{
			//play "correct" sound
			randomNums();
			Answer = numbers [0] + numbers [1];
			displayResults ();
			correct = false;
		}

		//if the value of collected is the same as answer then correct is true
		if (amnCollected == Answer) 
		{
			correct = true;
		}
	}

	void randomNums()
	{
		//setting random number values to number text (values from 1-9)
		for (int i = 0; i < numbers.Length; i++) 
		{
			numbers [0] = Random.Range (1, 10);
			numbers [1] = Random.Range (1, 10);
			numbersText [0].text = numbers [0].ToString ();
			numbersText [1].text = numbers [1].ToString ();
		}
	}

	//display current collected amount
	void displayResults()
	{
		for (int i = 0; i < buttons.Length; i++) 
		{
			//this is showing the Answer atm, need to change this to be the collected amount on display in UI text instead of button
			buttons [i].transform.GetChild(0).GetComponent<Text> ().text = Answer.ToString();
		}
	}
}
