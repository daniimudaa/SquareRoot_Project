using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafSpawn : MonoBehaviour 
{
	public GameObject leaves;
	public int numToSpawn;
	public Vector3 position; 

	void Awake ()
	{
		//Vector3 position = new Vector3 (Random.Range (100.0f, 1000.0f), 70, Random.Range (100.0f, 1000.0f, 0f));
	}

	void Start () 
	{
		int spawned = 0;

		while (spawned < numToSpawn) 
		{
			position = new Vector3 (Random.Range (20.0f, -20.0f), 10, Random.Range (20.0f, -20.0f));
			Instantiate (leaves, position, Quaternion.identity);
			spawned++;
		}
	}
	
}
