using System;
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

    [SerializeField] private Transform m_arrowOrigin;
    
    private bool isGripped = false;
    
    private bool inPosition = false;
   
    
   private ActionBasedController controller;
    private void Awake()
    {   
        // 2. action based controller with openXR
        controller = GetComponent<ActionBasedController>();


        SubscribeNEWscript();
    }


    
    
    private void SubscribeNEWscript()
    {
        
        controller.selectAction.action.started += OnGripStarted;
        controller.selectAction.action.canceled += OnGripCanceled;
    } // SubscribeNEWscript


    


    private void Update()
    {
        if (isGripping)
        {
            // print("grippin....");
            m_nockedArrow.transform.rotation = m_arrowStart.rotation;
        }
    }

    private bool isGripping = false;
    
    private void OnGripStarted(InputAction.CallbackContext context)
    {
        if (inPosition)
        {
            isGripping = true;
            
            m_nockedArrow = Instantiate(
                m_prefabArrow, 
                m_arrowOrigin.position, 
                m_arrowOrigin.rotation, 
                m_arrowOrigin 
            );
        }
        m_isTriggerHeld = true;
    } // OnGripStarted
    
    
    private void OnGripCanceled(InputAction.CallbackContext context)
    {
        if (isGripping)
        {
            isGripping = false;
            ThrowArrow();
        }
    } // OnGripCanceled


    private void ThrowArrow()
    {
       // print("arrow thrown"); 
        m_isTriggerHeld = false;
      
            m_isArrowNocked = false;
            m_nockedArrow.transform.SetParent(null);
            float finalShootForce = Vector3.Distance(m_bowString.position, m_arrowStart.position) * m_shootForce;
            m_bowString.position = m_arrowStart.position;
            m_nockedArrow.GetComponent<Rigidbody>().isKinematic = false;
            m_nockedArrow.GetComponent<Rigidbody>().AddForce(m_bowHand.transform.forward * finalShootForce);
            m_nockedArrow.GetComponent<Rigidbody>().AddTorque(transform.right * 5);  // torque);;
            Destroy(m_nockedArrow, 25f); 
            m_nockedArrow = null;
        
    } // throwArrow


    //Nock and arrow
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BowString"  )
        {
            inPosition = true;
            // print(inPosition);
        }
    }
    //Nock and arrow
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "BowString")
        {
            inPosition = false;
            //print(inPosition);
        }
    }
}
