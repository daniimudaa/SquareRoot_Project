using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script that is on the answer table trigger
public class Leaves : MonoBehaviour 
{
	//references to manager script, leaf script 
	public GameManagerScript managerScript;
	public LeafSpawn leafScript;
	public GameObject gameManager;

	void Start()
	{
		//finding relevant objects and getting needed script components
		gameManager = GameObject.Find ("Manager");
		managerScript = gameManager.GetComponent<GameManagerScript> ();
		leafScript = gameManager.GetComponent<LeafSpawn> ();
	}

	//if leaf has collided with table collider then add leaf's value to amnCollected
	void OnCollisionEnter(Collision col)
	{
		//add 1 point value
		if (col.gameObject.tag == ("leaf1"))
		{
			managerScript.amnCollected = managerScript.amnCollected +=1;
		}

		//add 2 point value
		if (col.gameObject.tag == ("leaf2"))
		{
			managerScript.amnCollected = managerScript.amnCollected +=2;
		}

		//add 3 point value
		if (col.gameObject.tag == ("leaf3"))
		{
			managerScript.amnCollected = managerScript.amnCollected +=3;
		}
			
		//update amnCollected Text funtction
		managerScript.updateCollected();
	}
		
	void Update()
	{
		//if answer was correct
		if (managerScript.correct) 
		{
			// then destroy all current leaves in scene
			DestroyAllLeaves();
			//respawn a new problem with new spawn of leaves
			leafScript.spawnLeaves();
		}
	}

	//if a leave has been removed from answer table then remove the objects value from amnCollected
	void OnCollisionExit(Collision coll)
	{
		//minus 1 point value
		if (coll.gameObject.tag == ("leaf1"))
		{
			managerScript.amnCollected = managerScript.amnCollected -=1;
		}

		//minus 2 point value
		if (coll.gameObject.tag == ("leaf2"))
		{
			managerScript.amnCollected = managerScript.amnCollected -=2;
		}

		//minus 3 point value
		if (coll.gameObject.tag == ("leaf3"))
		{
			managerScript.amnCollected = managerScript.amnCollected -=3;
		}

		//update amnCollected Text funtction
		managerScript.updateCollected();
	}

	//find and destroy all leaves with tags "leaf#" in scene
	void DestroyAllLeaves()
	{
		GameObject[] leaves1 = GameObject.FindGameObjectsWithTag ("leaf1");
		GameObject[] leaves2 = GameObject.FindGameObjectsWithTag ("leaf2");
		GameObject[] leaves3 = GameObject.FindGameObjectsWithTag ("leaf3");

		foreach (GameObject leaf1 in leaves1) 
		{
			GameObject.Destroy (leaf1);
		}

		foreach (GameObject leaf2 in leaves2) 
		{
			GameObject.Destroy (leaf2);
		}

		foreach (GameObject leaf3 in leaves3) 
		{
			GameObject.Destroy (leaf3);
		}
	}
}
