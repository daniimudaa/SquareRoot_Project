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
	public int Answer;
	public bool correct;

	//number amount leaves collected
	public int amnCollected;

	public Text[] amnCollectedText;


	void Start () 
	{
		//setting the first values for all UI text
		randomNums(); //ransomising the numbers
		Answer = numbers [0] + numbers [1]; //calulating the answer
		amnCollected = 0;
		correct = false;
		amnCollectedText[0].text = "0";
		amnCollectedText[1].text = "0";
	}
	
	void Update () 
	{
		//if answer is correct then next random math problem
		if (correct)
		{
			//play "thats correct" sound
			randomNums();
			Answer = numbers [0] + numbers [1];
			correct = false;
			amnCollected = 0;
			amnCollectedText[0].text = "0";
			amnCollectedText[1].text = "0";
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

	//updating UI text to current collected amount
	public void updateCollected()
	{
		amnCollectedText[0].text = amnCollected.ToString();
		amnCollectedText[1].text = amnCollected.ToString();
	}
}
