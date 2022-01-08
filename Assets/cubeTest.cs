using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeTest : MonoBehaviour
{
    public HingeJoint hingeJoint;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "basic_rig L Hand")
        {
            GetComponent<BoxCollider>().enabled = false;
            hingeJoint.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
        }
    }
}
