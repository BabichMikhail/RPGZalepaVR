using UnityEngine;
using VRTK;

public class GameController : MonoBehaviour
{
    public GameObject GameState;

    private Vector3 position;
    private GameStateController gameStateController;

    private void Start()
    {
        var controllerEvents = GetComponent<VRTK_ControllerEvents>();
        Debug.Assert(controllerEvents != null);
        controllerEvents.GripPressed += new ControllerInteractionEventHandler(OnGripPressed);
        controllerEvents.GripReleased += new ControllerInteractionEventHandler(OnGripReleased);
        controllerEvents.AliasUseOn += new ControllerInteractionEventHandler(OnUse); // TODO remove it;

        Debug.Log("Initialized");
    }

    private bool isGrabbActive = false;

    public void OnUse(object sender, ControllerInteractionEventArgs e)
    {
        var grabbedObject = GetComponent<VRTK_InteractGrab>().GetGrabbedObject();
        Debug.Log(grabbedObject);
        if (grabbedObject != null) {
            if (grabbedObject.CompareTag("FirstAidKit"))
                GameState.GetComponent<GameStateController>().UseFirstAidKit(grabbedObject);
            else if (grabbedObject.CompareTag("Gun"))
                GameState.GetComponent<GameStateController>().UseGun(grabbedObject);
        }
    }

    public void OnGripPressed(object sender, ControllerInteractionEventArgs e)
    {
        var grabbedObject = GetComponent<VRTK_InteractGrab>().GetGrabbedObject();
        Debug.Log(grabbedObject);
        if (grabbedObject != null)
            if (grabbedObject.CompareTag("Gun"))
                GameState.GetComponent<GameStateController>().SetGun(grabbedObject);
        isGrabbActive = true;
    }

    public void OnGripReleased(object sender, ControllerInteractionEventArgs e)
    {
        isGrabbActive = false;
    }
}
