using UnityEngine;

public class RotateCameraAroundThinkipede : MonoBehaviour {

    [SerializeField] private Transform rotationPoint; 
    [SerializeField] private float rotationSpeed;

    private void Update() {
        transform.RotateAround(rotationPoint.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
