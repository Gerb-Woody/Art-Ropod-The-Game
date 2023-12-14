using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform centipedeHead;
    [SerializeField] private float smoothing;

    [SerializeField] private bool facingOtherWay;

    private Vector3 velocity = Vector3.zero;

    [SerializeField] private float yOffset = 5;
    [SerializeField] private float zOffset = -10; //Values so the cam direction can be reversed

    private void Update()
    {

        if (facingOtherWay)
        {
            Vector3 targetPosition = new Vector3(centipedeHead.position.x, centipedeHead.position.y + yOffset, centipedeHead.position.z + -zOffset);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothing);
        }
        else
        {
            Vector3 targetPosition = new Vector3(centipedeHead.position.x, centipedeHead.position.y + yOffset, centipedeHead.position.z + zOffset);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothing);
        }

    }
}
