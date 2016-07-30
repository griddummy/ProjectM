using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MyTestSceneMove : MonoBehaviour {

    public int SceneIndex = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SceneManager.LoadScene(SceneIndex);
        }
	}
}
