using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.RawImage fadeScreen;

    private void Start() {
        StartCoroutine(FadeGameIn());
    }

    public void PlayGame()
    {
        StartCoroutine(FadeGameOut(1));
    }

    public void QuitGame()
    {
        StartCoroutine(FadeGameOut(-1));
    }

    public void BackToMainMenu() {
        StartCoroutine(FadeGameOut(0));
    }

    private IEnumerator FadeGameOut(int sceneIndex) {
        int fadeTimer = 3;
        float fadeAmountPerPass = 0.01f;

        fadeScreen.raycastTarget = true;

        while (fadeScreen.color.a < 1f) {
            float a = fadeScreen.color.a;
            a += fadeAmountPerPass;
            fadeScreen.color = new Color(0, 0, 0, a);

            yield return new WaitForSeconds(fadeAmountPerPass * fadeTimer);
        }

        LoadScene(sceneIndex);
    }

    private IEnumerator FadeGameIn() {
        int fadeTimer = 3;
        float fadeAmountPerPass = 0.01f;

        while (fadeScreen.color.a > 0f) {
            float a = fadeScreen.color.a;
            a -= fadeAmountPerPass;
            fadeScreen.color = new Color(0, 0, 0, a);

            yield return new WaitForSeconds(fadeAmountPerPass * fadeTimer);
        }

        fadeScreen.raycastTarget = false;
    }

    private void LoadScene(int sceneIndex) {
        if (sceneIndex == -1) {
            Application.Quit();
            return;
        }

        SceneManager.LoadScene(sceneIndex);
    }
}
