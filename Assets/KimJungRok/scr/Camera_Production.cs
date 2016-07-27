using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Camera_Production : MonoBehaviour {


	public List<Vector3> WayPoint;
	public List<Quaternion> LookPoint;
	public List<float> speed;


	/*
	void Move(){
		WayPoint.Add (transform.position);
		LookPoint.Add (transform.rotation);
		foreach (Vector3 mov in WayPoint)
		{
			//transform.position = Vector3.Lerp (transform.position, WayPoint, speed);
			transform.position = Vector3.Lerp (transform.position, 
		}

	}
*/
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
