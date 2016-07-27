using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {
    // 카메라 관리 클래스
    public Camera camera1;
    public Camera camera2;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            Camera.SetupCurrent(camera1);
        }
        else if(Input.GetKeyUp(KeyCode.Alpha2))
        {
            Camera.SetupCurrent(camera2);
        }
    }    
}
