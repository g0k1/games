using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] float gravity;
    [SerializeField] float sen;

    float directionY;

    Transform posCam;
    CharacterController con;
    void Start()
    {
        con = GetComponent<CharacterController>();

        posCam = GameObject.Find("cameraLoc").transform;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        move();
        MovCamera();
    }

    void move()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal") + transform.up + transform.forward * Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            if (Physics.Raycast(transform.position, Vector3.down, .1f, LayerMask.GetMask("Ground")))
            {
                directionY += jumpForce;
            }
        }
        
        if (!Physics.Raycast(transform.position, Vector3.down, .1f, LayerMask.GetMask("Ground")))
        {
            directionY -= gravity * Time.deltaTime;
        }

        dir.y = directionY;

        con.Move(dir * speed * Time.deltaTime);
    }
    void MovCamera()
    {
        Camera.main.transform.position = posCam.position;

        float X = Input.GetAxis("Mouse X");
        float Y = Input.GetAxis("Mouse Y");

        float axisX = 0;
        axisX += X * sen;

        Vector3 rot = new Vector3(-Y, X, 0);
        Vector3 rotPlayer = new Vector3(0, axisX, 0);

        transform.eulerAngles += rotPlayer;
        Camera.main.transform.eulerAngles += rot * sen;
    }

}
