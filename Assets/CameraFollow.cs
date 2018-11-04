using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static Transform target;
    public float cameraResponse = 0.1f;
    public Vector3 offset = new Vector3(0, 0, -10);
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        if (target == null)
        {
            return;
        }

        //Vector3 desiredPosition = target.position + offset;
        //transform.position = desiredPosition;

        Vector3 targetPosition = target.TransformPoint(offset);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, cameraResponse);
    }

    public static void FindPlayer()
    {
        GameObject searchResult = GameObject.FindGameObjectWithTag("Player");

        if (searchResult != null)
        {
            target = searchResult.transform;
        }
    }
}