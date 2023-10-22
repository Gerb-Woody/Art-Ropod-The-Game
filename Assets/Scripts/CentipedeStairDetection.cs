using UnityEngine;

public class CentipedeStairDetection : MonoBehaviour {

    private bool forwardRayIsHitting;
    private bool downwardRayIsHitting;

    private void Update() {
        SendRaycasts();

        if (forwardRayIsHitting && downwardRayIsHitting) {
            transform.rotation = Quaternion.Euler(-90, transform.rotation.y, transform.rotation.z);
        }

        else if (!forwardRayIsHitting && !downwardRayIsHitting) {
            transform.rotation = Quaternion.Euler(0, transform.rotation.y, transform.rotation.z);
        }
    }

    private void SendRaycasts() {
        RaycastHit forwardHit;
        RaycastHit downwardHit;

        Debug.DrawRay(transform.position, transform.forward * 1, Color.red);
        Debug.DrawRay(transform.position, -transform.up * 1, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out forwardHit, 1f)) {
            if (forwardHit.collider.tag == "Ground") {
                forwardRayIsHitting = true;
            }
        }

        else {
            forwardRayIsHitting = false;
        }

        if (Physics.Raycast(transform.position, -transform.up, out downwardHit, 1f)) {
            if (downwardHit.collider.tag == "Ground") {
                downwardRayIsHitting = true;
            }
        }

        else {
            downwardRayIsHitting = false;
        }
    }
}
