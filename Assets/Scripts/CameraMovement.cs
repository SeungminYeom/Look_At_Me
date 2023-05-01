using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject playerCamera;

    float mouseX = 0;
    float mouseY = 0;

    void Start()
    {
        
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        Vector3 pos = playerCamera.transform.position;
        pos.y += 1;

        //transform.position = Vector3.Lerp(transform.position, playerCamera.transform.position, 0.9f);
        transform.position = Vector3.Lerp(transform.position, pos, 0.9f);

        Rotate();
    }

    private void LateUpdate()
    {
    }

    void Rotate()
    {
        /*
        if (Input.GetMouseButtonDown(1))
        {
            mouseFixedX = mouseX;
            mouseFixedY = mouseY;
        }

        if (Input.GetMouseButtonUp(1))
        {
            mouseFixedX = mouseFixedY = 0f;
            playerCamera.transform.rotation = Quaternion.identity;
            return;
        }

        if (Input.GetMouseButton(1))
        {
            mouseFixedX += Input.GetAxis("Mouse X") * GameManager.instance.mouseSensitivity;
            mouseFixedY += Input.GetAxis("Mouse Y") * GameManager.instance.mouseSensitivity;
            playerCamera.transform.rotation = Quaternion.Euler(new Vector3(mouseFixedY, mouseFixedX, 0));
        }
        else
        {
            mouseX += Input.GetAxis("Mouse X") * GameManager.instance.mouseSensitivity;
            mouseY += Input.GetAxis("Mouse Y") * GameManager.instance.mouseSensitivity;
            mouseY = Mathf.Clamp(mouseY, -40, 20);

            transform.rotation = Quaternion.Euler(new Vector3(0, mouseX, 0));
            playerCamera.transform.localRotation = Quaternion.Euler(new Vector3(-mouseY, 0, 0));
        }
        */

        mouseX += Input.GetAxis("Mouse X") * GameManager.instance.mouseSensitivity;
        mouseY += Input.GetAxis("Mouse Y") * GameManager.instance.mouseSensitivity;
        mouseY = Mathf.Clamp(mouseY, -40, 20);

        transform.localRotation = Quaternion.Euler(new Vector3(-mouseY, mouseX, 0));
    }
}
