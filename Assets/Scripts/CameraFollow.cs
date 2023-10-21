using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] private Transform centipedeHead;
    [SerializeField] private float smoothing;

    private Vector3 velocity = Vector3.zero;

    private void Update() {
        Vector3 targetPosition = new Vector3(centipedeHead.position.x, centipedeHead.position.y + 4, centipedeHead.position.z - 6);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothing);
    }
}
