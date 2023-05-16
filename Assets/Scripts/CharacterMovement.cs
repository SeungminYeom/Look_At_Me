using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float characterSpeed;
    [SerializeField] float jumpForce;

    [SerializeField] bool doJump;
    [SerializeField] bool isJump;

    float xAxis;
    float zAxis;

    float mouseX = 0f;
    float mouseY = 0f;
    float mouseFixedX = 0f;
    float mouseFixedY = 0f;

    Rigidbody playerRigid;

    //GameObject playerCamera;

    void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
        //playerCamera = GameObject.Find("CameraArm").gameObject;
    }

    void Update()
    {
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            doJump = true;
        }
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    void Move()
    {
        if (xAxis == 0 && zAxis == 0) return;

        //transform.rotation = Quaternion.Euler(new Vector3(0, playerCamera.transform.eulerAngles.y, 0));
        
        /*
        if (Mathf.Abs(transform.eulerAngles.y - playerCamera.transform.eulerAngles.y) < 10)
        {
            transform.rotation = Quaternion.Euler(0, playerCamera.transform.eulerAngles.y, 0);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, playerCamera.transform.eulerAngles.y, 0)), 0.2f);
        }
        */

        Vector3 velocity = new Vector3(xAxis, 0, zAxis);

        if (velocity.magnitude > 1) velocity = velocity.normalized;
        
        //직진 보정
        velocity = playerRigid.transform.TransformDirection(velocity) * characterSpeed;

        playerRigid.velocity = new Vector3(velocity.x, playerRigid.velocity.y, velocity.z);
    }

    void Jump()
    {
        if (!doJump) return;

        playerRigid.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        doJump = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane")
            isJump = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Plane")
            isJump = true;
    }
}