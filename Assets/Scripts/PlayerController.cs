using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    GameObject playerGO;
    GameObject plectrumGO;
    Camera playerCameraGO;
    Rigidbody playerRB;

    public float jumpForce = 5f;

    public float forwardForce = 1f;
    public float sideForce = 1f;
    public float backwardForce = 1f;



    private void Awake()
    {
        playerGO = this.gameObject;
        plectrumGO = playerGO.transform.Find("PlectrumModel").gameObject;
        playerCameraGO = playerGO.transform.Find("PlayerCamera").GetComponent<Camera>();
        //playerRB = playerGO.transform.Find("PlectrumModel/Model").GetComponent<Rigidbody>();
        playerRB = playerGO.GetComponent<Rigidbody>();
    }




    // Start is called before the first frame update
    void Start()
    {
        
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
    }


    void Jump()
    {
        playerRB.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
    }

    void MoveForward()
    {
        playerRB.AddForce(Vector3.forward * forwardForce, ForceMode.Force);
    }

    void MoveBackwards()
    {
        playerRB.AddForce(Vector3.forward * backwardForce * -1f, ForceMode.Force);
    }



    void MoveLeft()
    {
        playerRB.AddForce(Vector3.left * sideForce, ForceMode.Force);
    }

    void MoveRight()
    {
        playerRB.AddForce(Vector3.right * sideForce, ForceMode.Force);
    }

    void Rotate()
    {

    }




}


