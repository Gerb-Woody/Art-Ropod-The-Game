using System.Collections;
using UnityEngine;

public class DynamicMusicManager : MonoBehaviour {

    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private Transform player;
    [SerializeField] private Transform cresendoPoint;
    [SerializeField] private AudioSource[] musicSources; // 0 - Low | 1 - Mid | 2 - High

    private AudioSource currentMusic;

    private const float fadeAmount = 0.01f;
    private const int fadeLengthInSeconds = 5;
    private bool playerReachedEnd;
    private bool routineIsRunning;

    private void Start() {
        SetAllMusicVolumeAtStart();

        currentMusic = musicSources[0];
        StartCoroutine(FadeInLowMusic());
    }

    private void Update() {
        if (!playerReachedEnd) {
            if ((PlayerDistanceToCresendo() > 46f) && (currentMusic != musicSources[0]) && !routineIsRunning) {
                StartCoroutine(FadeInLowMusic());
            }

            else if ((PlayerDistanceToCresendo() <= 46f && PlayerDistanceToCresendo() > 5f) && (currentMusic != musicSources[1]) && !routineIsRunning) {
                StartCoroutine(FadeInMidMusic());
            }

            else if ((PlayerDistanceToCresendo() <= 5f) && (currentMusic != musicSources[2]) && !routineIsRunning) {
                playerReachedEnd = true;
                StartCoroutine(FadeInHighMusic());
            }
        }
    }

    private void SetAllMusicVolumeAtStart() {
        musicSources[0].volume = 0f;
        musicSources[1].volume = 0f;
        musicSources[2].volume = 0f;
    }

    private IEnumerator FadeInLowMusic() {
        routineIsRunning = true;

        if (currentMusic != musicSources[0]) {
            while (musicSources[0].volume < 1) {
                currentMusic.volume -= fadeAmount;
                musicSources[0].volume += fadeAmount;
                yield return new WaitForSeconds(fadeAmount * fadeLengthInSeconds);
            }

            currentMusic = musicSources[0];
        }

        else {
            while (currentMusic.volume < 1) {
                currentMusic.volume += fadeAmount;
                yield return new WaitForSeconds(fadeAmount * fadeLengthInSeconds);
            }
        }

        routineIsRunning = false;
        ResetMusicVolume();
    }

    private IEnumerator FadeInMidMusic() {
        routineIsRunning = true;

        while (musicSources[1].volume < 1) {
            currentMusic.volume -= fadeAmount;
            musicSources[1].volume += fadeAmount;
            yield return new WaitForSeconds(fadeAmount * fadeLengthInSeconds);
        }

        currentMusic = musicSources[1];
        routineIsRunning = false;
        ResetMusicVolume();
    }

    private IEnumerator FadeInHighMusic() {
        musicSources[2].Play();

        while (musicSources[2].volume < 1) {
            currentMusic.volume -= fadeAmount;
            musicSources[2].volume += fadeAmount;
            yield return new WaitForSeconds(fadeAmount * fadeLengthInSeconds);
        }

        currentMusic = musicSources[2];
        Invoke("CallBackToMainMenu", 60f);
        ResetMusicVolume();
    }

    private void CallBackToMainMenu() {
        sceneLoader.BackToMainMenu();
    }

    private float PlayerDistanceToCresendo() {
        return Vector3.Distance(player.position, cresendoPoint.position);
    }

    private void ResetMusicVolume() {
        foreach (AudioSource music in musicSources) {
            if (music != currentMusic) {
                music.volume = 0;
            }
        }
    }
}
