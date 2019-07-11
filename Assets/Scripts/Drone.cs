using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour {

	// variables for drone
	public Rigidbody2D drone;
	public Transform startTransform;
	public Transform endTransform;
	public float radius = 1f;
	public float droneSpeed;

	public Vector2 direction;
	Transform destination;
	private PlayerView player;

	void Start()
	{
		//Initalizes the drone
		drone = GetComponentInChildren<Rigidbody2D> ();

		//Starts the drones movement
		SetDestination (startTransform);


	}


	void OnDrawGizmos()
	{
		//draws the start and end position (scene view only)
		Gizmos.DrawWireSphere (startTransform.position, radius);
		Gizmos.DrawWireSphere (endTransform.position, radius);
	}


	void FixedUpdate ()
	{
		//movement code
		drone.MovePosition (drone.position + direction * droneSpeed * Time.fixedDeltaTime);

		//If statement that decides if the start or end position is the current destination
	if (Vector2.Distance (drone.position, destination.position) < droneSpeed * Time.fixedDeltaTime) 
	{
			SetDestination (destination == startTransform ? endTransform : startTransform);
		}
	}

	void SetDestination(Transform dest)
	{
		//sets the destination
		destination = dest;
		direction = (destination.position - drone.transform.position).normalized;
	}


}
		