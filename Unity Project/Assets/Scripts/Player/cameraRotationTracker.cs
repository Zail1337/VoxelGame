using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotationTracker : MonoBehaviour {
	void Update () {
        //sets an variable to access the Camera
        var myCam = GameObject.Find("Main Camera");

        //binds the y rotation of the Camera to an Variable
        Vector3 eulerRotation = new Vector3(transform.eulerAngles.x, myCam.transform.eulerAngles.y, transform.eulerAngles.z);

        //Set te Rotation from the Camera to the own Roation
        transform.rotation = Quaternion.Euler(eulerRotation);
    }
}
