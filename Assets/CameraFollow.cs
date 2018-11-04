using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float cameraResponse = 0.1f;
    public Vector3 offset = new Vector3(0, 0, -10);
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        //Vector3 desiredPosition = target.position + offset;
        //transform.position = desiredPosition;

        Vector3 targetPosition = target.TransformPoint(offset);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, cameraResponse);
    }
}
