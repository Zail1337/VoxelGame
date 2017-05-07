using UnityEngine;

public class Old_PlayerMove : MonoBehaviour {


    //Variables:
    public float moveSpeed = 3.0f;

    private Vector3 moveInput;

    private Camera mainCamera;


    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
    }


    void Update()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;


        //If Ray is tounching Plane
        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            //Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            //Player Look at Point(Variable: pointToLook)(Vector3 to not let the player look down on the Ground)
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z ));
        }
    }

    //Better way for Player Controlling, because it is not based on FPS.
    private void FixedUpdate()
    {
        float yRotation = mainCamera.transform.eulerAngles.y;

    }
}
