using UnityEngine;
using VRTK;

public class TransformFollow : VRTK_TransformFollow
{
    protected override void SetRotationOnGameObject(Quaternion newRotation)
    {
        newRotation.x = transformToChange.rotation.x;
        newRotation.z = transformToChange.rotation.z;
        transformToChange.rotation = newRotation;
    }
}
