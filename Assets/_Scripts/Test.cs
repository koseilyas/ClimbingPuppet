using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Rigidbody rhand,lhand;
    public Rigidbody[] others;
    public ForceMode forceMode;
    public float forcePower;
    public float multiplier;
    public Transform testCube;
    Vector3 dir = Vector3.up;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.H))
        {
            dir = (testCube.position - lhand.position).normalized;
            lhand.velocity = dir * forcePower;
            foreach (var rb in others)
            {
                rb.velocity = dir * forcePower * multiplier;
            }
        }
        
        
        if (Input.GetKey(KeyCode.J))
        {
            dir = (testCube.position - rhand.position).normalized;
            rhand.velocity = dir * forcePower;
            foreach (var rb in others)
            {
                rb.velocity = dir * forcePower * multiplier;
            }
        }
    }
}
