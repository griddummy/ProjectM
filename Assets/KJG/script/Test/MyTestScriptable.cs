using UnityEngine;
using System.Collections;

public class MyTestScriptable : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        Debug.Log("초기 : " + InputManager.intstance.test);
        InputManager.intstance.test = "ss";
        Debug.Log("변경 : " + InputManager.intstance.test);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
