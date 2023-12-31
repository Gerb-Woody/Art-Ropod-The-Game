using UnityEngine;

public class BodyPartFollow : MonoBehaviour {

    [SerializeField] private Transform followPart;
    [SerializeField] private float smoothing;
    [SerializeField] private float followDistance;

    private Vector3 velocity = Vector3.zero;

    private void Update() {
        transform.position = Vector3.SmoothDamp(transform.position, followPart.position, ref velocity, smoothing);
        transform.rotation = followPart.rotation;
    }
}
