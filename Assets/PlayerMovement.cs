using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //https://www.youtube.com/watch?v=f473C43s8nE

    [Header("Movement")]

    public float moveSpeed;
    public Transform orientation;
    float HorInput;
    float VerInput;
    Vector3 moveDir;

    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
        SpeedControl();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MyInput()
    {
        HorInput = Input.GetAxisRaw("Horizontal");
        VerInput = Input.GetAxisRaw("Vertical");
    }

    public void MovePlayer()
    {
        moveDir = orientation.forward * VerInput + orientation.right * HorInput;
        rb.AddForce(moveDir.normalized * moveSpeed * 10f,ForceMode.Force);
    }

    void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude>moveSpeed)
        {
            Vector3 limVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limVel.x, rb.velocity.y, limVel.z);
        }
    }
}
