using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollisionController : MonoBehaviour
{
    public Vector3 centreOfMass;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centreOfMass;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    // https://docs.unity3d.com/ScriptReference/Rigidbody-centerOfMass.html
    
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Arrow")
        {
            collision.collider.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    
}