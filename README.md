# unity-vr-archery


## new input
```c#
   private ActionBasedController controller;
    private void Awake()
    {   
        //  action based controller with openXR
        controller = GetComponent<ActionBasedController>();

        controller.selectAction.action.started += OnGripStarted;
        controller.selectAction.action.canceled += OnGripCanceled;
    }

```