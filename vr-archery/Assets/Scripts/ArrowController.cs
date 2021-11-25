﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
public class ArrowController : MonoBehaviour
{

    public GameObject m_prefabArrow;

    public float m_shootForce;

    public Transform m_arrowStart;

    public Transform m_arrowEnd;

    public Transform m_bowString;

    public Transform m_bowHand;


    private bool m_isTriggerHeld;

    private bool m_isArrowNocked;

    private GameObject m_nockedArrow;
    
    
    //////////// CONTROLLER TEST START /////////////
    
   //  private XRController controller; // 1
   private ActionBasedController controller;
    private void Awake()
    {
        // 2. action based controller with openXR
        controller = GetComponent<ActionBasedController>();

        controller.selectAction.action.started += OnGripStarted;
        controller.selectAction.action.canceled += OnGripCanceled;
        
    }


    private void Start()
    {
        
    }

    private InputAction.CallbackContext GripContext;

    private void OnGripStarted(InputAction.CallbackContext obj)
    {
        
            print("grip");
            /*m_isTriggerHeld = true;
            if(m_isArrowNocked)
            {
                //m_bow.LookAt(transform);

                Vector3 heading = m_arrowEnd.position - m_arrowStart.position;
                float magnitudeOfHeading = heading.magnitude;
                heading.Normalize();

                Vector3 startToHand = transform.position - m_arrowStart.position;
                float dotProduct = Vector3.Dot(startToHand, heading);

                dotProduct = Mathf.Clamp(dotProduct, 0, magnitudeOfHeading);
                Vector3 spot = m_arrowStart.position + heading * dotProduct;

                transform.position = spot;

                m_bowString.position = spot;
                m_nockedArrow.transform.position = spot;
            }*/
    } // OnGripStarted
    
    private void OnGripCanceled(InputAction.CallbackContext obj)
    {
        //Shoot Arrow
        // if (Input.GetAxis(m_trigger) < 0.5f && m_isTriggerHeld)
        /*if ( m_isTriggerHeld)
        {
            print("grip canceled");
            m_isTriggerHeld = false;
            if (m_isArrowNocked)
            {
                m_isArrowNocked = false;
                m_nockedArrow.transform.SetParent(null);
                float finalShootForce = Vector3.Distance(m_bowString.position, m_arrowStart.position) * m_shootForce;
                m_bowString.position = m_arrowStart.position;
                m_nockedArrow.GetComponent<Rigidbody>().isKinematic = false;
                m_nockedArrow.GetComponent<Rigidbody>().AddForce(m_nockedArrow.transform.forward * finalShootForce);
                Destroy(m_nockedArrow, 5f);
                m_nockedArrow = null;
                //m_bow.localEulerAngles = new Vector3(-90, 0, 0);
            }
        }*/
        
        
        
    } // OnGripCanceled
    

    private void Update()
    {
        
       // OldUpdate();
    }

    

    //Nock and arrow
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BowString" && m_isArrowNocked == false)
        {
            m_isArrowNocked = true;
            // m_nockedArrow = Instantiate(m_prefabArrow, m_arrowStart.position, m_arrowStart.rotation, m_arrowStart);
            m_nockedArrow = Instantiate(m_prefabArrow, m_arrowStart.position, Quaternion.identity, m_arrowStart);
        }
    }
    //Nock and arrow
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "BowString" && m_isTriggerHeld == false)
        {
            m_isArrowNocked = false;
            Destroy(m_nockedArrow);
        }
    }
}
