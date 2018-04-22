using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafSpawn : MonoBehaviour 
{
	//array of leaves prefabs
	public GameObject[] leaves;

	//number of leaves waned to spawn in scene
	public int numToSpawn;

	//position for leaves to spawn
	public Vector3 position;

	//int value to determin a random pick of leaf prefabs
	private int random;

	void Start () 
	{
		//calling from start & having the function seperated so that it is able to be called via other scripts
		spawnLeaves ();
	}

	public void spawnLeaves()
	{
		//creating new int to store value - amount of objects that have spawned
		int spawned = 0;

		//if the spawned amount is less that the number to spawn then spawn leaf objects in random transforms within a set range
		while (spawned < numToSpawn) 
		{
			random = Random.Range (0, 3);
			position = new Vector3 (Random.Range (20.0f, -20.0f), 10, Random.Range (20.0f, -20.0f));
			Instantiate (leaves[random], position, Quaternion.identity);
			spawned++;
		}
	}

}
