# unity-vr-archery

* INSTALL XR INTERACTION TOOLKIT
	* install it manually Window > package manager > + > add package from git url
	* copy paste "com.unity.xr.interaction.toolkit"  (now at "1.0.0-pre.8") 
	* import "Default Input Actions" and "XR device simulator"
	
* INSTALL XR PLUG-IN MANAGEMENT
 
	Project settings > XR plugin management > PC> oculus and Windows mixed reality
 
	Project settings > XR plugin management > ANDROID > oculus 
 
* delete main camera
 
* in hierarchy: new > XR > XR Rig (action based)
 
* follow these steps:
	* on XR-rig > add component > Input Action Manager  
	* under Input Action Manager > Action assets >  size: 1 - Element 0: XRI Default Input Actions 
	* LeftHand Controller > remove component "XR Controller"
	* under Assets > samples > XR Interaction toolkit > v.v.v > Default Input actions, drag "XRI Default Left Controller.preset" into LeftHand Controller
	* repeat for RightHand Controller
	
* for Hands:
	* remove "XR Ray Interactor", "XR Interactor Line Visual" and "Line Renderer" 
	* add component "XR DIrect Interactor"	