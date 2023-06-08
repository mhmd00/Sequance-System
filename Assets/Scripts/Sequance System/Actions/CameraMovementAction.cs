using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraMovementAction : Action
{
    public Transform cameraTransform;
    public Transform targetCameraTransform;
    public float cameraMovementDuration;
    public float targetCameraYAxisOffset;
    public float targetCameraXAxisOffset;
    public float targetCameraZAxisOffset;

    public override IEnumerator ExecuteAction()
    {
        Vector3 startPosition = cameraTransform.position;
        Quaternion startRotation = cameraTransform.rotation;
        float elapsedTime = 0f;

        while (elapsedTime < cameraMovementDuration)
        {
            float time = elapsedTime / cameraMovementDuration;
            cameraTransform.position = Vector3.Lerp(startPosition, targetCameraTransform.position+
                new Vector3(targetCameraXAxisOffset, targetCameraYAxisOffset, targetCameraZAxisOffset), time);
            //cameraTransform.rotation = Quaternion.Lerp(startRotation, targetCameraTransform.rotation, time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        //cameraTransform.position = targetCameraTransform.position;
        //cameraTransform.rotation = targetCameraTransform.rotation;
    }
}
