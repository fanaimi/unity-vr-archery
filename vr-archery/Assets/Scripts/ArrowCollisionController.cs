using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollisionController : MonoBehaviour
{
    public Vector3 centreOfMass;
    private Rigidbody rb;
    public bool Awake;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        
        rb.centerOfMass = centreOfMass;  rb.WakeUp();
        Awake = !rb.IsSleeping();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(transform.position + transform.rotation*centreOfMass,0.1f);
    }
    
    // https://docs.unity3d.com/ScriptReference/Rigidbody-centerOfMass.html
    // Simple player bow and arrow attack in Unity
    //https://www.youtube.com/watch?v=Fu9X3OowEy0&ab_channel=NicolaiAndersen

    
    // Edit > Projects Settings > Physycs > uncheck IgnoreCollision layer we created and applied beforehand
    
    private void OnTriggerEnter(Collider collider)
    {
        print("trigger enter!");
        print(collider.name);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        // VS rb.addTorque(transform.right * torque);
        rb.isKinematic = true;
        transform.SetParent(collider.transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        
        if(collision.collider.tag == "Arrow")
        {
            collision.collider.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    
}