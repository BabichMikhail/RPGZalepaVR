using UnityEngine;
using VRTK;

public class GameController : MonoBehaviour
{
    public GameObject GameState;

    private Vector3 position;
    private GameStateController gameStateController;

    private void Start ()
    {
        var controllerEvents = GetComponent<VRTK_ControllerEvents>();
        if (controllerEvents != null) {
            controllerEvents.GripReleased += new ControllerInteractionEventHandler(OnGripReleased);
            controllerEvents.TouchpadReleased += new ControllerInteractionEventHandler(OnTouchpadReleased);
        }
        

        //gameStateController = GameState.GetComponent<GameStateController>();

       // position = transform.position;
    }

    private void Update ()
    {
        /*var newPosition = transform.position;
        gameStateController.ActionPoints -= 0.5f * (position - newPosition).magnitude;
        position = newPosition;
        Debug.Log(transform.position);

        if (gameStateController.ActionPoints <= 0.0f) {
            gameObject.GetComponent<VRTK_BezierPointerRenderer>().enabled = false;
        }*/
    }

    private void OnGripReleased(object sender, ControllerInteractionEventArgs e)
    {
        Debug.Log("Hello world");
    }

    private void OnTouchpadReleased(object sender, ControllerInteractionEventArgs e)
    {
        Debug.Log("On teleport");
    }
}
