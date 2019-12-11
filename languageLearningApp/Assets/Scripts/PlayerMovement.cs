using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float ForwardForce = 200f;
    public float sidewaysforce = 500f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, ForwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            //if statement is true execute the below script
            rb.AddForce(0, 0, sidewaysforce * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            //if statement is true execute the below script
            rb.AddForce(0, 0, -sidewaysforce * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(-ForwardForce, 0, 0);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(ForwardForce, 0, 0);
        }
    }
}
