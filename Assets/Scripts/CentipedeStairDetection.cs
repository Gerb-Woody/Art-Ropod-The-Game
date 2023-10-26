using UnityEngine;

public class CentipedeStairDetection : MonoBehaviour {

    Rigidbody rb;
    CapsuleCollider capsuleCollider;

    [SerializeField] private Transform raycastPoint;

    private bool forwardRayIsHitting;
    private bool downwardRayIsHitting;
    private float castDistance = 0.75f;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = rb.GetComponent<CapsuleCollider>();
    }

    private void Update() {
        SendRaycasts();

        if (forwardRayIsHitting && downwardRayIsHitting) {
            transform.rotation = Quaternion.Euler(-90, transform.rotation.y + 180, transform.rotation.z);
            rb.useGravity = false;
            capsuleCollider.enabled = false;
        }

        else if (!forwardRayIsHitting && !downwardRayIsHitting) {
            transform.rotation = Quaternion.Euler(0, transform.rotation.y + 180, transform.rotation.z);
            rb.useGravity = true;
            capsuleCollider.enabled = true;
        }
    }

    private void SendRaycasts() {
        RaycastHit forwardHit;
        RaycastHit downwardHit;

        Debug.DrawRay(raycastPoint.position, transform.forward * castDistance, Color.red);
        Debug.DrawRay(raycastPoint.position, -transform.up * castDistance, Color.red);

        if (Physics.Raycast(raycastPoint.position, transform.forward, out forwardHit, castDistance)) {
            if (forwardHit.collider.tag == "Ground") {
                forwardRayIsHitting = true;
            }
        }

        else {
            forwardRayIsHitting = false;
        }

        if (Physics.Raycast(raycastPoint.position, -transform.up, out downwardHit, castDistance)) {
            if (downwardHit.collider.tag == "Ground") {
                downwardRayIsHitting = true;
            }
        }

        else {
            downwardRayIsHitting = false;
        }
    }
}
