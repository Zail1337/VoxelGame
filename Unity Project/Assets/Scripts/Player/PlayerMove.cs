using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviourClassic
{
    //movement Speed
    public float speed;

    private void FixedUpdate()
    {
        //tracks the input
        var horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        //sets an variable to access the Rotation Tracker Cube
        var Tracker = GameObject.Find("CameraRotationTracker");

        //Controll:

        //Forwards and Backwards
        transform.Translate(Tracker.transform.forward * vertical, Space.World);

        //Left and Right
        transform.Translate(Tracker.transform.right * horizontal, Space.World);
    }

    void Update()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;


        //If Ray is tounching Plane
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            //Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            //Player Look at Point(Variable: pointToLook)(Vector3 to not let the player look down on the Ground)
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }
}