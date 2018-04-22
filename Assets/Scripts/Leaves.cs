using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script that is on the answer table trigger
public class Leaves : MonoBehaviour 
{
	public GameManagerScript managerScript;
	public GameObject gameManager;

	void Start()
	{
		gameManager = GameObject.Find ("Manager");
		managerScript = gameManager.GetComponent<GameManagerScript> ();
	}

	//if leaf has collided with table collider then add leaf's value to amnCollected
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == ("leaf1"))
		{
			managerScript.amnCollected = managerScript.amnCollected +=1;
		}

		if (col.gameObject.tag == ("leaf2"))
		{
			managerScript.amnCollected = managerScript.amnCollected +=2;
		}

		if (col.gameObject.tag == ("leaf3"))
		{
			managerScript.amnCollected = managerScript.amnCollected +=3;
		}
			
	}

	void OnCollisionStay (Collision col)
	{
		if (managerScript.correct) 
		{
			Destroy (col.gameObject);
		}
	}

	void OnCollisionExit(Collision coll)
	{
		if (coll.gameObject.tag == ("leaf1"))
		{
			managerScript.amnCollected = managerScript.amnCollected -=1;
		}

		if (coll.gameObject.tag == ("leaf2"))
		{
			managerScript.amnCollected = managerScript.amnCollected -=2;
		}

		if (coll.gameObject.tag == ("leaf3"))
		{
			managerScript.amnCollected = managerScript.amnCollected -=3;
		}

	}
}
