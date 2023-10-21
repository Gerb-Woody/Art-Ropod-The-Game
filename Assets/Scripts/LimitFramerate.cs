using UnityEngine;

public class LimitFramerate : MonoBehaviour {

    private void Awake() {
        Application.targetFrameRate = 60;
    }
}
