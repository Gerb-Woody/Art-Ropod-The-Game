using UnityEngine;

public class CentipedeMovement : MonoBehaviour {

    [SerializeField] private float moveDistance;
    [SerializeField] private float rotationSpeed;

    private bool[] steps;

    private void Start() {
        steps = new bool[4];
    }

    private void FixedUpdate() {
        CheckForRotation();

        if (Input.GetKey(KeyCode.R) && Input.GetKey(KeyCode.F) && (!steps[0])) {
            MoveCentipede();
            steps[0] = true;
        }

        if (Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.D) && (!steps[1] && steps[0])) {
            MoveCentipede();
            steps[1] = true;
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) && (!steps[2] && steps[1])) {
            MoveCentipede();
            steps[2] = true;
        }

        if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.A) && (!steps[3] && steps[2])) {
            MoveCentipede();
            steps[3] = true;
        }

        else if (!Input.anyKey) {
            ResetSteps();
        }
    }

    private void MoveCentipede() {
        transform.position += transform.forward * moveDistance;
    }

    private void CheckForRotation() {
        if (Input.GetKey(KeyCode.T)) {
            transform.Rotate(transform.up * rotationSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.G)) {
            transform.Rotate(transform.up * -rotationSpeed * Time.deltaTime, Space.World);
        }
    }

    private void ResetSteps() {
        for (int i = 0; i < steps.Length; i++) {
            steps[i] = false;
        }
    }
}