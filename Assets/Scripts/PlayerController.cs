using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    #region variables

    GameObject playerGO;
    GameObject plectrumGO;
    Camera playerCamera;
    GameObject playerCameraHolderGO;
    Rigidbody playerRB;
    GameObject bottomGO;



    public float jumpForce = 5f;

    public float forwardForce = 1f;
    public float sideForce = 1f;
    public float backwardForce = 1f;

    public bool inAir;
    public bool trippleJumpAvailable;



    //Camera
    private Vector3 _LocalRotation;
    private float rotateX;
    private float rotateY;

    public float camDistance;
    public float orbitSpeed = 10.0f;
    public float zoomSpeed = 5.0f;
    public float camMaxDistance = 100.0f;
    public float camMinDistance = 1.0f;

    public float smoothFactorZoom = 0.5f;
    public float smoothFactorOrbit = 0.8f;
    public float smoothCameraStepY = 0.2f;

    public float camStartDistance = 9.0f;
    public Vector3 camStartRotation;

    #endregion variables
    #region awake & update

    private void Awake()
    {
        playerGO = this.gameObject;
        plectrumGO = playerGO.transform.Find("PlectrumModel").gameObject;
        playerCameraHolderGO = playerGO.transform.Find("CameraHolder").gameObject;
        playerCamera = playerCameraHolderGO.transform.Find("PlayerCamera").GetComponent<Camera>();
        //playerRB = playerGO.transform.Find("PlectrumModel/Model").GetComponent<Rigidbody>();
        playerRB = playerGO.GetComponent<Rigidbody>();
        bottomGO = playerGO.transform.Find("Bottom").gameObject;

        Cursor.visible = false;

    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MoveForward();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MoveBackwards();
        }

        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        RotateBody();
        RotateCamera();


        if (Physics.Raycast(bottomGO.transform.position, -Vector3.up,0.1f))
        {
            inAir = false;
        }
    }

#endregion

    #region movement
    void Jump()
    {
        if (!inAir)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            trippleJumpAvailable = true;
            inAir = true;
        }
        else if (trippleJumpAvailable)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            trippleJumpAvailable = false;
        }

    }

    void MoveForward()
    {
        playerRB.AddForce(playerGO.transform.forward * forwardForce, ForceMode.Force);
    }

    void MoveBackwards()
    {
        playerRB.AddForce(playerGO.transform.forward * backwardForce * -1f, ForceMode.Force);
    }



    void MoveLeft()
    {
        playerRB.AddForce(playerGO.transform.right * -sideForce, ForceMode.Force);
    }

    void MoveRight()
    {
        playerRB.AddForce(playerGO.transform.right * sideForce, ForceMode.Force);
    }
    #endregion

    void RotateBody()
    {
        if(Input.GetAxis("Mouse X") != 0)
        {
            _LocalRotation.x += Input.GetAxis("Mouse X") * orbitSpeed;
        }



        //Changing Body
        Quaternion bodyTurnAngle = Quaternion.Euler(0, _LocalRotation.x, 0);
        playerGO.transform.rotation =
            Quaternion.Lerp(
                playerGO.transform.rotation,
                bodyTurnAngle,
                Time.deltaTime * smoothFactorOrbit);
    }




    void RotateCamera()
    {
        if (Input.GetAxis("Mouse Y") != 0)
        {

            _LocalRotation.y -= Input.GetAxis("Mouse Y") * orbitSpeed;
            //Clamp Y Axis
            _LocalRotation.y = Mathf.Clamp(_LocalRotation.y, -90f, 90f);

            //Debug.Log(Input.GetAxis("Mouse Y"));
        }


        //Zoom

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            float scrollAmount = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            scrollAmount *= this.camDistance;

            this.camDistance += scrollAmount * -1f;
            this.camDistance = Mathf.Clamp(this.camDistance, camMinDistance, camMaxDistance);

        }



        //Changing Camera rotation
        Quaternion camTurnAngle = Quaternion.Euler(_LocalRotation.y, 0, 0);
        //Debug.Log("Quarternion: "+camTurnAngle+". _LocalRotation.y: "+_LocalRotation.y);

        playerCameraHolderGO.transform.localRotation =
            Quaternion.RotateTowards(
                playerCameraHolderGO.transform.localRotation,
                camTurnAngle,
                smoothCameraStepY);


        //Apply Zoom
        if (playerCamera.transform.localPosition.z != this.camDistance * -1)
        {
            playerCamera.transform.localPosition =
                new Vector3(0f, 0f, Mathf.Lerp(
                    playerCamera.transform.localPosition.z,
                    this.camDistance * -1f,
                    Time.deltaTime * smoothFactorZoom));




        }
    }
}


