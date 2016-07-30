using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {

	//public BossAiMannager cutsceneStart;

	// Use this for initialization
	void Start () {
		//cutsceneStart = GameObject.Find ("Bruce").GetComponent<BossAiMannager> ();
		//cutsceneStart.GetComponents ("BossAiMannager") as BossAiMannager;

	}

	IEnumerator TimeRotation(GameObject target, float time, float yAngle)
	{
		
			yield return new WaitForSeconds (time);
			target.transform.Rotate (0, yAngle, 0);
			target.transform.position = Vector3.Lerp(transform.position, this.transform.position + new Vector3(0,0,0), 1f);


	}
	// Update is called once per frame
	void Update () {
		//if (cutsceneStart.Hello_Boss == true)
		//{
			StartCoroutine (TimeRotation (this.gameObject, 0.01f, 0.5f));
			//cutsceneStart.Hello_Boss = false;
			//enabled = false;
		//}
		//enabled = false;

	}
}