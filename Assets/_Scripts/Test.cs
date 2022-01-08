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

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.H))
        {
            lhand.velocity = Vector3.up * forcePower;
            foreach (var rb in others)
            {
                rb.velocity = Vector3.up * forcePower * multiplier;
            }
        }
        
        if (Input.GetKey(KeyCode.J))
        {
            rhand.velocity = Vector3.up * forcePower;
            foreach (var rb in others)
            {
                rb.velocity = Vector3.up * forcePower * multiplier;
            }
        }
    }
}
