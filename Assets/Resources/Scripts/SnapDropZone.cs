using UnityEngine;
using VRTK;

public class SnapDropZone : VRTK_SnapDropZone
{
    public GameObject GameState;
    public GameObject Gun;

    protected override VRTK_InteractableObject ValidSnapObject(GameObject checkObject, bool grabState, bool checkGrabState = true)
    {
        if (!checkObject.CompareTag("Ammunition"))
            return null;
        return base.ValidSnapObject(checkObject, grabState, checkGrabState);   
    }
}
