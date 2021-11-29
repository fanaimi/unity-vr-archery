# unity-vr-archery

## INSTALL XR INTERACTION TOOLKIT
	* install it manually Window > package manager > + > add package from git url
	* copy paste "com.unity.xr.interaction.toolkit"  (now at "1.0.0-pre.8") 
	* import "Default Input Actions" and "XR device simulator"
	
## INSTALL XR PLUG-IN MANAGEMENT
 
	* roject settings > XR plugin management > PC> oculus and Windows mixed reality
 
	* Project settings > XR plugin management > ANDROID > oculus 
 
## SETTING UP 
	*  delete main camera
	 
	* in hierarchy: new > XR > XR Rig (action based)
	 
	* follow these steps:
		* on XR-rig > add component > Input Action Manager  
		* under Input Action Manager > Action assets >  size: 1 - Element 0: XRI Default Input Actions 
		* LeftHand Controller > remove component "XR Controller"
		* under Assets > samples > XR Interaction toolkit > v.v.v > Default Input actions, drag "XRI Default Left Controller.preset" into LeftHand Controller
		* repeat for RightHand Controller
	
## for Hands:
	* remove "XR Ray Interactor", "XR Interactor Line Visual" and "Line Renderer" 
	* add component "XR DIrect Interactor"	
	
## About Animating Hands: 
	* check this out! https://www.youtube.com/watch?v=DxKWq7z4Xao&ab_channel=JustinPBarnett-VRGameDev
	
	
## XR DEBUGGER
	* windows > analysis > XR INTERACTION DEBUGGER (in play mode)
	
	
## install OpenXR 
	* get notes from VALEM : https://www.youtube.com/watch?v=u6Rlr2021vw&ab_channel=Valem
```C#
	using UnityEngine.InputSystem;
	private ActionBasedController controller;
	private void Awake()
    {   
        // action based controller with openXR
        controller = GetComponent<ActionBasedController>();

        controller.selectAction.action.performed += OnGrip;
        controller.activateAction.action.performed += OnTrigger;
    }
	
	private void OnGrip(InputAction.CallbackContext obj)
    {
        Debug.Log(obj.valueType);
        print("grip");
	}