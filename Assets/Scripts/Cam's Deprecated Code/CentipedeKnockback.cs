using UnityEngine;

public class CentipedeKnockback : MonoBehaviour {

    private Rigidbody rb;
    private int forceAmount = 8;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Debris") {
            print("Hit");
            rb.AddForce(-transform.forward * forceAmount, ForceMode.Impulse);
        }
    }
}
