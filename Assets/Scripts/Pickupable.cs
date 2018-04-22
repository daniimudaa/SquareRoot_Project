using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour 
{
	//reference to main camera component
	public GameObject mainCamera;

	//carrying variables and values
	private bool carrying;
	private GameObject carriedObject;
	private float distance = 1; //how far the object is held from camera screen
	private float smooth = 6; //smoothing value for object movement (smooths the jumpiness of the bject when moving)

	void Start () 
	{
		//referencing the camera component thats in the scene
		mainCamera = GameObject.FindWithTag ("MainCamera");
	}
	
	void Update () 
	{
		//if you are carrying then play carry function otherwise if not carrying then use raycast to find pickupable object
		if (carrying) 
		{
			carry (carriedObject);
			checkDrop ();
		} 

		else 
		{
			pickUp();
		}
	}

	//when carrying the object
	void carry(GameObject o)
	{
		//make object kinematic so the gravity doesnt fight against its new position
		o.GetComponent<Rigidbody> ().isKinematic = true;
		//positioning the object in a new position (centre of the Main Camera's screen at distance, while using time + smooth to lower the jaggered movement)
		o.transform.position = Vector3.Lerp (o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
	}

	void pickUp()
	{
		//if mouse right click then use raycast to find pickupable object and move to centre camera position
		if (Input.GetMouseButtonDown(0)) 
		{
			//finding the centre of the camera screen
			int x = Screen.width / 2;
			int y = Screen.height / 2;

			//setting position that the ray will be casted
			Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay (new Vector3 (x, y));
			RaycastHit hit;

			//if it has hit a pickupable object then position & move to place
			if (Physics.Raycast (ray, out hit)) 
			{
				Pickupable p = hit.collider.GetComponent<Pickupable> ();
				if (p != null) 
				{
					carrying = true;
					carriedObject = p.gameObject;
					p.gameObject.GetComponent<Rigidbody> ().isKinematic = true;
				}
			}
		}
	}
		
	void checkDrop()
	{
		//if you are already carrying the object and press right click again then you will drop the object
		if (Input.GetMouseButtonDown(0)) 
		{
			dropObject ();
		}
	}

	//dropping the object by reversing the functions that picked it up
	void dropObject()
	{
		carrying = false;
		//turning gravity back on so that the object falls untill in contact
		carriedObject.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
		//there is no object being carried
		carriedObject = null;
	}
}
