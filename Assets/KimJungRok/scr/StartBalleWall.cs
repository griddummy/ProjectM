using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class StartBalleWall : MonoBehaviour {

	public List<BossAiMannager> listBossAI;

	public Camera MainCamera;
	public Camera RotationCamera;
	public Camera Camera1;
	public Camera camera2;
	public Camera BackCam;
	public GameObject BackCamera;
	bool cameraBackmove = false;

	bool one;

	public GameObject RemakeWall;

	// Use this for initialization
	void Start () {
		MainCamera.enabled = true;
		RotationCamera.enabled = false;
		Camera1.enabled = false;
		camera2.enabled= false;
		BackCam.enabled= false;

		one = false;
	
	}

	IEnumerator StartCutScene(){
		
		MainCamera.enabled = false;
		RotationCamera.enabled = true;
		Camera1.enabled = false;
		camera2.enabled= false;
		BackCam.enabled= false;

		yield return new WaitForSeconds (3f);
		MainCamera.enabled = false;
		RotationCamera.enabled = false;
		Camera1.enabled = true;
		camera2.enabled= false;
		BackCam.enabled= false;


		yield return new WaitForSeconds (1f);
		MainCamera.enabled = false;
		RotationCamera.enabled = false;
		Camera1.enabled = false;
		camera2.enabled= true;
		BackCam.enabled= false;

		yield return new WaitForSeconds (1f);
		MainCamera.enabled = false;
		RotationCamera.enabled = false;
		Camera1.enabled = false;
		camera2.enabled= false;
		BackCam.enabled= true;
		yield return new WaitForSeconds (0.21f);
		//BackCam.transform.Translate(-Vector3.forward * Time.deltaTime * 15f);
		cameraBackmove = true;

		yield return new WaitForSeconds (3f);
		cameraBackmove = false;
		yield return new WaitForSeconds (1f);

		MainCamera.enabled = true;
		RotationCamera.enabled = false;
		Camera1.enabled = false;
		camera2.enabled= false;
		BackCam.enabled= false;

		foreach (BossAiMannager ai in listBossAI)
		{			
			ai.StartBattle ();
		}
		Destroy (BackCamera, 5f);

		Instantiate (RemakeWall, transform.position + new Vector3(9,-7,4.2f), transform.rotation);
	}
	void OnTriggerEnter (Collider col){

		if (col.gameObject.tag == ("Player")) {
			if (one == false)
			{
				one = true;
				StartCoroutine (StartCutScene());
			}
			else if (one == true)
			{

			}


		}
	}
	
	// Update is called once per frame
	void Update () {
		if (cameraBackmove == true)
		{
			BackCamera.transform.position = BackCamera.transform.position + new Vector3 (0, 0, -0.21f);
		}
	
	}
}
