using UnityEngine;

public class CentipedeStairDetection : MonoBehaviour {

    private void Update() {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit, 1f)) {
            if(hit.collider.tag == "Stairs") {
                print("Hitting Stairs!");
            }
        }
    }
}
