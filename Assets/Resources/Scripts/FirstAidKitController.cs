using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class FirstAidKitController : MonoBehaviour
{
    private void Start()
    {
        var controllerEvents = GetComponent<VRTK_ControllerEvents>();
        controllerEvents.GripPressed += new ControllerInteractionEventHandler(OnGripPressed);
        controllerEvents.GripReleased += new ControllerInteractionEventHandler(OnGripReleased);
        controllerEvents.AliasUseOn += new ControllerInteractionEventHandler(OnUse); // TODO remove it;
       
        Debug.Log("Initialized");
    }

    private bool isGrabbActive = false;

    public void OnUse(object sender, ControllerInteractionEventArgs e)
    {
        //if (isGrabbActive)
        //    Destroy((GameObject)sender, 0.1f);

        var grabbedObject = GetComponent<VRTK_InteractGrab>().GetGrabbedObject();
        if (grabbedObject != null && grabbedObject.CompareTag("FirstAidKit"))

            
        
        Debug.Log("USE");
    }

    public void OnGripPressed(object sender, ControllerInteractionEventArgs e)
    {
        isGrabbActive = true;
        Debug.Log("START GRAB");
    }

    public void OnGripReleased(object sender, ControllerInteractionEventArgs e)
    {
        isGrabbActive = false;
        Debug.Log("FINISH GRAB");
    }
}
