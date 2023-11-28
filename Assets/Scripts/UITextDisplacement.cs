using System.Collections;
using UnityEngine;

public class UITextDisplacement : MonoBehaviour {

    [SerializeField] private int displacementDistance = 5;
    [SerializeField] private float timeBetweenDisplacements = 0.2f;

    private Vector2 startingPosition;
    private RectTransform rect;

    private void Awake() {
        rect = GetComponent<RectTransform>();

        startingPosition = rect.anchoredPosition;
        // StartCoroutine(ChangeTextPosition());
    }

    private void OnEnable() {
        StartCoroutine(ChangeTextPosition());
    }

    private IEnumerator ChangeTextPosition() {
        while (true) {
            rect.anchoredPosition = CalculateNewPosition();

            yield return new WaitForSecondsRealtime(timeBetweenDisplacements);
        }
    }

    private Vector2 CalculateNewPosition() {
        float randX = Random.Range(startingPosition.x - displacementDistance, startingPosition.x + displacementDistance);
        float randY = Random.Range(startingPosition.y - displacementDistance, startingPosition.y + displacementDistance);

        return new Vector2(randX, randY);
    }
}
