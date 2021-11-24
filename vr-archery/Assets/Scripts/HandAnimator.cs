using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class HandAnimator : MonoBehaviour
{

    public float speed = 5;
    [SerializeField] XRController controller;

    private Animator animator = null;
    


    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        // store input
        CheckGrip();
        CheckPointer();

        // smooth input values

        // apply smoothed values


    }


    private void CheckGrip()
    {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            print("grip!");
        }
    }


    private void CheckPointer()
    {
        
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float pointerValue))
        {
            print("triggered!");
        }
    }


}
